using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using Client.View;
using Client.Controller;
using Newtonsoft.Json;

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
            /*
            using(var ws = new WebSocket("ws://192.168.184.128:8000/"))
            {
                ws.OnMessage += async (sender, e) =>
                {

                    await Task.FromResult<object>(null);
                    Console.WriteLine(e.Data);
                };

                ws.Connect();
                ws.Send("This is a test message");
                Controller.Controller c = new Controller.Controller(ws);
                Application.Run(new uxLoginForm(c));
            }
            */
            //ws://192.168.184.128:8000/
            
            string ip = "192.168.184.128", port = "800";
            using (WebSocket ws = new WebSocket("ws://10.130.48.21:8000/communicator"))
            {
                Uri s = ws.Url;
                Console.WriteLine("current URL we are trying  " + s.ToString());
                // var exampleSocket = new WebSocket("wss://192.168.184.128:8000/communicator");
                if (ws.IsAlive)
                {
                    Console.WriteLine("CONNECTED TO THE SERVER");
                }
                ws.Connect();
                Controller.Controller c = new Controller.Controller(ws);
                Application.Run(new uxLoginForm(c));
            }
            





        }
    }
}
