using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BidLibrary.Library;
using Client.Data;
using System.Net.WebSockets;
using System.Net;
using System.Net.Sockets;
using WebSocketSharp;
using Newtonsoft.Json;
using WebSocket = WebSocketSharp.WebSocket;
using Client.View;

namespace Client.Controller
{
    class Controller : UserVerifier, UpdateBid, SetNewObs
    {

        /// <summary>
        /// a list of observers that update based on the form
        /// </summary>
        private Observer observer;

        /// <summary>
        /// The websocket used to connect to server
        /// </summary>
        private WebSocket ws = new WebSocket("ws://10.130.48.166:8000/communicator");


        public event ServerMessage MessageRecieved;

        public delegate void ServerMessage(string message);

        /// <summary>
        /// The default controller constructor with uses the given observer form
        /// </summary>
        public Controller(Observer o)
        {
            ws.OnMessage += (sender, e) =>
            {
                MessageRecieved(e.Data);
            };

            MessageRecieved += ReadMessage;
            ws.Connect();
            if (ws.IsAlive)
            {
                Console.WriteLine("CONNECTED TO THE SERVER");
            }
            observer = o;
           
            

        }

        /// <summary>
        /// changes the form to the given observer
        /// </summary>
        public void SetNewObs(Observer x)
        {
            observer = x;
        }


        /// <summary>
        /// creates a message to be sent to the server to verify the given username and password
        /// </summary>
        public void VerifyUser(string username, string password)
        {
            Message newMessage = new Message(MessageType.Credential_Information, username, password);
            sendMessageToServer(newMessage);
            observer.Update(Client.State.loginPageWFR);


        }

        /// <summary>
        /// creates a message to be sent to the server to update a product with the given bid
        /// </summary>
        public void UpdateBid( Bid bid)
        {
            Message newMessage = new Message(MessageType.New_Bid, bid);
            sendMessageToServer(newMessage);
        }

        /// <summary>
        /// serializes a given message and sends it to the server
        /// </summary>
        public void sendMessageToServer(Message message)
        {
            var msg = JsonConvert.SerializeObject(message);
            
            if (ws.IsAlive) {
                ws.Send(msg); 
            }

        }

        /// <summary>
        /// reads the message from the server and reacts depending on the message type
        /// </summary>
        /// <param name="message">the message that is being read</param>
        public void ReadMessage(string msg)
        {
            Message message = JsonConvert.DeserializeObject<Message>(msg);

            Console.WriteLine(message.getMessageType());
            MessageType messageType = message.getMessageType();
            switch (messageType)
            {
                case MessageType.Credential_Information_Verification:
                    Console.WriteLine("reading credentials message");
                    bool v = message.getCredentialVerification();
                    if (v)
                    {
                        observer.Update(Client.State.loginPageTrue);
                    }
                    else
                    {
                        observer.Update(Client.State.loginPageFalse);
                    }
                    
                    break;
                case MessageType.Product_List_Information:
                    Console.WriteLine("reading product list message");
                    replaceCurrentList(message.getProducts());
                    observer.Update(Client.State.updating);
                    break;
                case MessageType.Win_Lose_Noti:
                    if (message.getWinLose())
                    {
                        observer.Update(Client.State.loginPageTrue);
                    }
                    else
                    {
                        observer.Update(Client.State.loginPageFalse);
                    }
                    
                    break;

                default:

                    //return null;
                    break;
            }

        }

        /// <summary>
        /// replaces the static proxy-database with an updated data list
        /// </summary>
        public void replaceCurrentList(BindingList<Product> newList)
        {
            DatabaseProxy.productList = newList;
            
        }

        
    }//class
}//namespace
