using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public interface UserVerifier
    {
        /// <summary>
        /// Verify's the user's login credentials
        /// </summary>
        /// <param name="username">the username of the user</param>
        /// <param name="password">the password of the user</param>
        /// <returns>returns true of the username and password matched. Returns false if they did not</returns>
        void VerifyUser(string username, string password);

    }
}
