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
using WebSocketSharp.Server;

namespace Client.Controller
{
    class Controller : WebSocketBehavior, UserVerifier
    {

        //public System.Timers.Timer aTimer = new System.Timers.Timer();






        public bool VerifyUser(string username, string password)
        {
            Message newMessage = new Message(MessageType.Credential_Information, username, password);
            sendMessageToServer(newMessage);
            
            return true;
        }
        

        public void UpdateBid( Bid bid)
        {
            Message newMessage = new Message(MessageType.New_Bid, bid);
            sendMessageToServer(newMessage);
        }

        public void sendMessageToServer(Message message)
        {

            string msg = JsonConvert.SerializeObject(message);
            Sessions.Broadcast(msg);


        }

        public void OnMessage(MessageEventArgs e)
        {
            
            string msg = e.Data;

            Message newMessage = JsonConvert.DeserializeObject<Message>(msg);

            ReadMessage(newMessage);

           


        }

        /// <summary>
        /// reads the message from the client and reacts depending on the message type
        /// </summary>
        /// <param name="message">the message that is being read</param>
        /// <returns></returns>
        public void ReadMessage(Message message)
        {

            MessageType messageType = message.getMessageType();


            switch (messageType)
            {
                case MessageType.Credential_Information_Verification:
                    
                    bool v = message.getCredentialVerification();
                    returnedCredentials(v);
                    break;
                case MessageType.Product_List_Information:

                    replaceCurrentList(message.getProducts());
                    break;


                default:

                    
                    //return null;
                    break;


            }

        }


        public void returnedCredentials(bool v)
        {

        }



        public void replaceCurrentList(List<Product> newList)
        {
            Data.DatabaseProxy.productList = newList;
            
        }




    }//class
}//namespace
