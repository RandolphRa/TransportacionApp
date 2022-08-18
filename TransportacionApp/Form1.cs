using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransportacionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
            
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            


        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

            bunifuPages1.PageIndex = 1;
            
        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }

        private void bunifuHSlider1_ValueChanged(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e)
        {
           
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 0;
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 1;
        }

       

       

        private void bunifuHSlider2_ValueChanged_1(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e)
        {
            bunifuRadialGauge3.Value = bunifuHSlider2.Value;
            bunifuRadialGauge4.Value = bunifuHSlider2.Value + 20;
            bunifuRadialGauge5.Value = bunifuHSlider2.Value;
         
            bunifuRadialGauge7.Value = bunifuHSlider2.Value;
     
            bunifuRadialGauge9.Value = bunifuHSlider2.Value;
            bunifuRadialGauge10.Value = bunifuHSlider2.Value + 20;
            bunifuRadialGauge11.Value = bunifuHSlider2.Value;
     
            bunifuRadialGauge13.Value = bunifuHSlider2.Value;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 2;
        }

        private void bunifuHSlider3_ValueChanged(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e)
        {
            bunifuCircleProgress1.Value = bunifuHSlider3.Value;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 0;
        }

        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 1;
        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 2;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
