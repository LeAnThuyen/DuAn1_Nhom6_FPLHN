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
    public partial class FormThongTinBanHang : Form
    {
        public FormThongTinBanHang()
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

        private void đặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FRMDatHang(), sender);
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHoaDonBanHang(), sender);
        }
    }
}
