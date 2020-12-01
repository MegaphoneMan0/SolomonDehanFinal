﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidLibrary.Library
{
    
    public class Message
    {
        
        private MessageType type;

        private string userName;

        private string password;

        private List<Product> products;

        private Bid newBid;

        private bool credentialVerification;

        /// <summary>
        /// this is for win lose noti. Client doesn't even need to worry about it, server is the only one that needs it
        /// </summary>
        private string clientID;


        //methods

        public Message(MessageType mType, string name, string pass)
        {
            type = mType;
            userName = name;
            password = pass;
            products = null;
            newBid = null;
            credentialVerification = false;
        }

        public Message(MessageType mType, string name, string pass, bool verification)
        {
            type = mType;
            userName = name;
            password = pass;
            products = null;
            newBid = null;
            credentialVerification = verification;
        }

        public Message(MessageType mType, List<Product> lProduct)
        {
            type = mType;
            userName = null;
            password = null;
            products = lProduct;
            newBid = null;
            credentialVerification = false;
        }

        public Message(MessageType mType, Bid bid)
        {
            type = mType;
            userName = null;
            password = null;

            newBid = bid;
            credentialVerification = false;
        }

        public MessageType getMessageType()
        {
            return type;
        }

        public string getUserName()
        {
            return userName;
        }

        public string getPassword()
        {
            return password;
        }

        public List<Product> getProducts()
        {
            return products;
        }

        public Bid getNewBid()
        {
            return newBid;
        }

        public bool getCredentialVerification()
        {
            return credentialVerification;
        }

        public string getClientID()
        {
            return clientID;
        }

        public void setClientID(string ID)
        {
            clientID = ID;
        }


    }
}
