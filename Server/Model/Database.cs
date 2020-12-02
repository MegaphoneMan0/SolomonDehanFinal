using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidLibrary;
using BidLibrary.Library;

namespace Server.Model
{
    /// <summary>
    /// The database that contains most of the information the controller needs
    /// </summary>
    static class Database
    {
        //parameters

       

        /// <summary>
        /// a list of users which are hard coded
        /// </summary>
        private static List<User> userLibrary = new List<User>() 
        { 
            new User("jdehan", "password123", true), 
            new User("jackfrost0", "password123", true),
            new User("jorge","password123",false)
        };

        /// <summary>
        /// a list of available products that clients can bid on. Only includes products available for bidding
        /// </summary>
        private static BindingList<Product> productLibrary = new BindingList<Product>();

        /// <summary>
        /// a list of clients that are connected to the server
        /// </summary>
        private static BindingList<Client> clientLibrary = new BindingList<Client>();

        /// <summary>
        /// a list of bids associated with the products in the productlibrary
        /// </summary>
        private static BindingList<Bid> bidLibrary = new BindingList<Bid>();

        
        //methods

        

        /// <summary>
        /// This method returns a product with the matching ID
        /// </summary>
        /// <param name="ID">The StringID of the desired Product</param>
        /// <returns>The desired product. If this product does not exist return is "null"</returns>
        public static Product searchProduct(string ID)
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
        public static User searchUser(string ID)
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
        public static Client searchClient(string id)
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
        public static List<User> returnAllUsers()
        {
            return userLibrary;
        }//returnAllUsers

        /// <summary>
        /// returns the product library
        /// </summary>
        /// <returns>the product library as a list of products</returns>
        public static BindingList<Product> returnAllProducts()
        {
            return productLibrary;
        }
        
        /// <summary>
        /// returns the client library
        /// </summary>
        /// <returns>the client library as a list of clients</returns>
        public static BindingList<Client> returnAllClients()
        {
            return clientLibrary;
        }

        /// <summary>
        /// a method to add a new user
        /// </summary>
        /// <param name="username">username of the new user</param>
        /// <param name="password">password of the new user</param>
        public static void addUser(string username, string password)
        {
            User newUser = new User(username, password);
        }//addUser

        /// <summary>
        /// a method to remove a user
        /// </summary>
        /// <param name="username">the username of the user to remove</param>
        public static void removeUser(string username)
        {
            User userToRemove = searchUser(username);

            userLibrary.Remove(userToRemove);

        }

        /// <summary>
        /// a method to add a product given a string
        /// </summary>
        /// <param name="name">the name of the new product</param>
        public static void addProduct(string name)
        {
            Product productToAdd = new Product(name);

            productLibrary.Add(productToAdd);
        }//addproduct

        /// <summary>
        /// a method to add a product given a product
        /// </summary>
        /// <param name="p">the product to add</param>
        public static void addProduct(Product p)
        {
            productLibrary.Add(p);
        }//addproduct

        /// <summary>
        /// adds a client to the client library
        /// </summary>
        /// <param name="c">a string to identify the client</param>
        public static void addClient(string c)
        {
            Client clientToAdd = new Client(c);
            clientLibrary.Add(clientToAdd);
        }

        /// <summary>
        /// removes a client from the client library
        /// </summary>
        /// <param name="c">the identifier of the client to be removed</param>
        public static void removeClient(string c)
        {
            Client clientToRemove = searchClient(c);

            clientLibrary.Remove(clientToRemove);
        }

        /// <summary>
        /// adds a bid to the bid library
        /// </summary>
        /// <param name="b">the bid to be added</param>
        public static void addBid(Bid b)
        {
            bidLibrary.Add(b);
        }

        /// <summary>
        /// removes a bid from the bid library
        /// </summary>
        /// <param name="b">the bid to be removed</param>
        public static void removeBid(Bid b)
        {
            bidLibrary.Remove(b);
        }

        /// <summary>
        /// returns all bids in the database
        /// </summary>
        /// <returns>the bidlibrary</returns>
        public static BindingList<Bid> getAllBids()
        {
            return bidLibrary;
        }


        


    }//database
}
