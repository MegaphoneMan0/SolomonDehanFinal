using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidLibrary.Library
{
    //jack
    public class Bid
    {
        //parameters

        /// <summary>
        /// the product that this Bid is for
        /// </summary>
        [JsonProperty] private Product product;


        /// <summary>
        /// the amount of the bid
        /// </summary>
        [JsonProperty] private double highestBid;

        /// <summary>
        /// the ID of the client who placed this bid
        /// </summary>
        [JsonProperty] private string highestBidder;


        //methods


        /// <summary>
        /// getter for the highestBid
        /// </summary>
        /// <returns>the double that represents the highestBid</returns>
        public double getBid()
        {
            return highestBid;
        }//getBid

        /// <summary>
        /// setter for the highestBid
        /// </summary>
        /// <param name="bid">the double that represents the amount of the highestBid</param>
        public void setBid(double bid)
        {
            highestBid = bid;
        }//setBid

        /// <summary>
        /// getter for the highestBidder
        /// </summary>
        /// <returns>the string that represents the highestBidder</returns>
        public string getBidder()
        {
            return highestBidder;
        }//getBid

        /// <summary>
        /// setter for the highestBidder
        /// </summary>
        /// <param name="bidder">the string that represents the id of the highestBidder</param>
        public void setBidder(string bidder)
        {
            highestBidder = bidder;
        }//setBid

        /// <summary>
        /// getter for the product
        /// </summary>
        /// <returns>a reference to the product that this bid is for</returns>
        public Product getProduct()
        {
            return product;
        }//getBid

        /// <summary>
        /// setter for the product
        /// </summary>
        /// <param name="bidder">a reference to the product that this bid is for</param>
        public void setProduct(Product prod)
        {
            product = prod;
        }//setBid

        /// <summary>
        /// sets the ToString to return the highestBid value
        /// </summary>
        public override string ToString()
        {
            return highestBid.ToString();
        }




    }//class
}//namespace
