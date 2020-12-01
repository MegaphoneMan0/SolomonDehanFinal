using Server.Controller;
using Server.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;

namespace Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller.Controller c = new Controller.Controller(new uxServerForm());


            IPAddress localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address;
            }
            string port = "8002";

            //if (InputBox(""))
            //{

            //}

            //starting a webSocketServer at port 8002
            var wss = new WebSocketServer(port);

            wss.AddWebSocketService<Communicator>("/communicator");

            //start the server
            wss.Start();


            Application.Run(new uxLoginForm(c, c));

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            // Stop the server
            wss.Stop();
        }//main
    }//program
}//server
