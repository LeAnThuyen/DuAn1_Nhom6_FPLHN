using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.Services;
using AForge.Video.DirectShow;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace _3_GUI_PresentaionLayers
{
    public partial class Frm_EditHangHoa : Form
    {
        #region
        private string mahh = "";
        private int id;
        private int idcthh;
        private string tenhh = "";
        private string nsx = "";
        private string danhmuc = "";
        private string trangthai = "";
        private string mavach = "";
        private string soluong = "";
        private string gianhap = "";
        private string giaban = "";
        private DateTime? ngaynhap;
        private string tenchatlieu = "";
        private string tenvatchua = "";
        private string nhomhuong = "";
        private string tennquocgia = "";
        private string sodungtich = "";
        private string anh = "";
        private DateTime? hsd;
        private string model = "";
        #endregion
        private QlyHangHoaServices _qlhhser;
        private HangHoaServices _hhser;
        private ChiTietHangHoaServices _cthhser;
        private DanhMucServices _dmser;
        private NhaSanXuatServices _nsxser;
        private NhomHuongServices _nhser;
        private DungTichServices _dtser;
        private XuatXuService _xxser;
        private VatChuaServices _vtser;
        private ChatLieuServie _clser;
        private HangHoa hh;
        private ChiTietHangHoa cthh;
        private AnhServices _imgser;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private int zen;
        private int zennsx;
        private int zendanhmuc;
        private string ok;
        public Frm_EditHangHoa(int id, int idcthh, string mahh, string tenhh, string nsx, string danhmuc, string trangthai, string mavach, string soluong,
            string gianhap, string giaban, DateTime ngaynhap, string tenchatlieu, string tenvatchua, string nhomhuong, string tenquocgia,
            string sodungtich, string anh, DateTime hsd, string model)
        {
            InitializeComponent();
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
            cthh = new ChiTietHangHoa();
            loadmahh();
            loadtenhh();
            loadanhmuc();
            loadnsx();
            loadchatlieu();
            loadvatchua();
            loadnhomhuong();
            loadquocgia();
            loadduntich();
            loaddpath();
            loadsugesstion();
            #region
            this.mahh = mahh;
            this.id = id;
            this.idcthh = idcthh;
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
            chk_conhang.Checked = trangthai == "Còn Hàng";
            chk_hethang.Checked = trangthai == "Hết Hàng";
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
            int a = Convert.ToInt32(_hhser.getlsthanghoafromDB().Where(c => c.IdhangHoa == id).Select(c => c.TrangThai).FirstOrDefault());
            if (txt_soluong.Text != "")
            {
                btn_them.Visible = false;
            }
            if (txt_soluong.Text == "")
            {
                button2.Visible = false;
            }
            
        }

        private void FrmBackView_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                cbo_webcam.Items.Add(device.Name);
            cbo_webcam.SelectedIndex = 0;

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
        #region
        private void cbo_tenquocgia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void loadmahh()
        {
            foreach (var x in _hhser.getlsthanghoafromDB())
            {
                cbo_mahh.Items.Add(x.MaHangHoa);
            }
            cbo_mahh.SelectedIndex = 0;
        }
        void loadtenhh()
        {
            foreach (var x in _hhser.getlsthanghoafromDB())
            {
                cbo_tenhh.Items.Add(x.TenHangHoa);
            }
            
        }
        void loadanhmuc()
        {
            foreach (var x in _dmser.getlstdanhmucfromDB())
            {
                cbo_danhmuc.Items.Add(x.TenDanhMuc);
            }
            cbo_danhmuc.SelectedIndex = 0;
        }
        void loadnsx()
        {
            foreach (var x in _nsxser.getlstnxsfromDB())
            {
                cbo_nsx.Items.Add(x.TenNhaSanXuat);
            }
            cbo_nsx.SelectedIndex = 0;
        }
        void loadchatlieu()
        {
            foreach (var x in _clser.getlstchatlieufromDB())
            {
                cbo_tencl.Items.Add(x.TenChatLieu);
            }
            cbo_tencl.SelectedIndex = 0;
        }
        void loadvatchua()
        {
            foreach (var x in _vtser.getlstvatchuafromDB())
            {
                cbo_tenvatchua.Items.Add(x.TenVatChua);
            }
            cbo_tenvatchua.SelectedIndex = 0;
        }
        void loadnhomhuong()
        {
            foreach (var x in _nhser.getlstnhomhuongfromDB())
            {
                cbo_tennhomhuong.Items.Add(x.TenNhomHuong);
            }
            cbo_tennhomhuong.SelectedIndex = 0;
        }
        void loadquocgia()
        {
            foreach (var x in _xxser.getlstxuatxufromDB())
            {
                cbo_tenquocgia.Items.Add(x.TenQuocGia);
            }
            cbo_tenquocgia.SelectedIndex = 0;
        }
        void loadduntich()
        {
            foreach (var x in _dtser.getlstdungtichfromDB())
            {
                cbo_soduntich.Items.Add(x.SoDungTich);
            }
            cbo_soduntich.SelectedIndex = 0;
        }
        void loaddpath()
        {
            foreach (var x in _imgser.getlstanhfromDB())
            {
                cbo_anh.Items.Add(x.DuongDan);
            }
            cbo_anh.SelectedIndex = 0;
        }
        #endregion
        private void btn_cammera_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                this.Alert("Mở Camera Thành Công");
            }
           
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbo_webcam.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            //timer1.Start();
        }
        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                txt_mavach.Invoke(new MethodInvoker(delegate ()
                {
                    txt_mavach.Text = result.ToString();
                }));
            }
            pic_cammera.Image = bitmap;
          
            
        }
      
        private void FrmBackView_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {


      
        }



        private void pic_hanghoa_DoubleClick(object sender, EventArgs e)
        {
            FrmBackView frmBackView = new FrmBackView(_hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa) + 1, "", "", "", "", "Còn Hàng", "", "", "", "", Convert.ToDateTime("08-08-2020"), "", "", "", "", "", "", Convert.ToDateTime("08-08-2020"), "");
            frmBackView.Show();


        }
       
        private void cbo_anh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img1 = Image.FromFile(cbo_anh.Text);
            pic_anhhanghoa.Image = img1;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                _qlhhser.AddSP(new HangHoa()
                {
                    IdhangHoa = _hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa) + 1,
                    TenHangHoa = cbo_tenhh.Text,
                    MaHangHoa = cbo_mahh.Text,
                    TrangThai = Convert.ToInt32(chk_conhang.Checked),
                    IddanhMuc = _dmser.getlstdanhmucfromDB().Where(c => c.TenDanhMuc == cbo_danhmuc.Text).Select(c => c.IddanhMuc).FirstOrDefault(),
                    IdnhaSanXuat = _nsxser.getlstnxsfromDB().Where(c => c.TenNhaSanXuat == cbo_nsx.Text).Select(c => c.IdnhaSanXuat).FirstOrDefault()
                });


                _qlhhser.AddSpChiTiet(new ChiTietHangHoa()
                {
                    IdthongTinHangHoa = _cthhser.getlstchitietthanghoafromDB().Max(c => c.IdthongTinHangHoa) + 1,
                    SoLuong = txt_soluong.Text,
                    DonGiaNhap = Convert.ToDouble(txt_gianhap.Text),
                    DonGiaBan = Convert.ToDouble(txt_giaban.Text),
                    HanSuDung = dtp_hsd.Value,
                    Model = txt_model.Text,
                    NgayNhapKho = dtp_ngaynhap.Value,
                    TrangThai = Convert.ToInt32(chk_conhang.Checked),
                    IdchatLieu = _clser.getlstchatlieufromDB().Where(c => c.TenChatLieu == cbo_tencl.Text).Select(c => c.IdchatLieu).FirstOrDefault(),
                    IdnhomHuong = _nhser.getlstnhomhuongfromDB().Where(c => c.TenNhomHuong == cbo_tennhomhuong.Text).Select(c => c.IdnhomHuong).FirstOrDefault(),
                    IdhangHoa = _hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa) + 1,
                    IdquocGia = _xxser.getlstxuatxufromDB().Where(c => c.TenQuocGia == cbo_tenquocgia.Text).Select(c => c.IdquocGia).FirstOrDefault(),
                    IddungTich = _dtser.getlstdungtichfromDB().Where(c => c.SoDungTich == Convert.ToDouble(cbo_soduntich.Text)).Select(c => c.IddungTich).FirstOrDefault(),
                    Idanh = _imgser.getlstanhfromDB().Where(c => c.DuongDan == cbo_anh.Text).Select(c => c.Idanh).FirstOrDefault(),
                    IdvatChua = _vtser.getlstvatchuafromDB().Where(c => c.TenVatChua == cbo_tenvatchua.Text).Select(c => c.IdvatChua).FirstOrDefault(),
                    Mavach = txt_mavach.Text.Trim()
                }); 
                _qlhhser.SaveHangHoa(hh);
                _qlhhser.SaveChiTietHangHoa(cthh);
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Thêm Thành Công");

                }
                return;
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("bạn có muốn sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                hh.IdhangHoa = id;
                hh.MaHangHoa = cbo_mahh.Text;
                hh.TenHangHoa = cbo_tenhh.Text;
                hh.IdnhaSanXuat = _nsxser.getlstnxsfromDB().Where(c => c.TenNhaSanXuat == cbo_nsx.Text).Select(c => c.IdnhaSanXuat).FirstOrDefault();
                hh.TrangThai = Convert.ToInt32(chk_conhang.Checked);
                hh.IddanhMuc = _dmser.getlstdanhmucfromDB().Where(c => c.TenDanhMuc == cbo_danhmuc.Text).Select(c => c.IddanhMuc).FirstOrDefault();
                cthh.IdthongTinHangHoa = idcthh;
                cthh.SoLuong = txt_soluong.Text;
                cthh.Mavach = txt_mavach.Text.Trim();
                cthh.DonGiaNhap = Convert.ToInt32(txt_gianhap.Text);
                cthh.DonGiaBan = Convert.ToInt32(txt_giaban.Text);
                cthh.HanSuDung = dtp_hsd.Value;
                cthh.Model = txt_model.Text;
                cthh.NgayNhapKho = dtp_ngaynhap.Value;
                cthh.TrangThai = Convert.ToInt32(chk_conhang.Checked);
                cthh.IdchatLieu = _clser.getlstchatlieufromDB().Where(c => c.TenChatLieu == cbo_tencl.Text).Select(c => c.IdchatLieu).FirstOrDefault();
                cthh.IdnhomHuong = _nhser.getlstnhomhuongfromDB().Where(c => c.TenNhomHuong == cbo_tennhomhuong.Text).Select(c => c.IdnhomHuong).FirstOrDefault();
                cthh.IdhangHoa = id;
                cthh.IdquocGia = _xxser.getlstxuatxufromDB().Where(c => c.TenQuocGia == cbo_tenquocgia.Text).Select(c => c.IdquocGia).FirstOrDefault();
                cthh.Idanh = _imgser.getlstanhfromDB().Where(c => c.DuongDan == cbo_anh.Text).Select(c => c.Idanh).FirstOrDefault();
                cthh.IdvatChua = _vtser.getlstvatchuafromDB().Where(c => c.TenVatChua == cbo_tenvatchua.Text).Select(c => c.IdvatChua).FirstOrDefault();
                cthh.IddungTich = _dtser.getlstdungtichfromDB().Where(c => c.SoDungTich == Convert.ToDouble(cbo_soduntich.Text)).Select(c => c.IddungTich).FirstOrDefault();
                _qlhhser.UpdateSP(hh);
                _qlhhser.UpdateSPChiTiet(cthh);
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Đã Xác Nhận Cập Nhật Nếu Đồng Ý Hãy Tiến Hành Lưu");

                }
                return;
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn lưu lại những thay đổi hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                _qlhhser.SaveHangHoa(hh);
                _qlhhser.SaveChiTietHangHoa(cthh);
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Lưu Thành Công");

                }
                return;
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void chk_conhang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_conhang.Checked)
            {

                chk_hethang.Checked = false;
            }
        }

        private void chk_hethang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_hethang.Checked)
            {

                chk_conhang.Checked = false;
            }
        }
        public bool zenbarcode()
        {

            for (int i = 0; i < _cthhser.getlstchitietthanghoafromDB().Count; i++)
            {
                if (_cthhser.getlstchitietthanghoafromDB()[i].Mavach == txt_mavach.Text)
                {
                    DialogResult dialogResult = MessageBox.Show("Mã Vạch Này Đã Tồn Tại Trong Hệ Thống ! Bạn Có Muốn Sử Dụng 1 Số Thuộc Tính Của Nó Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        zen = Convert.ToInt32(_cthhser.getlstchitietthanghoafromDB().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.IdhangHoa).FirstOrDefault());
                        cbo_tenhh.Text = Convert.ToString(_hhser.getlsthanghoafromDB().Where(c => c.IdhangHoa == zen).Select(c => c.TenHangHoa).FirstOrDefault());
                        zendanhmuc = Convert.ToInt32(_hhser.getlsthanghoafromDB().Where(c => c.IdhangHoa == zen).Select(c => c.IddanhMuc).FirstOrDefault());
                        zennsx = Convert.ToInt32(_hhser.getlsthanghoafromDB().Where(c => c.IdhangHoa == zen).Select(c => c.IdnhaSanXuat).FirstOrDefault());
                        cbo_danhmuc.Text = Convert.ToString(_dmser.getlstdanhmucfromDB().Where(c => c.IddanhMuc == zendanhmuc).Select(c => c.TenDanhMuc).FirstOrDefault());
                        cbo_nsx.Text = Convert.ToString(_nsxser.getlstnxsfromDB().Where(c => c.IdnhaSanXuat == zennsx).Select(c => c.TenNhaSanXuat).FirstOrDefault());
                        txt_giaban.Text = Convert.ToString(_cthhser.getlstchitietthanghoafromDB().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.DonGiaBan).FirstOrDefault());
                        txt_gianhap.Text = Convert.ToString(_cthhser.getlstchitietthanghoafromDB().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.DonGiaNhap).FirstOrDefault());
                        for (int a = 0; a < 2; a++)
                        {
                            this.Alert("Sử Dụng Thành Công");
                        }

                        return true;
                    };

                    if (dialogResult == DialogResult.No)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
        private void txt_mavach_TextChanged(object sender, EventArgs e)
        {
            if (zenbarcode() == true)
            {

                return;
            }
        }

        private void pic_exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                FormSanPham formSanPham = new FormSanPham();

                formSanPham.loaddata();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Chào Mừng Bạn Đến Với PerSoft Perfume <3");

                }
                return;
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
          
        }
       
       
        private void cbo_tenhh_TextChanged(object sender, EventArgs e)
        {
           

        }
        public void loadsugesstion()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=TANA\\SQLEXPRESS;Initial Catalog=duan1;Persist Security Info=True;User ID=thuyen;Password=123";

            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("select TenHangHoa FROM HangHoa", connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlDataReader dr = sqlCommand.ExecuteReader();

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
           
            while (dr.Read())
            {
                col.Add(dr.GetString(0));
            }


            cbo_tenhh.AutoCompleteCustomSource = col;
            connection.Close();
        }
        private void cbo_tenhh_KeyUp(object sender, KeyEventArgs e)
        {
           for(int i = 0; i < _hhser.getlsthanghoafromDB().Count; i++)
            {
                if(cbo_tenhh.Text== _hhser.getlsthanghoafromDB()[i].TenHangHoa)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tái Sử Dụng 1 Số Thuộc Tính Cơ Bản Của Sản Phầm Cùng Tên Này Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        zen = Convert.ToInt32(_hhser.getlsthanghoafromDB().Where(c => c.TenHangHoa == cbo_tenhh.Text).Select(c => c.IddanhMuc).FirstOrDefault());
                        zendanhmuc = Convert.ToInt32(_hhser.getlsthanghoafromDB().Where(c => c.TenHangHoa == cbo_tenhh.Text).Select(c => c.IdhangHoa).FirstOrDefault());


                        zennsx = Convert.ToInt32(_hhser.getlsthanghoafromDB().Where(c => c.TenHangHoa == tenhh).Select(c => c.IdnhaSanXuat).FirstOrDefault());
                        cbo_danhmuc.Text = Convert.ToString(_dmser.getlstdanhmucfromDB().Where(c => c.IddanhMuc == zen).Select(c => c.TenDanhMuc).FirstOrDefault());
                        cbo_nsx.Text = Convert.ToString(_nsxser.getlstnxsfromDB().Where(c => c.IdnhaSanXuat == zennsx).Select(c => c.TenNhaSanXuat).FirstOrDefault());
                        txt_giaban.Text = Convert.ToString(_cthhser.getlstchitietthanghoafromDB().Where(c => c.IdhangHoa == zendanhmuc).Select(c => c.DonGiaBan).FirstOrDefault());
                        txt_gianhap.Text = Convert.ToString(_cthhser.getlstchitietthanghoafromDB().Where(c => c.IdhangHoa == zendanhmuc).Select(c => c.DonGiaNhap).FirstOrDefault());
                        txt_model.Text = Convert.ToString(_cthhser.getlstchitietthanghoafromDB().Where(c => c.IdhangHoa == zendanhmuc).Select(c => c.Model).FirstOrDefault());
                        for (int a = 0; a < 2; a++)
                        {
                            this.Alert("Bạn Đã Sử Dụng Thành Công");

                        }
                        return;
                    };

                    if (dialogResult == DialogResult.No)
                    {
                        for (int a = 0; a < 2; a++)
                        {
                            this.AlertErr(" Sử Dụng Thất Bại");

                        }
                        return;
                    }

                }
            }
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {

          
        }

      
    }
    
}
