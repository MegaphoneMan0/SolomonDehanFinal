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
        private List<User> userLibrary = new List<User>();

        private List<Product> productLibrary = new List<Product>();

        private List<Client> clientLibrary = new List<Client>();

        private List<Bid> bidLibrary = new List<Bid>();

    }//database
}
