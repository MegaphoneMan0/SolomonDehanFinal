using System;
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


        //methods

        public Message(MessageType mType, string name, string pass)
        {

        }

        public Message(MessageType mType, string name, string pass, bool verification)
        {

        }

        public Message(MessageType mType, List<Product> lProduct)
        {

        }

        public Message(MessageType mType, Product product, Bid bid)
        {

        }

        public MessageType getMessageType()
        {

        }

        public string getUserName()
        {

        }

        public string getPassword()
        {

        }

        public List<Product> getProducts()
        {

        }

        public Bid getNewBid()
        {

        }

        public bool getCredentialVerification()
        {

        }




    }
}
