using Server.Controller;
using Server.View;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Application.Run(new uxLoginForm());

            //starting a webSocketServer at port 8001
            var wss = new WebSocketServer(8001);

            wss.AddWebSocketService<Communicator>("/communicator");

            //start the server
            wss.Start();

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            // Stop the server
            wss.Stop();
        }//main
    }//program
}//server
