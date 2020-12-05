using BidLibrary.Library;
using Client.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public interface UpdateBid
    {
        /// <summary>
        /// an interface to integrate the UpdateBid method
        /// </summary>
        void UpdateBid(Bid bid);

    }
}
