using BidLibrary.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.View
{
    public interface TimesUp
    {
        /// <summary>
        /// TimesUp is for when the server admin
        /// </summary>
        /// <param name="product"></param>
        void TimesUp(Product product);


    }
}
