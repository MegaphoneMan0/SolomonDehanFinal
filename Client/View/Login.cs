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

namespace Client.View
{
    public partial class uxLoginForm : Form, UserVerifier
    {
        /// <summary>
        /// the interface from the controller
        /// </summary>
        private UserVerifier userVerifier;

        /// <summary>
        /// constructor
        /// </summary>
        public uxLoginForm(UserVerifier uv)
        {
            userVerifier = uv;
            InitializeComponent();

        }

        public bool VerifyUser(string username, string password)
        {
            return userVerifier.VerifyUser(username, password);
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
                Bid501 serverForm = new Bid501();
                this.Hide();
                serverForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username-Password combination is incorrect. Please try again.");
            }

        }
    }
}
