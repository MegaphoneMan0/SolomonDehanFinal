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
        public Product searchProduct(string ID)
        {
            foreach(Product p in productLibrary)
            {
                if (p.getID().Equals(ID))
                {
                    return p;
                }    
            }//foreach

            return null;
        }//Product


        /// <summary>
        /// This method returns a User with the matching ID
        /// </summary>
        /// <param name="ID">The UserID of the desired User</param>
        /// <returns>The desired User. If this product does not exist return is "null"</returns>
        public User searchUser(string ID)
        {
            foreach (User p in userLibrary)
            {
                if (p.getID().Equals(ID))
                {
                    return p;
                }
            }//foreach

            return null;
        }//Product

        /// <summary>
        /// This method returns a Client with the matching ID
        /// </summary>
        /// <param name="id">The ID of the desired Client</param>
        /// <returns>The desired client. If this client does not exist return is "null"</returns>
        public Client searchClient(double id)
        {
            foreach (Client client in clientLibrary)
            {
                if (client.getID() == id)
                {
                    return client;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the userLibrary in it's entirety
        /// </summary>
        /// <returns></returns>
        public List<User> returnAllUsers()
        {
            return userLibrary;
        }//returnAllUsers

        /// <summary>
        /// returns the product library
        /// </summary>
        /// <returns>the product library as a list of products</returns>
        public List<Product> returnAllProducts()
        {
            return productLibrary;
        }

        /// <summary>
        /// a method to add a new user
        /// </summary>
        /// <param name="username">username of the new user</param>
        /// <param name="password">password of the new user</param>
        public void addUser(string username, string password)
        {
            User newUser = new User(username, password);
        }

        /// <summary>
        /// a method to remove a user
        /// </summary>
        /// <param name="username">the username of the user to remove</param>
        public void removeUser(string username)
        {
            User userToRemove = searchUser(username);

            userLibrary.Remove(userToRemove);

        }

        /// <summary>
        /// a method to add a product
        /// </summary>
        /// <param name="name">the name of the new product</param>
        public void addProduct(string name)
        {
            Product productToAdd = new Product(name);

            productLibrary.Add(productToAdd);
        }

        /// <summary>
        /// adds a client to the client library
        /// </summary>
        /// <param name="c">a unique string of numbers to identify the client</param>
        public void addClient(double c)
        {
            Client clientToAdd = new Client(c);
        }

        /// <summary>
        /// removes a client from the client library
        /// </summary>
        /// <param name="c">the identifier of the client to be removed</param>
        public void removeClient(double c)
        {
            Client clientToRemove = searchClient(c);

            clientLibrary.Remove(clientToRemove);
        }

        /// <summary>
        /// adds a bid to the bid library
        /// </summary>
        /// <param name="b">the bid to be added</param>
        public void addBid(Bid b)
        {
            bidLibrary.Add(b);
        }

        /// <summary>
        /// removes a bid from the bid library
        /// </summary>
        /// <param name="b">the bid to be removed</param>
        public void removeBid(Bid b)
        {
            bidLibrary.Remove(b);
        }



    }//database
}
