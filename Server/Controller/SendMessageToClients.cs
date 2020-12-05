using BidLibrary.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controller
{
    public interface SendMessageToClients
    {
        /// <summary>
        /// A method which will send the given Message to all connected clients
        /// </summary>
        /// <param name="message"></param>
        void sendMessageToClients(Message message);

    }
}
