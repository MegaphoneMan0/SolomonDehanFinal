﻿using BidLibrary.Library;
using Server.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    /// <summary>
    /// An object that represents the clients connected to the server
    /// </summary>
    class Client 
    {
        //parameters

        /// <summary>
        /// The ID of the client, generated by server
        /// </summary>
        private string clientID;

        /// <summary>
        /// A list of Products that the client currently has a Bid on
        /// </summary>
        private List<Product> currentBids;


        //methods

        /// <summary>
        /// default constructor
        /// </summary>
        public Client()
        {

        }//Client

        /// <summary>
        /// constructor that sets the clientID
        /// </summary>
        /// <param name="ID">the identifying ID</param>
        public Client(string ID)
        {
            clientID = ID;
        }//Client
        
        /// <summary>
        /// getter for ClientID
        /// </summary>
        /// <returns>the clientID as a string</returns>
        public string getID()
        {
            return clientID;
        }//getID

        /// <summary>
        /// setter for ClientID
        /// </summary>
        /// <param name="id">whatever the ID should be</param>
        public void setID(string id)
        {
            clientID = id;
        }//setID

        /// <summary>
        /// This returns all of the products that this client has a bid on
        /// </summary>
        /// <returns></returns>
        public List<Product> getAllBids()
        {
            return currentBids;
        }
        
        /// <summary>
        /// This sets the currentBids to the provided list
        /// </summary>
        /// <param name="products"></param>
        public void setAllBids(List<Product> products)
        {
            currentBids = products;
        }


        public override string ToString()
        {
            return clientID;
        }



    }
}
