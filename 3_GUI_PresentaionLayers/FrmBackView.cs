using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.Models;
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
using System.Drawing.Printing;
using ZXing;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmBackView : Form
    {
        #region
        private string mahh = "";
        private int id ;
        private int idhh ;
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
     
        private ChiTietHangHoaServices _cthhser;
        private string a="";
        private QlyHangHoaServices _qlhhser;
  
    
        private DanhMucServices _dmser;
        private NhaSanXuatServices _nsxser;
        private HangHoaServices _hhser;
        private NhomHuongServices _nhser;
        private DungTichServices _dtser;
        private XuatXuService _xxser;
        private VatChuaServices _vtser;
        private ChatLieuServie _clser;
        private HangHoa hh;
        private ChiTietHangHoa cthh;
        private AnhServices _imgser;

        public FrmBackView(int id,int idhh,string mahh,string tenhh, string nsx,string danhmuc, string trangthai, string mavach,string soluong,
           string gianhap, string giaban,DateTime ngaynhap, string tenchatlieu, string tenvatchua, string nhomhuong, string tenquocgia,
           string sodungtich, string anh, DateTime hsd, string model)
        {
            InitializeComponent();
            #region
            this.mahh = mahh;
            this.id = id;
            this.idhh = idhh;
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
            //_qlhhser = new QlyHangHoaServices();
            //_hhser = new HangHoaServices();
            //_cthhser = new ChiTietHangHoaServices();
            _qlhhser = new QlyHangHoaServices();
            _hhser = new HangHoaServices();
            _cthhser = new ChiTietHangHoaServices();
            _dmser = new DanhMucServices();
            _nsxser = new NhaSanXuatServices();
            _nhser = new NhomHuongServices();
            _dtser = new DungTichServices();
            _xxser = new XuatXuService();
            _vtser = new VatChuaServices();
            _clser = new ChatLieuServie();
            _imgser = new AnhServices();

            hh = new HangHoa();

            Image img1 = Image.FromFile(cbo_anh.Text);
            pic_anhhanghoa.Image = img1;

        }
        private void chk_conhang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_conhang.Checked)
            {
                a = Convert.ToString(chk_conhang.Text);
                chk_hethang.Checked = false;
            }
        }

        private void chk_hethang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_hethang.Checked)
            {
                a = Convert.ToString(chk_hethang.Text);
                chk_conhang.Checked = false;
            }
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
            Frm_EditHangHoa frm_EditHangHoa = new Frm_EditHangHoa(_hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa) + 1,0 ,Convert.ToString( "HHPS"+Convert.ToInt32( _hhser.getlsthanghoafromDB().Max(c=>c.IdhangHoa)+1)), "", "", "", "Còn Hàng", "", "", "", "", Convert.ToDateTime("08-08-2020"), "", "", "", "", "", "", Convert.ToDateTime("08-08-2020"),"");
            for (int i = 0; i < 1; i++)
            {
                this.Alert("Hãy Thêm Mới 1 Sản Phẩm Thôi Nào !");
            }
            frm_EditHangHoa.Show();
           
            this.Close();
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        private void cbo_anh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img1 = Image.FromFile(cbo_anh.Text);
            pic_anhhanghoa.Image = img1;
        }

      

        private void pic_updatehh_DoubleClick(object sender, EventArgs e)
        {
        
           
            Frm_EditHangHoa frm_EditHangHoa = new Frm_EditHangHoa(id,idhh,mahh
               ,
               tenhh,
               nsx,
               danhmuc,a,mavach+" ",
                soluong,
                gianhap,
                giaban,
                dtp_ngaynhap.Value,tenchatlieu,
                tenvatchua,
               nhomhuong,
                tennquocgia,
               sodungtich,anh,
                dtp_hsd.Value,
                model);
            for (int i = 0; i < 1; i++)
            {
                this.Alert("Tiến Hành Cập Nhật !");
            }
            frm_EditHangHoa.Show();
            this.Close();
           


        }

       

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn xóa hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                hh.IdhangHoa = id;
                hh.MaHangHoa = cbo_mahh.Text;
                hh.TenHangHoa = cbo_tenhh.Text;
                hh.IdnhaSanXuat = _nsxser.getlstnxsfromDB().Where(c => c.TenNhaSanXuat == cbo_nsx.Text).Select(c => c.IdnhaSanXuat).FirstOrDefault();
                hh.TrangThai =0;
                hh.IddanhMuc = _dmser.getlstdanhmucfromDB().Where(c => c.TenDanhMuc == cbo_danhmuc.Text).Select(c => c.IddanhMuc).FirstOrDefault();           
                _qlhhser.UpdateSP(hh);
                _qlhhser.SaveHangHoa(hh);
               
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Xóa Thành Công");

                }
               
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }

      

        private void pic_mavach_DoubleClick(object sender, EventArgs e)
        {
            FrmCreateNewBarCode frmCreateNewBarCode = new FrmCreateNewBarCode(id,Convert.ToInt32( _cthhser.getlstchitietthanghoafromDB().Where(c=>c.IdhangHoa==id).Select(c=>c.IdhangHoa).FirstOrDefault()), cbo_mahh.Text, cbo_tenhh.Text, cbo_nsx.Text, cbo_danhmuc.Text, trangthai, mavach, txt_soluong.Text, txt_gianhap.Text, txt_giaban.Text, dtp_ngaynhap.Value, cbo_tencl.Text, cbo_tenvatchua.Text, cbo_tennhomhuong.Text, cbo_tenquocgia.Text, cbo_soduntich.Text, cbo_anh.Text, dtp_hsd.Value, txt_model.Text);
            for (int i = 0; i < 1; i++)
            {
                this.Alert("Tiến Hành Tạo Mã Vạch Thôi Nào");

            }
            frmCreateNewBarCode.Show();
       
           
           
        }

        private void pic_hanghoa_Click(object sender, EventArgs e)
        {

        }

        private void pic_mavach_Click(object sender, EventArgs e)
        {

        }

        private void pic_danhmuc_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pic_nsx_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pic_anhadd_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pic_cl_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pic_vt_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pic_nhomhuong_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pic_xuatxu_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pic_dungtich_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
