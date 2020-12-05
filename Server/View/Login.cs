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

        private uxServerForm uxServer;

        

        /// <summary>
        /// constructor with IP given
        /// </summary>
        //public uxLoginForm(string s,Controller.Controller controller, Communicator comm) 
        public uxLoginForm(string s, Controller.Controller timesUp, SendMessageToClients smtc)
        {
            InitializeComponent();
            uxServer = new uxServerForm(timesUp,smtc);
            timesUp.SetObs(uxServer);
            userVerifier = timesUp;
            Text = s;


            //initialProductsLoader.LoadInitialProducts();

            
        }//login constructor

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
                this.Close();
            }//if
            else
            {
                MessageBox.Show("Username-Password combination is incorrect. Please try again.");
            }//else

        }//login button clicked
    }//class
}//namespace
