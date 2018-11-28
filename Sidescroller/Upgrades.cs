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
    public partial class Upgrades : UserControl
    {
        public Form1 View { get; set; }

        public event EventHandler onBack;

        public Upgrades()
        {
            InitializeComponent();
        }

        public void updateButtonVisibility()
        {
            if (View.User.BoughtUpgrades.Contains(1))
            {
                btnUpgrade1.Visible = false;
            }

            if (View.User.BoughtUpgrades.Contains(2))
            {
                btnUpgrade2.Visible = false;
            }

            if (View.User.BoughtUpgrades.Contains(3))
            {
                btnUpgrade3.Visible = false;
            }

            if (View.User.BoughtUpgrades.Contains(4))
            {
                btnUpgrade4.Visible = false;
            }

            if (View.User.BoughtUpgrades.Contains(5))
            {
                btnUpgrade5.Visible = false;
            }
        }

        private void btnUpgrade1_Click(object sender, EventArgs e)
        {
            if (View.User != null)
            {
                if (View.Money >= 5)
                {
                    this.View.Money -= 5;
                    SQLManager.Instance.insertUserUpgrade(View.User, 1);
                    View.User.BoughtUpgrades.Add(1);
                    this.btnUpgrade1.Visible = false;
                }
                else
                {
                    MessageBox.Show("You need more Money!");
                }
            } else {
                MessageBox.Show("You're not logged in!");
            }
        }

        private void btnUpgrade2_Click(object sender, EventArgs e)
        {
            if (View.User != null)
            {
                if (View.Money >= 20)
                {
                    View.Money -= 20;
                    SQLManager.Instance.insertUserUpgrade(View.User, 2);
                    View.User.BoughtUpgrades.Add(2);
                    this.btnUpgrade2.Visible = false;
                }
                else
                {
                    MessageBox.Show("You need more Money!");
                }
            } else {
                MessageBox.Show("You're not logged in!");
            }
        }

        private void btnUpgrade3_Click(object sender, EventArgs e)
        {
            if (View.User != null)
            {
                if (View.Money >= 50)
                {
                    View.Money -= 50;
                    SQLManager.Instance.insertUserUpgrade(View.User, 3);
                    View.User.BoughtUpgrades.Add(3);
                    this.btnUpgrade3.Visible = false;
                }
                else
                {
                    MessageBox.Show("You need more Money!");
                }
            } else {
                MessageBox.Show("You're not logged in!");
            }
        }

        private void btnUpgrade4_Click(object sender, EventArgs e)
        {
            if (View.User != null)
            {
                if (View.Money >= 100)
                {
                    View.Money -= 100;
                    SQLManager.Instance.insertUserUpgrade(View.User, 4);
                    View.User.BoughtUpgrades.Add(4);
                    this.btnUpgrade4.Visible = false;
                }
                else
                {
                    MessageBox.Show("You need more Money!");
                }
            } else {
                MessageBox.Show("You're not logged in!");
            }
        }

        private void btnUpgrade5_Click(object sender, EventArgs e)
        {
            if (View.User != null)
            {
                if (View.Money >= 10)
                {
                    View.Money -= 10;
                    SQLManager.Instance.insertUserUpgrade(View.User, 5);
                    View.User.BoughtUpgrades.Add(5);
                    this.btnUpgrade5.Visible = false;
                }
                else
                {
                    MessageBox.Show("You need more Money!");
                }
            }
            else
            {
                MessageBox.Show("You're not logged in!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.onBack != null)
            {
                this.onBack(this, e);
                this.Visible = false;
            }
        }
    }
}
