using BidLibrary.Library;
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

        private TimesUp TimesUpHandler;

        private BindingList<Product> products = Database.returnAllProducts();

        private BindingList<Client> clients = Database.returnAllClients();


        /// <summary>
        /// default constructor
        /// </summary>
        public uxServerForm()
        {
            InitializeComponent();
            uxClientListBox.DataSource = clients;
            uxProductListBox.DataSource = products;
        }

        /// <summary>
        /// Constructor that takes a TimesUp interface
        /// </summary>
        /// <param name="timesUp"></param>
        public uxServerForm(TimesUp timesUp)
        {
            InitializeComponent();
            TimesUpHandler = timesUp;
            uxProductListBox.DataSource = products;
            uxClientListBox.DataSource = clients;
        }//constructor

        /// <summary>
        /// handler for when the add button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddButton_Click(object sender, EventArgs e)
        {
            formState = State.Adding_A_Product;
            uxAddProductForm productForm = new uxAddProductForm(new Controller.Controller(this));
            productForm.ShowDialog();

        }//button click

        /// <summary>
        /// This is the method contained within the Observer interface. It performs certain actions depending on the state that it is passed
        /// </summary>
        /// <param name="state"></param>
        public void Update(State state)
        {
            formState = state;
            if(formState == State.Adding_A_Product)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() => products.ResetBindings()
                    ));
                }
            }//if
            else if(formState == State.Recieved_New_Client | formState == State.Lost_Client)
            {

                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() => clients.ResetBindings()
                    ));
                }

                

            }//else if
            else
            {
                
            }//else
        }

        /// <summary>
        /// this does nothing, but I'm keeping it in case I need it
        /// </summary>
        private void refresh()
        {
            uxClientListBox.DataSource = Database.clientLibrary;
        }

        /// <summary>
        /// this is the button push method to stop bidding. It uses an interface to contact the controller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStopBidding_Click(object sender, EventArgs e)
        {
            Product product = Database.searchProduct(uxProductListBox.SelectedItem.ToString());
            product.setTimer(0);
            TimesUpHandler.TimesUp(product);
        }
    }
}
