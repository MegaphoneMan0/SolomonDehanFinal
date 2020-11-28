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
using WebSocketSharp;
using WebSocketSharp.Server;


namespace Server.Controller 
{
    /// <summary>
    /// handles communicating information to and from connected clients
    /// </summary>
    class Communicator : WebSocketBehavior
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
        /// This method will use websockets to send a message to one or all clients
        /// </summary>
        /// <param name="message">The message that needs to be sent</param>
        public void sendMessageToClients(Message message)
        {

            string msg = "";
            //need to make a message with the list of products and all that fun jazz
            //then serialize the message with JSON

            Sessions.Broadcast(msg);
        
                
        }//sendToClients

        
        public void 

        /// <summary>
        /// This method is run whenever the communicator recieves a message from a client
        /// </summary>
        /// <param name="e">e.Data is the serialized string from the client</param>
        public void OnMessage(MessageEventArgs e)
        {

            string msg = e.Data;

            //then convert the string to a "message" type. Message isn't done yet, I'll do this later

        }//OnMessage
        
        /// <summary>
        /// This method is run when a connection from a client is opened
        /// </summary>
        /// <param name="e">event arguments from the client</param>
        public void OnOpen(MessageEventArgs e)
        {

            //needs to be done after I get read message and controller done

        }//OnClose

        /// <summary>
        /// This method is run when a connection from a client is closed
        /// </summary>
        /// <param name="e">event arguments from the client</param>
        public void OnClose(MessageEventArgs e)
        {

            //needs to be done after I get read message and controller done

        }//OnClose








    }
}
