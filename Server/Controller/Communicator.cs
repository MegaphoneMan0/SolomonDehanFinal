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
using Newtonsoft.Json;
using Server.Model;
using Newtonsoft.Json.Serialization;

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

        /// <summary>
        /// interface that updates the client list whenever OnClose or OnOpen 
        /// </summary>
        private UpdateClientList updateClientListHandler;




        //methods

        /// <summary>
        /// default constructor
        /// </summary>
        public Communicator(ReadMessage RM, UpdateClientList UCL)
        {
            readMessageHandler = RM;
            updateClientListHandler = UCL;
        }//communicator


       
        /// <summary>
        /// This method will use websockets to send a message to one or all clients
        /// </summary>
        /// <param name="message">The message that needs to be sent</param>
        public void sendMessageToClients(Message message)
        {
            //ALRIGHT
            //WE NEED TO REFACTOR THIS TO BE ABLE TO SEND TO CERTAIN CLIENTS IF MESSAGETYPE IS WIN_LOSE_NOTI

            if (message.getMessageType() == MessageType.Win_Lose_Noti)
            {
                string cID = message.getClientID();
                string msg = JsonConvert.SerializeObject(message);
                Sessions.SendTo(cID,msg);
            }//if

            else
            {
                //this is if it needs to be sent to all, cool, who cares
                string msg = JsonConvert.SerializeObject(message);
                Sessions.Broadcast(msg);
            }//else
                
        }//sendToClients

       
        //THIS MAY CAUSE ISSUES, IDK HOW TO DO THE OVERRIDE THINGY SO IT'S GREEN UNDERLINED IDK MAN

        /// <summary>
        /// This method is run whenever the communicator recieves a message from a client
        /// </summary>
        /// <param name="e">e.Data is the serialized string from the client</param>
        protected override void OnMessage(MessageEventArgs e)
        {
            //alright, fun fact, there doesn't seem to be any way of singleing out a certian client except in here or in one of the other On_____ methods
            //cool
            //so we need to refactor sendMessageToClients to just return the serialized string. Not what I wanted but it'll work
            //actually, I think that isn't even needed anymore.
            //I'll just have read message return the string, or null if it doesn't need it
            //sendmessage can go back to being the session.broacast bit that it was before

            Client thisClient = Database.searchClient(ID);

            //e.RawData.ToString();

            string msg = e.Data;


            

            

            double newMessage = JsonConvert.DeserializeObject<double>(msg);

            //Console.WriteLine(newMessage.getUserName());
            /*
            Message returnMessage = readMessageHandler.ReadMessage(newMessage);

            

            //if the return message is not null then we need to send the reply
            if(returnMessage != null)
            {
                //re-serializing
                
                string reply = JsonConvert.SerializeObject(returnMessage);

                //checking if it is a newBid to be communicated to all, or just a client verification
                if (returnMessage.getMessageType() == MessageType.Product_List_Information)
                {
                    Sessions.Broadcast(reply);
                }//if
                else if(returnMessage.getMessageType() == MessageType.Credential_Information_Verification)
                {
                    Send(reply);

                }//else if
                else
                {
                    //uncertain if anything needs to go here, leaving it for now
                }//else        
                
            }//if
            else
            {
                //we do nothing!
            }//else

            */
        }//OnMessage
        
        /// <summary>
        /// This method is run when a connection from a client is opened
        /// </summary>
        /// <param name="e">event arguments from the client</param>
        protected override void OnOpen()
        {
            //first, we need to update the list of sessions

            //Client newClient = new Client(clientID);
            //ID is the websocket-sharp generated ID
            Database.addClient(ID);

            Console.WriteLine("SOMEONE CONNECTED");
            

            //get a list of session IDs
            List<string> sessionList = Sessions.ActiveIDs.ToList();

            List<Product> updatedProducts = updateClientListHandler.UpdateClientList(sessionList);

            //now, we need to send the client the product list in the database. This is done with the return of updateClientList
            //first, we serialize

            Message message = new Message(MessageType.Product_List_Information,updatedProducts);

            string msg = JsonConvert.SerializeObject(message);

            Send(msg);

        }//OnClose

        /// <summary>
        /// This method is run when a connection from a client is closed
        /// </summary>
        /// <param name="e">event arguments from the client</param>
        public void OnClose(MessageEventArgs e)
        {

            Database.removeClient(ID);

            //get a list of session IDs
            List<IWebSocketSession> sessionList = Sessions.Sessions.ToList();

            //turn them into strings for the controller
            List<string> vs = new List<string>();
            foreach (IWebSocketSession i in sessionList)
            {
                vs.Add(i.ID);
            }//foreach

            updateClientListHandler.UpdateClientList(vs);

            //in this case we can ignore the return of UpdateClientList

        }//OnClose








    }
}
