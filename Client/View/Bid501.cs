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

namespace Client
{
    public partial class Bid501 : Form , UpdateBid
    {
        public Bid501()
        {
            InitializeComponent();
            uxListBox.DataSource = Data.DatabaseProxy.productList;
            uxListBox.DisplayMember = "productID";
        }

        private UpdateBid updateBid;
      
        

        private void bidButton_Click(object sender, EventArgs e)
        {
            //Product sample = uxListBox.SelectedItem;
            Product sample = new Product();
            Bid newBid = new Bid();
            double bidAMT = Convert.ToDouble(uxInput.Text);
            List<Bid> bidList = sample.getBidList();
            Bid topBid = bidList[(bidList.Count-1)];
            if(topBid.getBid() < bidAMT)
            {
                newBid.setBid(bidAMT);
                newBid.setProduct(sample);
                UpdateBid(newBid);
            }
        }

        private void uxListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product curPro= new Product();
            string current = uxListBox.SelectedItem.ToString();
            for(int i = 0; i < DatabaseProxy.productList.Count; i++)
            {
                if(DatabaseProxy.productList[i].getID().Equals(current))
                {
                    curPro = DatabaseProxy.productList[i];
                }
            }

            uxProductName.Text = curPro.getID();
        }

        public bool UpdateBid(Bid bid)
        {
            return updateBid.UpdateBid(bid);
        }
    }
}
