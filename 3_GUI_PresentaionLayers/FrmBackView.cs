using _1_DAL_DataAccessLayer.DALServices;
using _2_BUS_BussinessLayer.Services;
using AForge.Video.DirectShow;
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
using ZXing;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmBackView : Form
    {
        #region
        private string mahh = "";
        private int id ;
        private string tenhh = "";
        private string nsx = "";
        private string danhmuc = "";
        private string trangthai="" ;
        private string mavach = "";
        private string soluong ="";
        private string gianhap ="";
        private string giaban ="";
        private DateTime? ngaynhap;
        private string tenchatlieu = "";
        private string tenvatchua = "";
        private string nhomhuong = "";
        private string tennquocgia = "";
        private string sodungtich = "";
        private string anh = "";
        private DateTime? hsd ;
        private string model = "";
        #endregion
        private QlyHangHoaServices _qlhhser;
        private HangHoaServices _hhser;
        private ChiTietHangHoaServices _cthhser;
     

        public FrmBackView(int id,string mahh,string tenhh, string nsx,string danhmuc, string trangthai, string mavach,string soluong,
           string gianhap, string giaban,DateTime ngaynhap, string tenchatlieu, string tenvatchua, string nhomhuong, string tenquocgia,
           string sodungtich, string anh, DateTime hsd, string model)
        {
            InitializeComponent();
            #region
            this.mahh = mahh;
            this.id = id;
            this.tenhh = tenhh;
            this.nsx = nsx;
            this.danhmuc = danhmuc;
            this.trangthai = trangthai;
            this.mavach = mavach;
            this.soluong = soluong;
            this.gianhap = gianhap;
            this.giaban = giaban;
            this.ngaynhap = ngaynhap;
            this.tenchatlieu = tenchatlieu;
            this.tenvatchua = tenvatchua;
            this.nhomhuong = nhomhuong;
            this.tennquocgia = tenquocgia;
            this.sodungtich = sodungtich;
            this.anh = anh;
            this.hsd = hsd;
            this.model = model;
            cbo_mahh.Text = mahh;
            cbo_tenhh.Text = tenhh;
            cbo_nsx.Text = nsx;
            cbo_danhmuc.Text = danhmuc;
            chk_conhang.Checked =trangthai=="Còn Hàng";
            chk_hethang.Checked =trangthai=="Hết Hàng";
            txt_mavach.Text = mavach;
            txt_soluong.Text = soluong;
            txt_gianhap.Text = gianhap;
            txt_giaban.Text = giaban;
            dtp_ngaynhap.Value = ngaynhap;
            cbo_tencl.Text = tenchatlieu;
            cbo_tenvatchua.Text = tenvatchua;
            cbo_tennhomhuong.Text = nhomhuong;
            cbo_tenquocgia.Text = tenquocgia;
            cbo_soduntich.Text = sodungtich;
            cbo_anh.Text = anh;
            dtp_hsd.Value = hsd;
            txt_model.Text = model;
            #endregion
            _qlhhser = new QlyHangHoaServices();
            _hhser = new HangHoaServices();
            _cthhser = new ChiTietHangHoaServices();

            Image img1 = Image.FromFile(cbo_anh.Text);
            pic_anhhanghoa.Image = img1;

        }

        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }

        private void FrmBackView_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

       

       
        private void pic_hanghoa_DoubleClick(object sender, EventArgs e)
        {
            Frm_EditHangHoa frm_EditHangHoa = new Frm_EditHangHoa(_hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa) + 1, "", "", "", "", "Còn Hàng", "", "", "", "", Convert.ToDateTime("08-08-2020"), "", "", "", "", "", "", Convert.ToDateTime("08-08-2020"),"");
            frm_EditHangHoa.Show();
            this.Alert("Hãy Thêm Mới 1 Sản Phẩm Thôi Nào !");
            // this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        private void cbo_anh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img1 = Image.FromFile(cbo_anh.Text);
            pic_anhhanghoa.Image = img1;
        }

       
    }
}
