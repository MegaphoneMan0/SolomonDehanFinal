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
    class Controller : ReadMessage, UserVerifier, UpdateClientList, ProductUpdater, TimesUp
    {
        /*
        //I TOTALLY FORGOT ABOUT THE TIMERS AND ALL THAT
        //SHIT
        //ALRIGHT, I NEED TO FIND HOW I DID IT EARLIER THIS YEAR. PRETTY SURE I CAN REPLICATE THAT... SORT OF
        //FUCK

        //aight, the max amount of time that we can support is a bit longer that 24 days
        //effectively, we could probably get away with bit a bit longer than that, but that's the safe bound
        //public System.Timers.Timer aTimer = new System.Timers.Timer();
        
        //lol, jk, no timers necessary
        //creating the thingy on the form
        */




        /// <summary>
        /// a list of observers that update based on the form
        /// </summary>
        private Observer observer;

        /// <summary>
        /// the communicator which handles communication between the server and connected clients
        /// </summary>
        private Communicator communicator; 


        //methods

        /// <summary>
        /// default constructor with the observer
        /// </summary>
        public Controller(Observer o)
        {
            observer = o;
            communicator = new Communicator(this);
        }

        /// <summary>
        /// default constructor without the observer
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
            //make a random between 1,000,000 and max
            Random rand = new Random();
            int random = rand.Next(1000000, int.MaxValue);

            p.setTimer(random);

            //add the new product to the database
            Database.addProduct(p);

            //create a new message with all of the products
            BindingList<Product> products = Database.returnAllProducts();
            Message newMessage = new Message(MessageType.Product_List_Information, products.ToList());

            //send out the updated list if there are any connected clients
            if (Database.returnAllClients().Count > 0)
            {
                communicator.sendMessageToClients(newMessage);
            }//if

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
                    Bid newBid = message.getNewBid();
                    Product newProduct = newBid.getProduct();

                    //first, let's get the existing product from our database
                    Product existingProduct = Database.searchProduct(newProduct.getID());



                    //then we can update that product with our new bid
                    //existingProduct.setBid(newBid);
                    List<Bid> bidList = existingProduct.getBidList();

                    if (bidList != null)
                    {

                        foreach (Bid bid in bidList)
                        {
                            if (bid.getBidder().Equals(message.getClientID()))
                            {
                                bidList.Remove(bid);
                                bidList.Add(newBid);
                            }//if
                        }//foreach
                    }
                    else
                    {
                        bidList = new List<Bid>();
                        bidList.Add(newBid);
                    }

                    //swank, time to log that bid in the bid library
                    Database.addBid(newBid);


                    existingProduct.setBid(bidList);
                    

                    //now we need to create a message containing the new bid to send out to our clients.
                    //this is going to be basically the same as when we send the whole product list
                    BindingList<Product> products = Database.returnAllProducts();

                    newMessage = new Message(MessageType.Product_List_Information, products.ToList());



                    //alright, I need to update the bidtimers and such

                    //copying a lot of this out of an earlier lab, lets hope it flies
                   // SetMostCurrentTimer();

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
        public BindingList<Product> UpdateClientList(List<string> clientList)
        {


            //since there isn't a difference in the controller between how we handle losing a client or recieving a new one, I just say that we recieved a new one.
            observer.Update(State.Recieved_New_Client);


            //this is the return, that's easy
            BindingList <Product> products = Database.returnAllProducts();
            return products;
        }

        

        /// <summary>
        /// This checks all of the bids for a product and notifies the corresponding clients of their success or failure
        /// </summary>
        /// <param name="product"></param>
        public void TimesUp(Product product)
        {
            //throw new NotImplementedException();

            //still need to implament, but this is for when the admin decides that the time is up on the bidding for a specific item

            //this is only applicable if there are any bids to begin with
            //first we get the bidlist
            List<Bid> bidList = product.getBidList();
            
            if(bidList != null)
            {
                //then we grab the highest bid, that's the winner
                int count = bidList.Count;
                Bid highestBid = bidList.ElementAt(count - 1);
                //then we remove it, the remaining bids belong to the losers
                bidList.Remove(highestBid);

                //first, we'll send the winner their noti
                string clientID = highestBid.getBidder();
                Message message = new Message(MessageType.Win_Lose_Noti, true, clientID);

                communicator.sendMessageToClients(message);

                //next all of the LOSERS

                foreach (Bid b in bidList)
                {
                    string cID = b.getBidder();
                    Message mes = new Message(MessageType.Win_Lose_Noti, false, cID);
                    communicator.sendMessageToClients(mes);
                }//foreach
            }//if
            


        }//timesup




        //the timer stuff that lol don't actually need


        /*
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


            //now need to notify the clients

            //remove product and send updated list



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
            foreach (Product p in Database.returnAllProducts())
            {
                double timeSpanInMill = p.getTimer();
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

        */





    }//class
}//namespace
