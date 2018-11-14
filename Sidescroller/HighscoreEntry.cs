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
    public partial class HighscoreEntry : UserControl
    {
        public int Place { get; set; }
        public string Name { get; set; }
        public long Score { get; set; }

        public HighscoreEntry()
        {
            InitializeComponent();
        }

        public void setFields(int place, string name, long score)
        {
            Place = place;
            Name = name;
            Score = score;

            lblPlace.Text = Place.ToString();
            lblName.Text = Name;
            lblScore.Text = Score.ToString();
        }

        public static HighscoreEntry createHeaderEntry()
        {
            HighscoreEntry header = new HighscoreEntry();
            header.lblPlace.Text = "PLACE";
            header.lblName.Text = "NAME";
            header.lblScore.Text = "SCORE";
            return header;
        }
    }
}
