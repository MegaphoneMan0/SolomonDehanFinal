using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Server.View
{
    interface Observer
    {
        /// <summary>
        /// TBH, no idea what this does. I'll figure it out!
        /// </summary>
        /// <param name="state">who knows</param>
        void Update(State state);

    }
}
