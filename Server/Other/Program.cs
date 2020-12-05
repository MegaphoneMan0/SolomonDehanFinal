using Server.Controller;
using Server.View;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WebSocketSharp.Server;
using WebSocketSharp;
using WebSocketSharp.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BidLibrary.Library;
using Server.Model;
using System.ComponentModel;

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

            //var cb = new ;

            

            IPAddress localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address;
            }
            string port = "8000";

            if (InputBox("Host Port", "Enter port number:", ref port) != DialogResult.OK)
            {
                return;
            }
            int portNum = Convert.ToInt32(port);


            //LoadInitialProducts();
            Database.productLibrary = new BindingList<Product>()
                {
                new Product("Cruzan Rum"),
                    new Product("Spiderman"),
                    new Product("Final project")
            };

            Controller.Controller c = new Controller.Controller();
            Communicator comm = new Communicator(c, c);
            c.SetClientHandler(comm);
            uxLoginForm lf = new uxLoginForm(String.Format("{0}:{1}", localIP, port),c,comm);
            
            
            //starting a webSocketServer at port 8000
            WebSocketServer wss = new WebSocketServer(8000);//localIP
            wss.AddWebSocketService("/communicator", () => {
                
                return comm;
            }
            );

            //start the server
            wss.Start();


            Application.Run(lf);

            

            
        }//main

        static public void LoadInitialProducts()
        {
            //this needs to load the products from a file into the database. How? WHO KNOWS
            //this is based of the example on the microsoft docs
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Products\InitialProducts.txt");

            foreach (string s in lines)
            {
                Product product = new Product(s);

                //make a random between 1,000,000 and max
                Random rand = new Random();
                int random = rand.Next(1000000, int.MaxValue);

                product.setTimer(random);
                Database.addProduct(product);
            }//foreach

        }



        // From http://www.csharp-examples.net/inputbox/
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

    }//program
}//server
