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

            formState = State.Monitoring;

            
            
            uxClientListBox.DataSource = clients;




            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Products\InitialProducts.txt");

            List<string> productList = new List<string>();
            foreach (string s in lines)
            {
                productList.Add(s);
            }//foreach

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

            formState = State.Monitoring;

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Products\InitialProducts.txt");

            List<string> productList = new List<string>();
            foreach (string s in lines)
            {
                productList.Add(s);
            }//foreach

            
            uxProductListBox.DataSource = productList;




            BindingList<Client> clients = Database.returnAllClients();
            //clients.ListChanged += Clients_ListChanged;
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

            uxAddProductForm productFrom = new uxAddProductForm(new Controller.Controller(this));
            productFrom.ShowDialog();

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
                BindingList<Product> products = Database.returnAllProducts();
                List<string> productNames = new List<string>();
                foreach (Product p in products)
                {
                    productNames.Add(p.getID());
                }
                uxProductListBox.DataSource = productNames;
            }//if
            else if(formState == State.Recieved_New_Client | formState == State.Lost_Client)
            {

                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    ))
                }

                //this.Invoke(new Action(() =>
                //{ refresh(); }));

            }//else if
            else
            {
                //we'll do both, why not
                /*
                BindingList<Product> products = Database.returnAllProducts();
                List<string> productNames = new List<string>();
                foreach (Product p in products)
                {
                    productNames.Add(p.getID());
                }
                uxProductListBox = new ListBox();
                uxProductListBox.DataSource = productNames;

                BindingList<Client> clients = Database.returnAllClients();
                List<string> clientNames = new List<string>();
                foreach (Client c in clients)
                {
                    clientNames.Add(c.getID());
                }
                uxClientListBox = new ListBox();
                uxClientListBox.DataSource = clientNames;

                */
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
