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
        /// getter for the highestBid
        /// </summary>
        /// <returns>the highestBid</returns>
        public Bid getBid()
        {
            return highestBid;
        }

        /// <summary>
        /// setter for the highestBid
        /// </summary>
        /// <param name="bid">the Bid that you want the highestBid to be</param>
        public void setBid(Bid bid)
        {
            highestBid = bid;
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
