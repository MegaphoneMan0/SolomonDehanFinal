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
    class Controller : WebSocketBehavior
    {

        public System.Timers.Timer aTimer = new System.Timers.Timer();



        /// <summary>
        /// Data object which holds the products list
        /// </summary>
        public DatabaseProxy list { get; set; }




        public bool VerifyUser(string username, string password)
        {
            Message newMessage = new Message(MessageType.Credential_Information, username, password);
            sendMessageToServer(newMessage);
            
            return true;
        }
        

        public void UpdateBid(Product product, Bid bid)
        {
            Message newMessage = new Message(MessageType.New_Bid, product, bid);
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
            DatabaseProxy newData = new DatabaseProxy();
            newData.productList = newList;
            list = newData;
            /*
            for(int i = 0; i < newList.Count; i++)
            {
                list.productList[i] = newList[i];
            }
            */
        }



        /*
        /// <summary>
        /// This will set the active timer, which will trigger OnTimedEvent. OnTimedEvent should also set the next timer
        /// </summary>
        /// <param name="amountOfTime">the amount of time till the bid is up in milliseconds</param>
        private void SetTimer(int amountOfTime)
        {

            aTimer = new System.Timers.Timer(amountOfTime);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        /// <summary>
        /// this event is tripped whenever aTimer goes off
        /// </summary>
        /// <param name="source">who knows</param>
        /// <param name="e">*shrug*</param>
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            //the timer's up, let's do this
            Console.WriteLine("One of the bid timers is up");

            SetMostCurrentTimer();


        }//onTimedEvent

        /// <summary>
        /// This is just because I had to use this exact same giant block of code twice. Looks cleaner this way.
        /// All it does is set a "nextTimer" to the highest possible value, then checks which timer in all of the bids is the lowest.
        /// This method is called whenever a new bid is added or whenever the current timer goes off. 
        /// </summary>
        private void SetMostCurrentTimer()
        {
            int nextTimer = 2147483500;
            bool nothing = false;//if this bool is still false by the end, it means there was nothing and we need to just get rid of the timer

            //determine the next timer
            foreach (Bid b in Database.getAllBids())
            {
                double timeSpanInMill = b.getTimer();
                int intTimeSpan = Convert.ToInt32(timeSpanInMill);

                if ((intTimeSpan < nextTimer) & (intTimeSpan > 0))
                {
                    nextTimer = intTimeSpan;
                    nothing = true;
                }//if

            }//foreach

            if (nothing)
            {
                aTimer.Dispose();

                SetTimer(nextTimer);
            }//if
            else
            {
                aTimer.Dispose();

            }//else
        }


    */


    }//class
}//namespace
