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
    public partial class FormHoaDonChiTiet : Form
    {
        public FormHoaDonChiTiet()
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

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            label18.Text = DateTime.Now.ToLongTimeString();
            label17.Text = DateTime.Now.ToLongDateString();
        }
    }
}
