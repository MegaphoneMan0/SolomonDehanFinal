using Server.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;

namespace Server.View
{
    public partial class uxLoginForm : Form
    {
        /// <summary>
        /// the interface from the controller
        /// </summary>
        private UserVerifier userVerifier;

        private LoadInitialProducts initialProductsLoader;

        private uxServerForm uxServer;

        /// <summary>
        /// constructor
        /// </summary>
        public uxLoginForm(UserVerifier uv, LoadInitialProducts LIP)
        {
            InitializeComponent();

            userVerifier = uv;
            initialProductsLoader = LIP;
            initialProductsLoader.LoadInitialProducts();

        }

        /// <summary>
        /// constructor with IP given
        /// </summary>
        //public uxLoginForm(string s,Controller.Controller controller, Communicator comm) 
        public uxLoginForm(string s, TimesUp timesUp, SendMessageToClients smtc)
        {
            InitializeComponent();
            uxServer = new uxServerForm(timesUp,smtc);
            Controller.Controller c = new Controller.Controller(uxServer, smtc);
            userVerifier = c;
            
            Text = s;
            //uxServer = usf;


            //I THINK this will work
            //starting a webSocketServer at port 8000
            WebSocketServer wss = new WebSocketServer(8000);//localIP
            wss.AddWebSocketService("/communicator", () => {
                Communicator server = new Communicator(c,c);
                return server;
            }
            );


            //start the server
            wss.Start();
        }

        /// <summary>
        /// an event handler for when a user clicks the login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoginButton_Click(object sender, EventArgs e)
        {

            string userName = uxUsernameBox.Text;
            string password = uxPasswordBox.Text;

            bool verification = userVerifier.VerifyUser(userName, password);

            if (verification)
            {
                
                this.Hide();

                uxServer.ShowDialog();

                //serverForm.ShowDialog(); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Username-Password combination is incorrect. Please try again.");
            }

        }
    }
}
