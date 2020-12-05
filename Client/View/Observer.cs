using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.View
{
    public interface Observer
    {
        /// <summary>
        /// An observer to track the state of the controller
        /// </summary>
        /// <param name="state">an enum describing the state of the view</param>
        void Update(State state);

    }
}
