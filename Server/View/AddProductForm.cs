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
        public uxAddProductForm()
        {
            InitializeComponent();
        }

        //just hard coded these into the listbox's "items" property
        /*
        private static List<Product> productsThatCanBeAdded = new List<Product>()
        {
            new Product("Iphone 4s"),
            new Product("Civilization Revolution"),
            new Product("Goldfish Packet"),
            new Product("The entire Russian government")
        };
        */

        ProductUpdater productUpdaterHandler;

        private void uxAddButton_Click(object sender, EventArgs e)
        {

            Product newProduct = new Product(uxProductsToAddBox.SelectedItem.ToString());

            productUpdaterHandler.UpdateProduct(newProduct);
            

        }
    }
}
