using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidLibrary.Library
{
    //jack
    public class Product
    {
        //parameters

        /// <summary>
        /// the identifying string for the product. Duplicate products are not currently allowed, so this is also just the name of the product
        /// </summary>
        private string productID;

        /// <summary>
        /// a list of bids ordered from highest to lowest. Each bid is from a unique client, no client should be on the list multiple times
        /// </summary>
        private List<Bid> bidList;

        
        

        /// <summary>
        /// the amount of time left on to bid
        /// </summary>
        private double bidTimer;

        //methods

        /// <summary>
        /// default constructor
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// constructor that takes the productID
        /// </summary>
        /// <param name="id">productID</param>
        public Product(string id)
        {
            productID = id;
        }

        /// <summary>
        /// getter for the productID
        /// </summary>
        /// <returns>the productID</returns>
        public string getID()
        {
            return productID;
        }

        /// <summary>
        /// setter for the productID
        /// </summary>
        /// <param name="id">the string that you want the productID to be</param>
        public void setID(string id)
        {
            productID = id;
        }

        /// <summary>
        /// getter for the list of bids
        /// </summary>
        /// <returns>the list of bids</returns>
        public List<Bid> getBidList()
        {
            return bidList;
        }

        /// <summary>
        /// setter for the bidList
        /// </summary>
        /// <param name="bid">the list of bids for this product</param>
        public void setBid(List<Bid> bids)
        {
            bidList = bids;
        }


        /// <summary>
        /// getter for the bidTimer
        /// </summary>
        /// <returns>the double that represents the timer</returns>
        public double getTimer()
        {
            return bidTimer;
        }//getTimer

        /// <summary>
        /// setter for the bidTimer
        /// </summary>
        /// <param name="timer">the double for the amount of time left on the timer</param>
        public void setTimer(double timer)
        {
            bidTimer = timer;
        }//setTimer


    }
}
