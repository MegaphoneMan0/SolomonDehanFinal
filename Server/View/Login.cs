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

        private uxServerForm uxServer;

        /// <summary>
        /// constructor
        /// </summary>
        public uxLoginForm(UserVerifier uv, LoadInitialProducts LIP)
        {
            userVerifier = uv;
            initialProductsLoader = LIP;
            initialProductsLoader.LoadInitialProducts();
            InitializeComponent();

        }

        /// <summary>
        /// constructor with IP given
        /// </summary>
        public uxLoginForm(UserVerifier uv, LoadInitialProducts LIP, string s, uxServerForm usf)
        {
            userVerifier = uv;
            initialProductsLoader = LIP;
            initialProductsLoader.LoadInitialProducts();
            Text = s;
            uxServer = usf;
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
                //uxServerForm serverForm = new uxServerForm(new Controller.Controller(new uxServerForm()));
                

                this.Hide();
                uxServer.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username-Password combination is incorrect. Please try again.");
            }

        }
    }
}
