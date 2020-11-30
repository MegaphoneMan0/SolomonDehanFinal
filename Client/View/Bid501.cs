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
            uxListBox.DataSource = Client.Controller..
        }

        private UpdateBid updateBid;
      
        

        private void bidButton_Click(object sender, EventArgs e)
        {
            //Product sample = uxListBox.SelectedItem;
            Product sample = new Product();
            Bid newBid = new Bid();
            double bidAMT = Convert.ToDouble(uxInput);
            if(sample.getBid().getBid() < bidAMT)
            {
                newBid.setBid(bidAMT);
                newBid.setProduct(sample);
                sample.setBid(newBid);
                UpdateBid(sample, newBid);
            }
        }

        private void uxListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public bool UpdateBid(Product product, Bid bid)
        {
            return updateBid.UpdateBid(product, bid);
        }
    }
}
