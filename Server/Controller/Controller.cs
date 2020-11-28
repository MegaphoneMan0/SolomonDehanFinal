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
        public void ReadMessage(Message message)
        {
            //reads a message and reacts appropriatly 
        }//ReadMessage



    }//class
}//namespace
