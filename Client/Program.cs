using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using Client.View;
using Client.Controller;

namespace Client
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
            Controller.Controller c = new Controller.Controller();
            Application.Run(new uxLoginForm(c));

            
            string ip = "192.168.184.128", port = "8000";
            using (WebSocket ws = new WebSocket("ws://192.168.184.128:8000/communicator"))
            {
                ws.Connect();
            }


                

        }
    }
}
