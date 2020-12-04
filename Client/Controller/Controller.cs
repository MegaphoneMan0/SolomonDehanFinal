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
//using WebSocketSharp.Server;
using WebSocket = WebSocketSharp.WebSocket;
using Client.View;

namespace Client.Controller
{
    class Controller : UserVerifier, UpdateBid
    {

        /// <summary>
        /// a list of observers that update based on the form
        /// </summary>
        private Observer observer;
        private Observer observer2;

        //public event string MessageRecieved;

        private bool returned = false;
        private bool verified = false;
        //public System.Timers.Timer aTimer = new System.Timers.Timer();
        private WebSocket ws;

        public Controller(WebSocket socket, Observer o, Observer x)
        {
            observer = o;
            observer2 = x;
            ws = socket;
            ws.OnMessage += (sender, e) => ReadMessage(e.Data);
            

        }




        public void VerifyUser(string username, string password)
        {
            Message newMessage = new Message(MessageType.Credential_Information, username, password);
            sendMessageToServer(newMessage);
            observer.Update(Client.State.loginPageWFR);
            observer2.Update(Client.State.loginPageWFR);


        }
        

        public void UpdateBid( Bid bid)
        {
            Message newMessage = new Message(MessageType.New_Bid, bid);
            sendMessageToServer(newMessage);
        }

        public void sendMessageToServer(Message message)
        {
            //Console.WriteLine("password before serial: " + message.getPassword());
            var msg = JsonConvert.SerializeObject(message);
            // Message othertest = (Message)JsonConvert.DeserializeObject(msg);
            // Console.WriteLine("this is the deserialized password: " + othertest.getPassword());
            //double far = 2.14;
           //string msg = JsonConvert.SerializeObject(far);
            if (ws.IsAlive) {
                ws.Send(msg); 
            }
            
            Message test = JsonConvert.DeserializeObject<Message>(msg);
            //Console.WriteLine("this is the deserialized password: "+test.getPassword());
            // Sessions.Broadcast(msg);


        }

        /*

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("on message");
            string msg = e.Data;

            Message newMessage = JsonConvert.DeserializeObject<Message>(msg);

            ReadMessage(newMessage);

           


        }
        */
        /// <summary>
        /// reads the message from the client and reacts depending on the message type
        /// </summary>
        /// <param name="message">the message that is being read</param>
        /// <returns></returns>
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
                        observer2.Update(Client.State.loginPageTrue);
                    }
                    else
                    {
                        observer.Update(Client.State.loginPageFalse);
                        observer2.Update(Client.State.loginPageFalse);
                    }
                    returnedCredentials(v);
                    break;
                case MessageType.Product_List_Information:
                    Console.WriteLine("reading product list message");
                    replaceCurrentList(message.getProducts());
                    observer.Update(Client.State.updating);
                    observer2.Update(Client.State.updating);
                    break;


                default:

                    
                    //return null;
                    break;


            }

        }


        public void returnedCredentials(bool v)
        {
            verified = v;
        }



        public void replaceCurrentList(BindingList<Product> newList)
        {
            DatabaseProxy.productList = newList;
            
        }

        
    }//class
}//namespace
