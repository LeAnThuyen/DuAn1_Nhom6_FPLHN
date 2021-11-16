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

        private void OpenChildForm(Form childForm, object btnSender)
        {

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelhome.Controls.Add(childForm);
            this.panelhome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();



        }

    


        private void timer2_Tick(object sender, EventArgs e)
        {
         
        }

        private void tbDark_CheckedChanged_1(object sender, EventArgs e)
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
            label1.Text = DateTime.Now.ToLongTimeString();
            label17.Text = DateTime.Now.ToLongDateString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dịtMẹMàyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongTinBanHang(), sender);
           
        }

        private void thôngTinToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormMoRong(), sender);
        }
    }
}
