using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controller;
using WebSocketSharp;

namespace Client.View
{
    public partial class uxLoginForm : Form, Observer
    {
        private State formState;
        private UserVerifier userVerifier;
        private Bid501 bidForm;

        /// <summary>
        /// constructor
        /// </summary>
        public uxLoginForm(UserVerifier uv)
        {
            userVerifier = uv;
            InitializeComponent();
            Update(State.intialConnect);
        }
        public uxLoginForm(WebSocket ws)
        {
            InitializeComponent();
            bidForm = new Bid501();
            Controller.Controller c = new Controller.Controller(ws, this);
            
            userVerifier = c;
            Update(State.intialConnect);
        }


        public void Update(State state)
        {
            formState = state;
            if(formState == State.loginPageTrue)
            {
                
                this.Hide();
                bidForm.ShowDialog();
                this.Close();
            }
            else if(formState == State.loginPageFalse)
            {
                MessageBox.Show("Username-Password combination is incorrect. Please try again.");
                Update(State.intialConnect);
            }
            
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

            userVerifier.VerifyUser(userName, password);
            Update(State.loginPageWFR);
            /*
            if (verification)
            {
                Bid501 serverForm = new Bid501();
                this.Hide();
                serverForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username-Password combination is incorrect. Please try again.");
            }
            */
        }
    }
}
