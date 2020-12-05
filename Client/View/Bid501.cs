using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BidLibrary.Library;
using Client.Controller;
using Client.Data;

namespace Client.View
{
    public partial class Bid501 : Form , Observer
    {
        /// <summary>
        /// a variable to keep track of the UpdateBid object
        /// </summary>
        private UpdateBid uBid;
        /// <summary>
        /// a variable to keep track of the state of the controller
        /// </summary>
        private State formState;
        /// <summary>
        /// a BindingList of products to keep the view in sync with the server
        /// </summary>
        private BindingList<Product> pList = DatabaseProxy.productList;
        /// <summary>
        /// A default constructor for the Bid501 View
        /// </summary>
        public Bid501()
        {
            InitializeComponent();
            pList = DatabaseProxy.productList;
            uxListBox.DataSource = pList;
            Update(State.intialConnect);
            
        }
        /// <summary>
        /// Sets the UpdateBid variable to the given value
        /// </summary>
        public void setUB(UpdateBid ub)
        {
            uBid = ub;
        }
        /// <summary>
        /// updates the view based on the updates controller state
        /// </summary>
        public void Update(State state)
        {
            formState = state;
            if (formState == State.updating)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() => pList.ResetBindings()
                        ));
                }
            }
            else if(formState == State.loginPageTrue)
            {
                MessageBox.Show("You won the Bid!");
            }
            else if(formState == State.loginPageFalse)
            {
                MessageBox.Show("You lost the bid");
            }

        }

        /// <summary>
        /// Creates and checks the validity of a new bid based on the information in the view
        /// </summary>
        private void bidButton_Click(object sender, EventArgs e)
        {
            Product curPro = new Product();

            string current = uxListBox.SelectedItem.ToString();
            for (int i = 0; i < DatabaseProxy.productList.Count; i++)
            {
                if (DatabaseProxy.productList[i].getID().Equals(current))
                {
                    curPro = DatabaseProxy.productList[i];
                }
            }
            Bid newBid = new Bid();
            double bidAMT = Convert.ToDouble(uxInput.Text);
            List<Bid> bidList = curPro.getBidList();
            if(bidList != null)
            {
                Bid topBid = bidList[(bidList.Count - 1)];
                
                if (topBid.getBid() < bidAMT)
                {
                    newBid.setBid(bidAMT);
                    newBid.setProduct(curPro);
                    uBid.UpdateBid(newBid);
                }
                else
                {
                    MessageBox.Show("Bid is not higher than current high bid");
                }

            }
            else
            {
                newBid.setBid(bidAMT);
                newBid.setProduct(curPro);
                uBid.UpdateBid(newBid);
            }
            
        }

        /// <summary>
        /// Changes information on the form based on a change of the selected item in the listbox
        /// </summary>
        private void uxListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product curPro= new Product();



            string current = uxListBox.SelectedItem.ToString();
            if (current != null)
            {
                for (int i = 0; i < DatabaseProxy.productList.Count; i++)
                {
                    if (DatabaseProxy.productList[i].getID().Equals(current))
                    {
                        curPro = DatabaseProxy.productList[i];
                    }
                }

                uxProductName.Text = curPro.getID();
                uxRemainingTime.Text = "Time Remaining: " +curPro.getTimer().ToString();
                uxStatusLabel.Text = "Active";
                List<Bid> bids = curPro.getBidList();
                if (bids == null)
                {
                    uxBids.Text = "0";
                    uxMinBid.Text = "$0";
                }
                else
                {
                    uxBids.Text = "Bids: "+ bids.Count.ToString();
                    uxMinBid.Text = "$" + bids[bids.Count - 1].ToString();
                }
                
                
            }

        }
        /// <summary>
        /// Refreshes the listbox when the buttons is pressed
        /// </summary>
        private void uxLoad_Click(object sender, EventArgs e)
        {
            pList = DatabaseProxy.productList;
            uxListBox.DataSource = pList;
            Update(State.updating);
        }
    }
}
