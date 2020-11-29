using Server.Model;
using Server.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Server
{
    public partial class uxServerForm : Form, Observer
    {

        private State formState;

        public uxServerForm()
        {
            formState = State.Monitoring;
            InitializeComponent();
        }//constructor

        private void uxAddButton_Click(object sender, EventArgs e)
        {
            formState = State.Adding_A_Product;
            Application.Run(new uxAddProductForm());
        }//button click

        /// <summary>
        /// this is called once a product has been added to the database
        /// </summary>
        public void addProduct()
        {
            formState = State.Monitoring;
        }//addProduct

        public void Update(State state)
        {
            formState = state;
            if(formState == State.Adding_A_Product)
            {
                uxProductListBox.DataSource = Database.returnAllProducts();
            }//if
            else if(formState == State.Recieved_New_Client | formState == State.Lost_Client)
            {
                uxClientListBox.DataSource = Database.returnAllClients();
            }//else if
            else
            {

            }//else
        }

    }
}
