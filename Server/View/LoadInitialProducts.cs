using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.View
{
    
    public interface LoadInitialProducts
    {
        /// <summary>
        /// this interface will call a controller method to load the initial products in to the database from a file. the file should be located in the home directory
        /// </summary>
        void LoadInitialProducts();
        

    }
}
