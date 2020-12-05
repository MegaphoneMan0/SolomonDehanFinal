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
        private UpdateBid uBid;
        private State formState;
        private BindingList<Product> pList = DatabaseProxy.productList;
        public Bid501()
        {
            InitializeComponent();
            pList = DatabaseProxy.productList;
            uxListBox.DataSource = pList;
            Update(State.intialConnect);
            
        }

        public void setUB(UpdateBid ub)
        {
            uBid = ub;
        }

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

        }

        private void bidButton_Click(object sender, EventArgs e)
        {
            //Product sample = uxListBox.SelectedItem;
            //Product sample = new Product();
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
            }
            else
            {
                newBid.setBid(bidAMT);
                newBid.setProduct(curPro);
                uBid.UpdateBid(newBid);
            }
            
        }

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

        
    }
}
