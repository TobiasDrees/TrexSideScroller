using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidescroller
{
    public partial class EndMenu : UserControl
    {
        public event EventHandler onRetry;
        public event EventHandler onHighscore;

        public EndMenu()
        {
            InitializeComponent();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            if (this.onRetry != null)
            {
                this.onRetry(this, e);
                this.Visible = false;
            }
        }

        private void btnUpgrades_Click(object sender, EventArgs e)
        {

        }

        private void btnHighscore_Click(object sender, EventArgs e)
        {
            if (this.onHighscore != null)
            {
                this.onHighscore(this, e);
                this.Visible = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }


    }
}
