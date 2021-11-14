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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormLoading frmLoading = new FormLoading();
            frmLoading.ShowDialog();
        }
    }
}
