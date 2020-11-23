using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidLibrary;
using BidLibrary.Library;
using System.Net.WebSockets;
using System.Net;
using System.Net.Sockets;


namespace Server.Controller
{
    /// <summary>
    /// handles communicating information to and from connected clients
    /// </summary>
    class Communicator 
    {
        //properties

        /// <summary>
        /// interface that allows the communicator to call the "readmessage" method from the controller  
        /// </summary>
        private ReadMessage readMessageHandler;


        //methods

        /// <summary>
        /// default constructor
        /// </summary>
        public Communicator()
        {

        }//communicator

        /// <summary>
        /// This method will use websockets to send all connected clients the updated list of products
        /// </summary>
        /// <param name="products"></param>
        public void sendToClients(List<Product> products)
        {
            //no idea how to do this yet
        }//sendToClients


        //public void OnMessage(MessageEventArgs messageEventArgs)
        //{
            //okay, so i need to somehow use a github library to make this work but i don't know how to do that. 
            //emailing either jorge or a TA
        //}


    }
}
