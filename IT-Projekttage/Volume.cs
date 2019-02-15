using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_Projekttage
{
    public partial class Volume : Form
    {
        public static string sampleName1;
        public static string sampleName2;
        public static string sampleName3;
        public static string sampleName4;
        public static string sampleName5;
        public static string sampleName6;
        public Volume()
        {
            InitializeComponent();
            lblInstrument1.Text = sampleName1;
            lblInstrument2.Text = sampleName2;
            lblInstrument3.Text = sampleName3;
            lblInstrument4.Text = sampleName4;
            lblInstrument5.Text = sampleName5;
            lblInstrument6.Text = sampleName6;
            volBox1.Text = Convert.ToString(Hauptseite.Sample1Vol);
            volBox2.Text = Convert.ToString(Hauptseite.Sample2Vol);
            volBox3.Text = Convert.ToString(Hauptseite.Sample3Vol);
            volBox4.Text = Convert.ToString(Hauptseite.Sample4Vol);
            volBox5.Text = Convert.ToString(Hauptseite.Sample5Vol);
            volBox6.Text = Convert.ToString(Hauptseite.Sample6Vol);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hauptseite.Sample1Vol = Convert.ToInt32(volBox1.Text);
            Hauptseite.Sample2Vol = Convert.ToInt32(volBox2.Text);
            Hauptseite.Sample3Vol = Convert.ToInt32(volBox3.Text);
            Hauptseite.Sample4Vol = Convert.ToInt32(volBox4.Text);
            Hauptseite.Sample5Vol = Convert.ToInt32(volBox5.Text);
            Hauptseite.Sample6Vol = Convert.ToInt32(volBox6.Text);
            this.Close();
        }

        private void volBox1_TextChanged(object sender, EventArgs e)
        {
            volBar1.Value = Convert.ToInt32(volBox1.Text);
        }

        private void volBar1_ValueChanged(object sender, EventArgs e)
        {
            volBox1.Text = Convert.ToString(volBar1.Value);
        }

        private void volBox2_TextChanged(object sender, EventArgs e)
        {
            volBar2.Value = Convert.ToInt32(volBox2.Text);
        }

        private void volBar2_ValueChanged(object sender, EventArgs e)
        {
            volBox2.Text = Convert.ToString(volBar2.Value);
        }

        private void volBox3_TextChanged(object sender, EventArgs e)
        {
            volBar3.Value = Convert.ToInt32(volBox3.Text);
        }

        private void volBar3_ValueChanged(object sender, EventArgs e)
        {
            volBox3.Text = Convert.ToString(volBar3.Value);
        }

        private void volBox4_TextChanged(object sender, EventArgs e)
        {
            volBar4.Value = Convert.ToInt32(volBox4.Text);
        }

        private void volBar4_ValueChanged(object sender, EventArgs e)
        {
            volBox4.Text = Convert.ToString(volBar4.Value);
        }

        private void volBox5_TextChanged(object sender, EventArgs e)
        {
            volBar5.Value = Convert.ToInt32(volBox5.Text);
        }

        private void volBar5_ValueChanged(object sender, EventArgs e)
        {
            volBox5.Text = Convert.ToString(volBar5.Value);
        }

        private void volBox6_TextChanged(object sender, EventArgs e)
        {
            volBar6.Value = Convert.ToInt32(volBox6.Text);
        }

        private void volBar6_ValueChanged(object sender, EventArgs e)
        {
            volBox6.Text = Convert.ToString(volBar6.Value);
        }
    }
}
