using Server.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Server
{
    public partial class uxServerForm : Form, Observer
    {
        public uxServerForm()
        {
            InitializeComponent();
        }

        private void uxAddButton_Click(object sender, EventArgs e)
        {
            Application.Run(new uxAddProductForm());
        }


        public void Update(State state)
        {
            //no idea how states work, should probably figure that out (or check if I even need to use them at all
        }

    }
}
