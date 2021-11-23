using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;

namespace _3_GUI_PresentaionLayers
{
    public partial class fKhachHang : Form
    {
        private IQlyKhachHang _iQlyKhachHang;
        public fKhachHang()
        {
            InitializeComponent();
            _iQlyKhachHang = new QLyKhachHangServices();
            css();
        }

        void css()
        {
            label7.AutoSize = false;
            label7.Height = 2;
            label7.BorderStyle = BorderStyle.Fixed3D;
            label9.AutoSize = false;
            label9.Height = 2;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label18.AutoSize = false;
            label18.Height = 2;
            label18.BorderStyle = BorderStyle.Fixed3D;
            label20.AutoSize = false;
            label20.Height = 2;
            label20.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == _iQlyKhachHang.GetsListKH().Where(x => x.Email == txtEmail.Text).Select(x => x.Email)
                .FirstOrDefault())
            {
                MessageBox.Show("Email bạn thêm đã bị trùng/n", "Thông báo");
            }

            
        
            var x = MessageBox.Show("Bạn có chắc chắn muốn thêm khách hàng không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (x == DialogResult.No)
            {
                return;
            }

            KhachHang khachHang = new KhachHang()
            {
                IdkhachHang = _iQlyKhachHang.GetsListKH().Max(x=>x.IdkhachHang)+1,
                TenKhachHang = txtTenKH.Text,
                DiaChi   = txtDiaChi.Text,
                SoDienThoai = txtDT.Text,
                Email = txtEmail.Text,
                MaKhachHang = "KH00"+(_iQlyKhachHang.GetsListKH().Max(x => x.IdkhachHang) + 1),
                TrangThai = rbtCaNhan.Checked==true?true:false,
            };
            _iQlyKhachHang.addKH(khachHang);
            _iQlyKhachHang.SaveKH(khachHang);
        }

        private void fKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
