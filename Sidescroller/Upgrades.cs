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
        public User User { get; set; }
        public Form1 Form1 { get; set; }

        public event EventHandler onBack;

        public Upgrades()
        {
            InitializeComponent();
        }

        public void updateButtonVisibility()
        {
            if (User.BoughtUpgrades.Contains(1))
            {
                btnUpgrade1.Visible = false;
            }

            if (User.BoughtUpgrades.Contains(2))
            {
                btnUpgrade2.Visible = false;
            }

            if (User.BoughtUpgrades.Contains(3))
            {
                btnUpgrade3.Visible = false;
            }

            if (User.BoughtUpgrades.Contains(4))
            {
                btnUpgrade4.Visible = false;
            }

            if (User.BoughtUpgrades.Contains(5))
            {
                btnUpgrade5.Visible = false;
            }
        }

        private void btnUpgrade1_Click(object sender, EventArgs e)
        {
            if (User != null) {
                if (this.User.Money >= 5)
                {
                    this.User.Money -= 5;
                    this.Form1.setMoney(this.User.Money);
                    SQLManager.Instance.insertUserUpgrade(this.User, 1);
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
            if (User != null) {
                if (this.User.Money >= 20)
                {
                    this.User.Money -= 20;
                    this.Form1.setMoney(this.User.Money);
                    SQLManager.Instance.insertUserUpgrade(this.User, 2);
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
            if (User != null) {
                if (this.User.Money >= 50)
                {
                    this.User.Money -= 50;
                    this.Form1.setMoney(this.User.Money);
                    SQLManager.Instance.insertUserUpgrade(this.User, 3);
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
            if (User != null) {
                if (this.User.Money >= 100)
                {
                    this.User.Money -= 100;
                    this.Form1.setMoney(this.User.Money);
                    SQLManager.Instance.insertUserUpgrade(this.User, 4);
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
            if (User != null) {
                if (this.User.Money >= 10)
                {
                    this.User.Money -= 10;
                    this.Form1.setMoney(this.User.Money);
                    SQLManager.Instance.insertUserUpgrade(this.User, 5);
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
