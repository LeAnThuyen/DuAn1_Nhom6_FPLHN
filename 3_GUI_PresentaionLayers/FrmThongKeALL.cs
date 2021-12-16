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
    public partial class FrmThongKeALL : Form
    {
        private Form activeForm;
        public FrmThongKeALL()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
         
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelhome.Controls.Add(childForm);
            this.panelhome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
           


        }
        private void thốngKêDoanhThuNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTinhTrangHoaDon(), sender);
        }

        private void thốngKêSảnPhẩmBánChạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBestseller(), sender);
           
        }

        
    }
}
