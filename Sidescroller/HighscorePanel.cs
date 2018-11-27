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
    public partial class HighscorePanel : UserControl
    {
        public event EventHandler onBack;
        private LinkedList<HighscoreEntry> entries;

        public HighscorePanel()
        {
            InitializeComponent();
            this.entryTable.Controls.Add(HighscoreEntry.createHeaderEntry(), 1, 0);
        }

        public void loadHighscore()
        {
            entries = SQLManager.Instance.selectHighscore();
            if (entries != null)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    entryTable.Controls.Add(entries.ElementAt(i), 1, i + 1);
                }
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
