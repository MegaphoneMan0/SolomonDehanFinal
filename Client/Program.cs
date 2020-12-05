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

            //using (WebSocket ws = new WebSocket("ws://10.130.48.166:8000/communicator"))
            // {
            /*
                 ws.Connect();
                 if (ws.IsAlive)
                 {
                     Console.WriteLine("CONNECTED TO THE SERVER");
                 }*/
            //Controller.Controller c = new Controller.Controller(ws);
            uxLoginForm form = new uxLoginForm();
            //Bid501 form = new Bid501();
                
                Controller.Controller c = new Controller.Controller( form);

            //c.setNewObs(bidForm);
            //form.setUB(c);
           
                form.setUV(c, c, c);
                Application.Run(form);
                //Controller.Controller c = new Controller.Controller(ws);
                //Application.Run(new uxLoginForm(c));
           // }
            
          /*
           * 
           * 
           * 
           * 
           */
            





        }
    }
}
