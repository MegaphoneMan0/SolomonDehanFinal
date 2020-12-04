using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidLibrary.Library
{
    
    public class Message
    {

        [JsonProperty] private MessageType type;

        [JsonProperty] private string userName;

        [JsonProperty] private string password;

        [JsonProperty] private List<Product> products;

        [JsonProperty] private Bid newBid;

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

        public Message()
        {

        }

        

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

        public Message(MessageType mType, bool winLose,string cID)
        {
            type = mType;
            winOrLose = winLose;
            clientID = cID;

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
            return products.ToList();
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

        /// <summary>
        /// THE BIG BOI CONSTRUCTOR
        /// </summary>
        [JsonConstructor] public Message(MessageType mType, string userN, string pass, List<Product> productList, Bid bid, bool credV, string ID, bool winLose )
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
