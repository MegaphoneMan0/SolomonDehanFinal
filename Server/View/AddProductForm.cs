using BidLibrary.Library;
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
    public partial class uxAddProductForm : Form
    {
        public uxAddProductForm(ProductUpdater PU)
        {
            productUpdaterHandler = PU;
            InitializeComponent();
            uxProductsToAddBox.DataSource = productsThatCanBeAdded;
        }

        //just hard coded these into the listbox's "items" property
        
        private static List<string> productsThatCanBeAdded = new List<string>()
        {
            "Iphone 4s",
            "Civilization Revolution",
            "Goldfish Packet",
            "The entire Russian government"
        };
        

        private ProductUpdater productUpdaterHandler;


        private void uxAddButton_Click(object sender, EventArgs e)
        {

            Product newProduct = new Product(uxProductsToAddBox.SelectedItem.ToString());

            productUpdaterHandler.UpdateProduct(newProduct);

            productsThatCanBeAdded.Remove(newProduct.getID());

            this.Close();

        }
    }
}
