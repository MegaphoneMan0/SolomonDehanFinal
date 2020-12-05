﻿using System;
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
        private UpdateBid uBid;
        private SetNewObs setObs;
        //private UpdateBid bidForm;

        /// <summary>
        /// constructor
        /// </summary>
        public uxLoginForm(UserVerifier uv,  UpdateBid ub)
        {
            userVerifier = uv;
            uBid = ub;
            InitializeComponent();
            Update(State.intialConnect);
        }
        public uxLoginForm()
        {
            InitializeComponent();
            

            
            Update(State.intialConnect);
        }

       public void setUV(UserVerifier uv, UpdateBid ub, SetNewObs sno)
        {
            //bidForm = bf;
            userVerifier = uv;
            uBid = ub;
            setObs = sno;
        }


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
