using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaitonLayer
{
    public partial class fCRUDHangHoa : Form
    {
        public fCRUDHangHoa()
        {
            InitializeComponent();
            CSSBorderTextBox();
        }

        void CSSBorderTextBox()
        {
            label3.AutoSize = false;
            label3.Height = 2;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label5.AutoSize = false;
            label5.Height = 2;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label7.AutoSize = false;
            label7.Height = 2;
            label7.BorderStyle = BorderStyle.Fixed3D;
            label9.AutoSize = false;
            label9.Height = 2;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label11.AutoSize = false;
            label11.Height = 2;
            label11.BorderStyle = BorderStyle.Fixed3D;
            label13.AutoSize = false;
            label13.Height = 2;
            label13.BorderStyle = BorderStyle.Fixed3D;
            label17.AutoSize = false;
            label17.Height = 2;
            label17.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            fNhaSanXuat f = new fNhaSanXuat();
            f.Show();
        }
    }
}
