using BidLibrary.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controller
{
    public interface UpdateClientList
    {

        /// <summary>
        /// updates the client list in the view
        /// </summary>
        /// <param name="clientList">the list of clients to be pushed to the view</param>
        BindingList<Product> UpdateClientList(List<string> clientList);

    }
}
