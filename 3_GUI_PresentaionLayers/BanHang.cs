using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }

      

        private void tbDark_CheckedChanged(object sender, EventArgs e)
        {
            if (tbDark.Checked)
            {
                this.BackColor = Color.RosyBrown;

            }
            else
            {
                this.BackColor = Color.DarkOliveGreen;

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label26.Text = DateTime.Now.ToLongTimeString();
            label25.Text = DateTime.Now.ToLongDateString();
        }
    }
}
