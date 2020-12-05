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
using System.ComponentModel;

namespace Server.Controller 
{
    /// <summary>
    /// handles communicating information to and from connected clients
    /// </summary>
    public class Communicator : WebSocketBehavior, SendMessageToClients
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




        public Communicator(ReadMessage readMessage, UpdateClientList update)
        {
            readMessageHandler = readMessage;
            updateClientListHandler = update;
        }


        /// <summary>
        /// This method will use websockets to send a message to one or all clients
        /// </summary>
        /// <param name="message">The message that needs to be sent</param>
        public void sendMessageToClients(Message message)
        {
            //ALRIGHT
            //WE NEED TO REFACTOR THIS TO BE ABLE TO SEND TO CERTAIN CLIENTS IF MESSAGETYPE IS WIN_LOSE_NOTI

            string reply = JsonConvert.SerializeObject(message);

            Action<bool> action;
            action = ShowSendResult;

            Console.WriteLine(ID);
            Console.WriteLine(message.getMessageType());
            SendAsync(reply, action);

            //CheckForDisconnects();
        }//sendToClients

        /// <summary>
        /// This method is run whenever the communicator recieves a message from a client
        /// </summary>
        /// <param name="e">e.Data is the serialized string from the client</param>
        protected override void OnMessage(MessageEventArgs e)
        {

            Client thisClient = Database.searchClient(ID);
            Console.WriteLine(ID);
            //e.RawData.ToString();

            string msg = e.Data;

            Message newMessage = JsonConvert.DeserializeObject<Message>(msg);

            readMessageHandler.ReadMessage(newMessage, this);

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



            BindingList<Product> updatedProducts = updateClientListHandler.UpdateClientList(sessionList);

            //now, we need to send the client the product list in the database. This is done with the return of updateClientList
            //first, we serialize

            Message message = new Message(MessageType.Product_List_Information, updatedProducts);

            string msg = JsonConvert.SerializeObject(message, Formatting.Indented);

            Action<bool> action;
            action = ShowSendResult;

            
            SendAsync(msg, action);

            //CheckForDisconnects();




        }//OnClose


        private void ShowSendResult(bool b)
        {
            Console.WriteLine(b);
        }



        

        /// <summary>
        /// This method is run when a connection from a client is closed
        /// </summary>
        /// <param name="e">event arguments from the client</param>
        protected override void OnClose(CloseEventArgs e)
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
