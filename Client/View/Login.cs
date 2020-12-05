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
        /// <summary>
        /// a variable to keep track of the state of the controller
        /// </summary>
        private State formState;
        /// <summary>
        /// a variable to keep track of the UserVerifier object
        /// </summary>
        private UserVerifier userVerifier;
        /// <summary>
        /// a variable to keep track of the UpdateBid object
        /// </summary>
        private UpdateBid uBid;
        /// <summary>
        /// a variable to keep track of the SetNewObs object
        /// </summary>
        private SetNewObs setObs;

        /// <summary>
        /// constructor when given 2 differnet objects to initialize the local variables with
        /// </summary>
        public uxLoginForm(UserVerifier uv,  UpdateBid ub)
        {
            userVerifier = uv;
            uBid = ub;
            InitializeComponent();
            Update(State.intialConnect);
        }

        /// <summary>
        /// A default empty constructor
        /// </summary>
        public uxLoginForm()
        {
            InitializeComponent();
            Update(State.intialConnect);
        }
        /// <summary>
        /// sets the local variables to the given variables for future use
        /// </summary>
        public void setUV(UserVerifier uv, UpdateBid ub, SetNewObs sno)
        {
            userVerifier = uv;
            uBid = ub;
            setObs = sno;
        }

        /// <summary>
        /// Updates the local state to the given state and changes the form accordingly
        /// </summary>
        public void Update(State state)
        {
            formState = state;
            if(formState == State.loginPageTrue)
            {
                Console.WriteLine("LOGIN SUCCESS");
                this.Invoke(new Action(() =>
                {
                    Bid501 bidForm = new Bid501();
                    bidForm.setUB(uBid);
                    setObs.SetNewObs(bidForm);
                    this.Hide();
                    bidForm.Update(State.updating);
                    bidForm.ShowDialog();
                    
                    //this.Close();
                }));

            }
            else if(formState == State.loginPageFalse)
            {
                Console.WriteLine("LOGIN FAIL");
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
         
        }
    }
}
