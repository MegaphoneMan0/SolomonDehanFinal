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

            
           // uxLoginForm form = new uxLoginForm();     //TO TEST LOGIN
            Bid501 form = new Bid501();   //TO TEST BID501
                
                Controller.Controller c = new Controller.Controller( form);

           
            form.setUB(c);            //TO TEST BID501
           
               // form.setUV(c, c, c);    //TO TEST LOGIN
                Application.Run(form);
          
            
          
            





        }
    }
}
