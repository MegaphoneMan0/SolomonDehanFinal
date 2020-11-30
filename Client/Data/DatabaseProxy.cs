﻿using System;
using System.Collections.Generic;
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
    public class DatabaseProxy
    {
        //parameters

       

        /// <summary>
        /// a list of available products that clients can bid on. Only includes products available for bidding
        /// </summary>
        public List<Product> productList = new List<Product>();




        //methods

        /// <summary>
        /// returns all products in the database proxy
        /// </summary>
        /// <returns>the productList</returns>
        public List<Product> getAll()
        {
            return productList;
        }


    }//database
}
