using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmDoiMatKhau : Form
    {
        private IServicesChangePass _iServicesChangePass;
        private NhanVien _nv;
        private IServicesNhanVien _iservicesnv;
        string email;
        private IRolesServices _iroleservices;
        //private List<ViewNhanVien> _lstviewnhanvien;
        // private IServicesNhanVien _iServicesNhanVien;
        public FrmDoiMatKhau(string tk)
        {
            InitializeComponent();
            _iservicesnv = new NhanVienServices();
            email = tk;
            //_lstviewnhanvien = new List<ViewNhanVien>();
            //_iServicesNhanVien = new NhanVienServices();
            _iServicesChangePass = new ChangeServices();
            _iroleservices = new RolesServices();
            _nv = new NhanVien();
            LoadQuyen();
        }
        void LoadQuyen()
        {
            foreach (var x in _iroleservices.getListRole())
            {
                cbo_role.Items.Add(x.RoleName);

            }
            cbo_role.SelectedIndex = 0;

        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {

            try
            {
                string passcheck = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Email == txt_email.Text).Select(c => c.PassWord).FirstOrDefault();

                if (_iServicesChangePass.encryption(txt_mkc.Text) == passcheck && txt_mkm.Text == txt_nlmk.Text)
                {
                    _nv.Iduser = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Email == txt_email.Text).Select(c => c.Iduser).FirstOrDefault();
                    _nv.Email = Convert.ToString(txt_email.Text);
                    _nv.MaNhanVien = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.MaNhanVien).FirstOrDefault();
                    _nv.TenNhanVien = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.TenNhanVien).FirstOrDefault();
                    _nv.GioiTinh = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.GioiTinh).FirstOrDefault();
                    _nv.NamSinh = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.NamSinh).FirstOrDefault();
                    _nv.PassWord = _iServicesChangePass.encryption(txt_mkm.Text);
                    _nv.QueQuan = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.QueQuan).FirstOrDefault();
                    _nv.SoCmnd = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.SoCmnd).FirstOrDefault();
                    _nv.DienThoai = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.DienThoai).FirstOrDefault();
                    _nv.TrangThai = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.TrangThai).FirstOrDefault();
                    _nv.Anh = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.Anh).FirstOrDefault();
                    _nv.Idrole = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.Idrole).FirstOrDefault();
                    _nv.Flag = _iservicesnv.getlstnhanvienfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.Flag).FirstOrDefault();
                    _iservicesnv.updatenhanvien(_nv);
                    _iservicesnv.save(_nv);
                    MessageBox.Show("Đổi Mật Khẩu Thành Công", "Thông báo");
                    return;

                }
                else
                {
                    MessageBox.Show("Thông tin bạn vừa nhập không đúng. Mời nhập lại!", "Thông Báo");
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Bình Để Sửa Lỗi");
            }


        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                txt_mkc.UseSystemPasswordChar = true;
            }
            else
            {
                txt_mkc.UseSystemPasswordChar = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                txt_mkm.UseSystemPasswordChar = true;
            }
            else
            {
                txt_mkm.UseSystemPasswordChar = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked)
            {
                txt_nlmk.UseSystemPasswordChar = true;
            }
            else
            {
                txt_nlmk.UseSystemPasswordChar = false;
            }
        }

        private void btn_timtk_Click(object sender, EventArgs e)
        {
            try
            {
                var rl = _iroleservices.getListRole().Where(c => c.RoleName == Convert.ToString(cbo_role.Text)).Select(c => c.Idrole).FirstOrDefault();
                for (int i = 0; i < _iservicesnv.getlstnhanvienfromDB().Count; i++)
                {
                    if (_iservicesnv.getlstnhanvienfromDB()[i].Email == txt_email.Text && _iservicesnv.getlstnhanvienfromDB()[i].Idrole == Convert.ToInt32(rl))
                    {
                        MessageBox.Show("Chúc mứng bạn đã nhập đúng tài khoản", "Thông báo");
                        grb_check.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Bình Để Sửa Lỗi");
            }

        }

        private void txt_email_Leave(object sender, EventArgs e)
        {
            string patter = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txt_email.Text, patter))
            {

            }
            else
            {
                MessageBox.Show("Mời bạn nhập lại email, Thông Báo");
                return;
            }
        }
        public bool Check()
        {
            if (string.IsNullOrEmpty(txt_email.Text))
            {
                MessageBox.Show("Email không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_mkc.Text))
            {
                MessageBox.Show("Mật khẩu cũ không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_mkm.Text))
            {
                MessageBox.Show("Mật khẩu mới không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_nlmk.Text))
            {
                MessageBox.Show("Mật khẩu nhập lại không được bỏ trống", "Thông báo");
                return false;
            }

            //tên
            if (txt_mkm.Text.Length <= 3)
            {
                MessageBox.Show("Mật khẩu mới phải trên 3 ký tự", "ERR");
                return false;
            }
            if (txt_nlmk.Text.Length <= 3)
            {
                MessageBox.Show("Mật khẩu nhập lại phải trên 3 ký tự", "ERR");
                return false;
            }
            return true;
        }
    }
}
