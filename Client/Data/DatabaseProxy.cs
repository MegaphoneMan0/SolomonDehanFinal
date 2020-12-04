using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidLibrary;
using BidLibrary.Library;

namespace Client.Data
{
    /// <summary>
    /// The database that contains most of the information the controller needs
    /// </summary>
    public static class DatabaseProxy
    {
        //parameters

       

        /// <summary>
        /// a list of available products that clients can bid on. Only includes products available for bidding
        /// </summary>
        public static BindingList<Product> productList = new BindingList<Product>();
        



        //methods

        /// <summary>
        /// returns all products in the database proxy
        /// </summary>
        /// <returns>the productList</returns>
        public static BindingList<Product> getAll()
        {
            return productList;
        }


    }//database
}
