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

        //default constructor
        public uxServerForm()
        {
            //uxClientListBox = new ListBox();
            InitializeComponent();

            formState = State.Monitoring;
            
            List<Product> products = Database.returnAllProducts();
            List<string> productNames = new List<string>();
            foreach (Product p in products)
            {
                productNames.Add(p.getID());
            }
            uxProductListBox.DataSource = productNames;

            List<Client> clients = Database.returnAllClients();
            List<string> clientNames = new List<string>();
            foreach (Client c in clients)
            {
                clientNames.Add(c.getID());
            }
            uxClientListBox.DataSource = clientNames;




            //


            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Products\InitialProducts.txt");

            List<string> productList = new List<string>();
            foreach (string s in lines)
            {
                productList.Add(s);
            }//foreach

            uxProductListBox.DataSource = productList;

        }

        public uxServerForm(TimesUp timesUp)
        {

            TimesUpHandler = timesUp;

            formState = State.Monitoring;
            List<Product> products = Database.returnAllProducts();
            List<string> productNames = new List<string>();
            foreach(Product p in products)
            {
                productNames.Add(p.getID());
            }
            uxProductListBox.DataSource = productNames;

            List<Client> clients = Database.returnAllClients();
            List<string> clientNames = new List<string>();
            foreach (Client c in clients)
            {
                clientNames.Add(c.getID());
            }
            uxClientListBox.DataSource = clientNames;

            InitializeComponent();


        }//constructor

        private void uxAddButton_Click(object sender, EventArgs e)
        {
            formState = State.Adding_A_Product;

            uxAddProductForm productFrom = new uxAddProductForm(new Controller.Controller(this));
            productFrom.ShowDialog();

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
                List<Product> products = Database.returnAllProducts();
                List<string> productNames = new List<string>();
                foreach (Product p in products)
                {
                    productNames.Add(p.getID());
                }
                uxProductListBox.DataSource = productNames;
            }//if
            else if(formState == State.Recieved_New_Client | formState == State.Lost_Client)
            {
                List<Client> clients = Database.returnAllClients();
                List<string> clientNames = new List<string>();
                foreach (Client c in clients)
                {
                    clientNames.Add(c.getID());
                }
                uxClientListBox = new ListBox();
                uxClientListBox.DataSource = clientNames;
                //this.Show();
            }//else if
            else
            {
                //we'll do both, why not

                List<Product> products = Database.returnAllProducts();
                List<string> productNames = new List<string>();
                foreach (Product p in products)
                {
                    productNames.Add(p.getID());
                }
                uxProductListBox = new ListBox();
                uxProductListBox.DataSource = productNames;

                List<Client> clients = Database.returnAllClients();
                List<string> clientNames = new List<string>();
                foreach (Client c in clients)
                {
                    clientNames.Add(c.getID());
                }
                uxClientListBox = new ListBox();
                uxClientListBox.DataSource = clientNames;


            }//else
        }

        private void uxStopBidding_Click(object sender, EventArgs e)
        {
            Product product = Database.searchProduct(uxProductListBox.SelectedItem.ToString());
            product.setTimer(0);
            TimesUpHandler.TimesUp(product);
        }
    }
}
