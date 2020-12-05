using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidLibrary.Library
{
    
    public class Message
    {
        /// <summary>
        /// a MessageType to determine the type of the message
        /// </summary>
        [JsonProperty] private MessageType type;

        /// <summary>
        /// a username to be verified
        /// </summary>
        [JsonProperty] private string userName;

        /// <summary>
        /// a password to be verified
        /// </summary>
        [JsonProperty] private string password;

        /// <summary>
        /// a list of products available to update the clients' view
        /// </summary>
        [JsonProperty] private BindingList<Product> products;

        /// <summary>
        /// a valid bid to be added to the server
        /// </summary>
        [JsonProperty] private Bid newBid;

        /// <summary>
        /// a bool representing if the given credentials are valid
        /// </summary>
        [JsonProperty] private bool credentialVerification;

        /// <summary>
        /// this is for win lose noti. Client doesn't even need to worry about it, server is the only one that needs it
        /// </summary>
        [JsonProperty] private string clientID;

        /// <summary>
        /// a bool with true representing a win and false represeting a lose
        /// </summary>
        [JsonProperty] private bool winOrLose;


        //methods
        /// <summary>
        /// A default empty constructor
        /// </summary>
        public Message()
        {

        }


        /// <summary>
        /// Constructor for a message that communicates a user's given credentials
        /// </summary>
        public Message(MessageType mType, string name, string pass)
        {
            type = mType;
            userName = name;
            password = pass;
            products = null;
            newBid = null;
            credentialVerification = false;
        }

        /// <summary>
        /// Constructor for a message that communicates if the credentials are valid
        /// </summary>
        public Message(MessageType mType, string name, string pass, bool verification)
        {
            type = mType;
            userName = name;
            password = pass;
            products = null;
            newBid = null;
            credentialVerification = verification;
        }

        /// <summary>
        /// Constructor for a message that communicates if the client won or lost a bid
        /// </summary>
        public Message(MessageType mType, BindingList<Product> lProduct)
        {
            type = mType;
            userName = null;
            password = null;
            products = lProduct;
            newBid = null;
            credentialVerification = false;
        }

        /// <summary>
        /// Constructor for a message that communicates a client's valid bid
        /// </summary>
        public Message(MessageType mType, Bid bid)
        {
            type = mType;
            userName = null;
            password = null;

            newBid = bid;
            credentialVerification = false;
        }

        /// <summary>
        /// Constructor for a message that communicates if the client won or lost a bid
        /// </summary>
        public Message(MessageType mType, bool winLose,string cID)
        {
            type = mType;
            winOrLose = winLose;
            clientID = cID;

        }

        /// <summary>
        /// Returns the type of the message
        /// </summary>
        public MessageType getMessageType()
        {
            return type;
        }

        /// <summary>
        /// Returns the username of the message
        /// </summary>
        public string getUserName()
        {
            return userName;
        }

        /// <summary>
        /// Returns the password of the message
        /// </summary>
        public string getPassword()
        {
            return password;
        }

        /// <summary>
        /// Returns the BindingList of Products within the message
        /// </summary>
        public BindingList<Product> getProducts()
        {
            return products;
        }

        /// <summary>
        /// Returns the newBid of the message
        /// </summary>
        public Bid getNewBid()
        {
            return newBid;
        }

        /// <summary>
        /// Returns the credentialVerification of the message
        /// </summary>
        public bool getCredentialVerification()
        {
            return credentialVerification;
        }

        /// <summary>
        /// Returns the ClientID of the message
        /// </summary>
        public string getClientID()
        {
            return clientID;
        }

        /// <summary>
        /// Sets the ClientID to the given string
        /// </summary>
        public void setClientID(string ID)
        {
            clientID = ID;
        }

        /// <summary>
        /// THE BIG BOI CONSTRUCTOR
        /// </summary>
        [JsonConstructor] public Message(MessageType mType, string userN, string pass, BindingList<Product> productList, Bid bid, bool credV, string ID, bool winLose )
        {
            type = mType;
            userName = userN;
            password = pass;
            products = productList;
            newBid = bid;
            credentialVerification = credV;
            clientID = ID;
            winOrLose = winLose;
        }


    }
}
