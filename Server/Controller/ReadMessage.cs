using BidLibrary.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controller
{
    public interface ReadMessage
    {
        /// <summary>
        /// reads the message from the client and reacts depending on the message type
        /// </summary>
        /// <param name="message">the message that needs interpreting</param>
        /// <returns>the message (if its credential verification) or null if it's a new bid</returns>
        void ReadMessage(Message message, Communicator communicator);
        

    }
}
