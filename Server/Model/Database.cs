using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidLibrary;
using BidLibrary.Library;

namespace Server.Model
{
    class Database
    {
        //parameters

        /// <summary>
        /// a list of users which are hard coded
        /// </summary>
        private List<User> userLibrary = new List<User>();

        /// <summary>
        /// a list of available products that clients can bid on. Only includes products available for bidding
        /// </summary>
        private List<Product> productLibrary = new List<Product>();

        /// <summary>
        /// a list of clients that are connected to the server
        /// </summary>
        private List<Client> clientLibrary = new List<Client>();

        /// <summary>
        /// a list of bids associated with the products in the productlibrary
        /// </summary>
        private List<Bid> bidLibrary = new List<Bid>();

        
        //methods

        /// <summary>
        /// Default constructor
        /// </summary>
        public Database()
        {

        }//Database

        /// <summary>
        /// This method returns a product with the matching ID
        /// </summary>
        /// <param name="ID">The StringID of the desired Product</param>
        /// <returns>The desired product. If this product does not exist return is "null"</returns>
        public Product search(string ID)
        {
            foreach(Product p in productLibrary)
            {
                //need to implament Product before I can make this work
            }//foreach

            return null;
        }//Product






    }//database
}
