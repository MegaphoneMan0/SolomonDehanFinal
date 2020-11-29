using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.View
{
    public partial class uxLoginForm : Form
    {
        /// <summary>
        /// the interface from the controller
        /// </summary>
        private UserVerifier userVerifier;

        private LoadInitialProducts initialProductsLoader;

        /// <summary>
        /// constructor
        /// </summary>
        public uxLoginForm()
        {
            InitializeComponent();
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
                initialProductsLoader.LoadInitialProducts();
                Application.Run(new uxServerForm());
                
            }
            else
            {
                MessageBox.Show("Username-Password combination is incorrect. Please try again.");
            }

        }
    }
}
