using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace IT_Projekttage
{
    public partial class Ueber : Form
    {
        public Ueber()
        {
            InitializeComponent();
        }

        private void lbl_kott129771_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:kott129771@itahaus-krbor.de");
        }

        private void lbl_varl129582_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:varl129582@itahaus.krbor.de");
        }

        private void lbl_schm130668_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:schm130668@itahaus-krbor.de");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.efense.de");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.amexus.com");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.steinlemoss.de/");
        }
    }
}
