using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Server.View
{
    public interface Observer
    {
        /// <summary>
        /// OOOOOOKAY, it doesn't actually say that we need to use states, so i'm pitching this thing soon
        /// </summary>
        /// <param name="state">who knows</param>
        void Update(State state);

    }
}
