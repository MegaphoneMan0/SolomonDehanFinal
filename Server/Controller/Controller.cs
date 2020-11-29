using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BidLibrary.Library;
using Server.Model;
using Server.View;


namespace Server.Controller
{
    class Controller : ReadMessage, UserVerifier, UpdateClientList, ProductUpdater, LoadInitialProducts
    {
        //I TOTALLY FORGOT ABOUT THE TIMERS AND ALL THAT
        //SHIT
        //ALRIGHT, I NEED TO FIND HOW I DID IT EARLIER THIS YEAR. PRETTY SURE I CAN REPLICATE THAT... SORT OF
        //FUCK

        //aight, the max amount of time that we can support is a bit longer that 24 days
        //effectively, we could probably get away with bit a bit longer than that, but that's the safe bound
        public System.Timers.Timer aTimer = new System.Timers.Timer();
        


        /// <summary>
        /// a list of observers that update based on the form
        /// </summary>
        private Observer observer;

        /// <summary>
        /// the communicator which handles communication between the server and connected clients
        /// </summary>
        private Communicator communicator;

        /// <summary>
        /// default constructor
        /// </summary>
        public Controller()
        {
            
        }

        /// <summary>
        /// Adds a product to the database
        /// </summary>
        /// <param name="p"></param>
        public void UpdateProduct(Product p)
        {
            //add the new product to the database
            Database.addProduct(p);

            //create a new message with all of the products
            List<Product> products = Database.returnAllProducts();
            Message newMessage = new Message(MessageType.Product_List_Information, products);

            //send out the updated list
            communicator.sendMessageToClients(newMessage);

            //this isn't done, I need to do something with the observer to update the server form
            observer.Update(State.Adding_A_Product);



        }//UpdateProduct

        /// <summary>
        /// Verify's the user's login credentials
        /// </summary>
        /// <param name="username">the username of the user</param>
        /// <param name="password">the password of the user</param>
        /// <returns>returns true of the username and password matched. Returns false if they did not</returns>
        public bool VerifyUser(string username,string password)
        {
            observer.Update(State.Recieved_Credentials);

            User user = Database.searchUser(username);

            if(user == null)
            {
                return false;
            }//if
            else
            {
                if (user.getPassword().Equals(password))
                {
                    observer.Update(State.Aproved);
                    return true;
                }//if
                else
                {
                    observer.Update(State.Denied);
                    return false;
                }//else
            }//else
        }//VerifyUser

        /// <summary>
        /// reads the message from the client and reacts depending on the message type
        /// </summary>
        /// <param name="message">the message that is being read</param>
        /// <returns>the message (if its credential verification) or null if it's a new bid</returns>
        public Message ReadMessage(Message message)
        {
            //reads a message and reacts appropriatly 

            MessageType messageType = message.getMessageType();
            

            switch(messageType)
            {
                case MessageType.Credential_Information:
                    string userName = message.getUserName();
                    string password = message.getPassword();

                    Message newMessage;

                    //if the credential info is correct
                    if(VerifyUser(message.getUserName(), message.getPassword()))
                    {
                        newMessage = new Message(MessageType.Credential_Information_Verification, userName, password, true);
                    }//if
                    else
                    {
                        newMessage = new Message(MessageType.Credential_Information_Verification, userName, password, false);
                    }//else

                    return newMessage;
                    break;

                case MessageType.New_Bid:
                    
                    //the new bid is already verified to be good
                    Product newProduct = message.getProducts().First<Product>();
                    Bid newBid = newProduct.getBid();

                    //first, let's get the existing product from our database
                    Product existingProduct = Database.searchProduct(newProduct.getID());

                    //second, we need to get rid of it's existing bid in the database
                    Database.removeBid(existingProduct.getBid());

                    //then we can update that product with our new bid
                    existingProduct.setBid(newBid);

                    //swank, time to log that bid in the bid library
                    Database.addBid(newBid);

                    //now we need to create a message containing the new bid to send out to our clients.
                    //this is going to be basically the same as when we send the whole product list
                    List<Product> products = Database.returnAllProducts();

                    newMessage = new Message(MessageType.Product_List_Information, products);



                    //alright, I need to update the bidtimers and such

                    //copying a lot of this out of an earlier lab, lets hope it flies
                    SetMostCurrentTimer();

                    observer.Update(State.Recieved_New_Bid);
                    return newMessage;
                    break;

                default:

                    //if the message isn't one of these two type we do nothing
                    return null;
                    break;


            }//switch

        }//ReadMessage

        /// <summary>
        /// updates the client list in the view
        /// </summary>
        /// <param name="clientList">the list of clients to be pushed to the view</param>
        public List<Product> UpdateClientList(List<string> clientList)
        {


            //since there isn't a difference in the controller between how we handle losing a client or recieving a new one, I just say that we recieved a new one.
            observer.Update(State.Recieved_New_Client);


            //this is the return, that's easy
            List <Product> products = Database.returnAllProducts();
            return products;
        }

        /// <summary>
        /// This method is called from the login screen when it's constructed to load the initial products from the file at the given address
        /// </summary>
        public void LoadInitialProducts()
        {
            //this needs to load the products from a file into the database. How? WHO KNOWS
            //this is based of the example on the microsoft docs
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Products\InitialProducts.txt");

            foreach(string s in lines)
            {
                Product product = new Product(s);
                Database.addProduct(product);
            }//foreach

        }

        /// <summary>
        /// This will set the active timer, which will trigger OnTimedEvent. OnTimedEvent should also set the next timer
        /// </summary>
        /// <param name="amountOfTime">the amount of time till the bid is up in milliseconds</param>
        private void SetTimer(int amountOfTime)
        {

            aTimer = new System.Timers.Timer(amountOfTime);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        /// <summary>
        /// this event is tripped whenever aTimer goes off
        /// </summary>
        /// <param name="source">who knows</param>
        /// <param name="e">*shrug*</param>
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            //the timer's up, let's do this
            Console.WriteLine("One of the bid timers is up");

            SetMostCurrentTimer();


        }//onTimedEvent

        /// <summary>
        /// This is just because I had to use this exact same giant block of code twice. Looks cleaner this way.
        /// All it does is set a "nextTimer" to the highest possible value, then checks which timer in all of the bids is the lowest.
        /// This method is called whenever a new bid is added or whenever the current timer goes off. 
        /// </summary>
        private void SetMostCurrentTimer()
        {
            int nextTimer = 2147483500;
            bool nothing = false;//if this bool is still false by the end, it means there was nothing and we need to just get rid of the timer

            //determine the next timer
            foreach (Bid b in Database.getAllBids())
            {
                double timeSpanInMill = b.getTimer();
                int intTimeSpan = Convert.ToInt32(timeSpanInMill);

                if ((intTimeSpan < nextTimer) & (intTimeSpan > 0))
                {
                    nextTimer = intTimeSpan;
                    nothing = true;
                }//if

            }//foreach

            if (nothing)
            {
                aTimer.Dispose();

                SetTimer(nextTimer);
            }//if
            else
            {
                aTimer.Dispose();

            }//else
        }





    }//class
}//namespace
