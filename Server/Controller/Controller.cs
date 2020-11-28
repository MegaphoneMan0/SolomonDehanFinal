using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidLibrary.Library;
using Server.Model;
using Server.View;


namespace Server.Controller
{
    class Controller : ReadMessage
    {
        /// <summary>
        /// a database of users and clients
        /// </summary>
        private Database database;

        /// <summary>
        /// a list of observers that update based on the form
        /// </summary>
        private List<Observer> observers;

        /// <summary>
        /// the communicator which handles communication between the server and connected clients
        /// </summary>
        private Communicator communicator;

        /// <summary>
        /// Adds a product to the database
        /// </summary>
        /// <param name="p"></param>
        public void UpdateProduct(Product p)
        {
            database.addProduct(p);
        }//UpdateProduct

        /// <summary>
        /// Verify's the user's login credentials
        /// </summary>
        /// <param name="username">the username of the user</param>
        /// <param name="password">the password of the user</param>
        /// <returns>returns true of the username and password matched. Returns false if they did not</returns>
        public bool VerifyUser(string username,string password)
        {
            User user = database.searchUser(username);

            if(user == null)
            {
                return false;
            }//if
            else
            {
                if (user.getPassword().Equals(password))
                {
                    return true;
                }//if
                else
                {
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
                    Product existingProduct = database.searchProduct(newProduct.getID());

                    //then we can update that product with our new bid
                    existingProduct.setBid(newBid);

                    //swank, time to log that bid in the bid library
                    database.addBid(newBid);
                    return null;
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

            //NOOOO fucking clue how to do update the form



            //this is the return, that's easy
            List<Product> products = database.returnAllProducts();
            return products;
        }


    }//class
}//namespace
