using BidLibrary.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.View
{
    interface ProductUpdater
    {
        /// <summary>
        /// sends the new product to the database
        /// </summary>
        /// <param name="product">the product that needs to be added</param>
        void UpdateProduct(Product product);

    }
}
