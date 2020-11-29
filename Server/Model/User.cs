using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    /// <summary>
    /// An object that represents the users that can login
    /// </summary>
    class User
    {
        //parameters

        /// <summary>
        /// the identifier for the user
        /// </summary>
        private string userID;

        /// <summary>
        /// the password for the user
        /// </summary>
        private string password;

        /// <summary>
        /// a boolean indicating whether the user is or is not an admin. True means that they are. 
        /// </summary>
        private bool admin;


        //method

        /// <summary>
        /// default constructor for the user
        /// </summary>
        public User()
        {

        }//User

        /// <summary>
        /// constructor for the user which sets the password and ID
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="pass">the password of the user</param>
        public User(string id, string pass)
        {
            userID = id;
            password = pass;
        }//User

        /// <summary>
        /// constructor for the user which sets the password, ID, and access rights
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="pass">the password of the user</param>
        /// <param name="level">the access level of the user (true for admin, false for normal)</param>
        public User(string id, string pass,bool level)
        {
            userID = id;
            password = pass;
            admin = level;
        }//User

        /// <summary>
        /// getter for the user ID
        /// </summary>
        /// <returns>the ID of the user</returns>
        public string getID()
        {
            return userID;
        }//getID

        /// <summary>
        /// setter for the user ID
        /// </summary>
        /// <param name="ID">the desired ID for the user</param>
        public void setID(string ID)
        {
            userID = ID;
        }//setID

        /// <summary>
        /// getter for the password
        /// </summary>
        /// <returns>the password of the user</returns>
        public string getPassword()
        {
            return password;
        }//getID

        /// <summary>
        /// setter for the password
        /// </summary>
        /// <param name="ID">the desired password for the user</param>
        public void setPassword(string pass)
        {
            password = pass;
        }//setID

        /// <summary>
        /// getter for whether or not the user is an admin
        /// </summary>
        /// <returns>boolean. If the user is an admin, this returns true, if not it returns false</returns>
        public bool getAdmin()
        {
            return admin;
        }//getAdmin

        /// <summary>
        /// setter for whether or not the user is an admin
        /// </summary>
        /// <param name="a">a boolean. If the user is an admin, this should be true, if not it should be false</param>
        public void setAdmin(bool a)
        {
            admin = a;
        }//setAdmin




    }
}
