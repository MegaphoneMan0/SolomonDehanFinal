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

        void sendMessageToClients(Message message);

    }
}
