using _1_DAL_DataAccessLayer.DALServices;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;
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

        private IServiceForDangNhap iserlogin;
      
        public static FormDangNhap backsender;
        public FormDangNhap()
        {
            InitializeComponent();
            iserlogin = new DangNhapServies();
          
            backsender = this;
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                txt_username.Text = Properties.Settings.Default.UserName;
                txt_password.Text = Properties.Settings.Default.Password;
            }
        }
        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }
        public void AlertErr(string mess)
        {
            FrmThatBaiAlert frmThatBaiAlert = new FrmThatBaiAlert();
            frmThatBaiAlert.showAlert(mess);
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            if (chk_remmember.Checked == true)
            {
                Properties.Settings.Default.UserName = txt_username.Text;
                Properties.Settings.Default.Password = txt_password.Text;
                Properties.Settings.Default.Save();


            }
            else 
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Save();
            }

            // quản trị
            for (int i = 0; i < iserlogin.getlstnhanvienfromDB().Count(); i++)
            {

                if ((txt_username.Text == iserlogin.getlstnhanvienfromDB()[i].Email && iserlogin.getlstnhanvienfromDB()[i].PassWord ==iserlogin.encryption( txt_password.Text)))
                {
                    if (iserlogin.getlstnhanvienfromDB()[i].Idrole == 1 && iserlogin.getlstnhanvienfromDB()[i].Flag == false)
                    {
                        for (int a = 0; a < 2; a++)
                        {
                            this.Alert("Lần Đầu Đăng Nhập Hãy Đổi Mật Khẩu Mới Thôi Nào");
                        }
                        FrmDoiMatKhau frmDoiMatKhau = new FrmDoiMatKhau(txt_username.Text);
                        frmDoiMatKhau.Show();
                        this.Hide();
                    }
                }
                if (txt_username.Text ==Convert.ToString(iserlogin.getlstnhanvienfromDB()[i].Email)
                    && iserlogin.getlstnhanvienfromDB()[i].PassWord == iserlogin.encryption(txt_password.Text) &&
                    iserlogin.getlstnhanvienfromDB()[i].Idrole == 1 && iserlogin.getlstnhanvienfromDB()[i].Flag == true)
                {
                    //FormLoading frmLoading = new FormLoading();
                    //frmLoading.ShowDialog();
                    FrmLogin frmLogin = new FrmLogin();

                    FrmLogin.backsender.txt.Text = Convert.ToString(iserlogin.getlstnhanvienfromDB()[i].Email);
                    Image img = Image.FromFile(Convert.ToString(iserlogin.getlstnhanvienfromDB()[i].Anh));
                    FrmLogin.backsender.pic.Image = img;
                    FrmLogin.backsender.role=  Convert.ToInt32(iserlogin.getlstnhanvienfromDB()[i].Idrole);
                    FrmLogin.backsender.txt1.Text=  Convert.ToString(iserlogin.getlstnhanvienfromDB()[i].TenNhanVien);
                    if (iserlogin.getlstnhanvienfromDB()[i].Idrole == 1)
                    {
                        //FrmLogin.backsender.btnsp.Visible = false;
                        //muốn ẩn cái gì thì ẩn
                    }
            
                    frmLogin.Show();
                    for (int a = 0; a < 2; a++)
                    {
                        this.Alert("Xin Chào Quản Lý :"+" "+ iserlogin.getlstnhanvienfromDB()[i].Email);
                    }
                    this.Hide();
                    return;
                }
               
               
            }
            // nhân viên// chưa được mã hóa mật khẩu đang đợi người khác code phần thêm nhân viên
            for (int i = 0; i < iserlogin.getlstnhanvienfromDB().Count(); i++)
            {

                if ((txt_username.Text == iserlogin.getlstnhanvienfromDB()[i].Email && iserlogin.getlstnhanvienfromDB()[i].PassWord == iserlogin.encryption(txt_password.Text)))
                {
                    if (iserlogin.getlstnhanvienfromDB()[i].Idrole == 1 && iserlogin.getlstnhanvienfromDB()[i].Flag == false)
                    {
                        for (int a = 0; a < 2; a++)
                        {
                            this.Alert("Lần Đầu Đăng Nhập Hãy Đổi Mật Khẩu Mới Thôi Nào");
                        }
                        FrmDoiMatKhau  frmDoiMatKhau = new FrmDoiMatKhau(txt_username.Text);
                        frmDoiMatKhau.Show();
                        this.Hide();
                        return;
                    }
                }
                if (txt_username.Text == Convert.ToString(iserlogin.getlstnhanvienfromDB()[i].Email)
                    && iserlogin.getlstnhanvienfromDB()[i].PassWord == iserlogin.encryption(txt_password.Text) &&
                    iserlogin.getlstnhanvienfromDB()[i].Idrole == 0 && iserlogin.getlstnhanvienfromDB()[i].Flag == true)
                {
                    //FormLoading frmLoading = new FormLoading();
                    //frmLoading.ShowDialog();
                    FrmLogin frmLogin = new FrmLogin();

                    FrmLogin.backsender.txt.Text = Convert.ToString(iserlogin.getlstnhanvienfromDB()[i].Email);
                    Image img = Image.FromFile(Convert.ToString(iserlogin.getlstnhanvienfromDB()[i].Anh));
                    FrmLogin.backsender.pic.Image = img;
                    FrmLogin.backsender.role = Convert.ToInt32(iserlogin.getlstnhanvienfromDB()[i].Idrole);
                    FrmLogin.backsender.txt1.Text = Convert.ToString(iserlogin.getlstnhanvienfromDB()[i].TenNhanVien);
                    if (iserlogin.getlstnhanvienfromDB()[i].Idrole == 0)
                    {
                        FrmLogin.backsender.btnsp.Visible = false;
                        FrmLogin.backsender.btntk.Visible = false;
                        FrmLogin.backsender.btnqlnv.Visible = false;
                        FrmLogin.backsender.btnkh.Visible = false;

                      
                    }

                    frmLogin.Show();
                    for (int a = 0; a < 2; a++)
                    {
                        this.Alert("Xin Chào Nhân Viên :" + " " + iserlogin.getlstnhanvienfromDB()[i].Email);
                    }
                    this.Hide();
                    return;
                }


            }



            MessageBox.Show("Đăng Nhập Thất Bại", "Thông Báo");
            return;
        }

        private void chk_hienpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_hienpass.Checked == true)
            {
                txt_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmQuenMatKhau frmQuenMatKhau = new FrmQuenMatKhau();
            frmQuenMatKhau.Show();
            this.Hide();
        }
    }
}
