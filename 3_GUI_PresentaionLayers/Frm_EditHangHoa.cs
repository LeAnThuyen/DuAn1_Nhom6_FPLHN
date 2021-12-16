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
using System.Text.RegularExpressions;
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
            //loadmahh();
            //loadtenhh();
            //loadanhmuc();
            //loadnsx();
            //loadchatlieu();
            //loadvatchua();
            //loadnhomhuong();
            //loadquocgia();
            //loadduntich();
            //loaddpath();
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

        public bool check()
        {
            if (string.IsNullOrEmpty(cbo_mahh.Text))
            {
                MessageBox.Show("mã hàng hóa không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(cbo_mahh.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("Mã Hàng Hóa không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbo_mahh.Text))
            {
                MessageBox.Show("mã hàng hóa không được có khoảng trắng", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cbo_tenhh.Text))
            {
                MessageBox.Show("Tên hàng hóa không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(cbo_tenhh.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("Tên hàng hóa không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if (string.IsNullOrEmpty(cbo_tencl.Text))
            {
                MessageBox.Show("Tên chất liệu không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_soluong.Text))
            {
                MessageBox.Show("Số lượng không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_soluong.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("Số lượng không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_soluong.Text))
            {
                MessageBox.Show("Số lượng không được có khoảng trắng", "Thông báo");
                return false;
            }
            if (Convert.ToInt32( txt_soluong.Text)<=0 && Convert.ToInt32(txt_soluong.Text) > 2000)
            {
                MessageBox.Show("Số lượng không được âm hoặc nhỏ hơn không và phải nhỏ hơn 2000", "Thông báo");
                return false;
            }

            if (string.IsNullOrEmpty(txt_gianhap.Text))
            {
                MessageBox.Show("giá nhập không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_gianhap.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("giá nhập không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if(Convert.ToInt32( txt_gianhap.Text)> Convert.ToInt32(txt_giaban.Text))
            {
                MessageBox.Show("giá nhập không được lớn hơn giá bán", "ERR");
                return false;
            }
            if (Convert.ToInt32(txt_gianhap.Text) <=0 && Convert.ToInt32(txt_gianhap.Text)<50000000)
            {
                MessageBox.Show("giá nhập phải lơn hơn 0 và nhỏ hơn 50000000", "ERR");
                return false;
            }
            if (string.IsNullOrEmpty(txt_giaban.Text))
            {
                MessageBox.Show("giá bán không được bỏ trống", "Thông báo");
                return false;
            }
            if (Convert.ToInt32(txt_giaban.Text) <= 0 && Convert.ToInt32(txt_giaban.Text) < 100000000)
            {
                MessageBox.Show("giá bán phải lơn hơn 0 và nhỏ hơn 100000000", "ERR");
                return false;
            }
            //
            if (cbo_mahh.Text.Length <= 3 && cbo_mahh.Text.Length >= 10)
            {
                MessageBox.Show("Mã nước hoa phải trên 3 ký tự và nhỏ hơn 10 kí tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_mahh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã nước hoa Bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_giaban.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("giá bán không được chứa ký tự đặc biệt", "ERR");
                return false;
            }

            //check trùng
            //danh mục





            //macl
            if (cbo_tencl.Text.Length <= 3)
            {
                MessageBox.Show("Tên chất liệu nước hóa phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_mahh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã nước hoa Bắt buộc phải chứa số", "ERR");
                return false;
            }


            //tên
            if (cbo_tenhh.Text.Length <= 3)
            {
                MessageBox.Show("Tên hàng hóa phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_tenhh.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên hàng hóa không được chứa số", "ERR");
                return false;
            }


            if (Regex.IsMatch(txt_soluong.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số số lượng  không được chứa chữ cái", "ERR");
                return false;
            }

            if (Regex.IsMatch(txt_gianhap.Text, @"^\d+$") == false)
            {

                MessageBox.Show("đơn giá nhập không được chứa chữ cái", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_giaban.Text, @"^\d+$") == false)
            {

                MessageBox.Show("đơn giá bán không được chứa chữ cái", "ERR");
                return false;
            }
            //danh mục
            if (cbo_danhmuc.Text.Length <= 3)
            {
                MessageBox.Show("Tên danh mục phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_danhmuc.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên danh mục không được chứa số", "ERR");
                return false;
            }
            //nhà sản xuất
            if (cbo_nsx.Text.Length <= 3)
            {
                MessageBox.Show("Tên Nhà Sản Xuất phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_nsx.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Nhà Sản Xuất không được chứa số", "ERR");
                return false;
            }
            //chất liệu
            if (cbo_tencl.Text.Length <= 3)
            {
                MessageBox.Show("Tên Chất Liệu phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_tencl.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Chất Liệu  không được chứa số", "ERR");
                return false;
            }
            //vật chứa
            if (cbo_tenvatchua.Text.Length <= 3)
            {
                MessageBox.Show("Tên Vật Chứa phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_tenvatchua.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Vật Chứa  không được chứa số", "ERR");
                return false;
            }
            // nhóm hương
            if (cbo_tennhomhuong.Text.Length <= 3)
            {
                MessageBox.Show("Tên Nhóm Hương phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_tennhomhuong.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Nhóm Hương  không được chứa số", "ERR");
                return false;
            }
            //quốc gia
            if (cbo_tenquocgia.Text.Length <= 3)
            {
                MessageBox.Show("Tên Quốc Gia phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_tenquocgia.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Quốc Gia  không được chứa số", "ERR");
                return false;
            }
            // dung tích
            if (Regex.IsMatch(cbo_soduntich.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số dung tích không được chứa chữ cái", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_soduntich.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("số dung tích không được chứa ký tự đặc biệt", "ERR");
                return false;
            }




            return true;
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
         
        }
        public void loadtenhh()
        {
            foreach (var x in _hhser.getlsthanghoafromDB())
            {
                cbo_tenhh.Items.Add(x.TenHangHoa);
            }
            
        }
       public void loadanhmuc()
        {
            foreach (var x in _dmser.getlstdanhmucfromDB())
            {
                cbo_danhmuc.Items.Add(x.TenDanhMuc);
            }
            cbo_danhmuc.SelectedIndex = 0;
        }
        public void loadnsx()
        {
            foreach (var x in _nsxser.getlstnxsfromDB())
            {
                cbo_nsx.Items.Add(x.TenNhaSanXuat);
            }
            cbo_nsx.SelectedIndex = 0;
        }
        public void loadchatlieu()
        {
            foreach (var x in _clser.getlstchatlieufromDB())
            {
                cbo_tencl.Items.Add(x.TenChatLieu);
            }
            cbo_tencl.SelectedIndex = 0;
        }
        public void loadvatchua()
        {
            foreach (var x in _vtser.getlstvatchuafromDB())
            {
                cbo_tenvatchua.Items.Add(x.TenVatChua);
            }
            cbo_tenvatchua.SelectedIndex = 0;
        }
        public void loadnhomhuong()
        {
            foreach (var x in _nhser.getlstnhomhuongfromDB())
            {
                cbo_tennhomhuong.Items.Add(x.TenNhomHuong);
            }
            cbo_tennhomhuong.SelectedIndex = 0;
        }
        public void loadquocgia()
        {
            foreach (var x in _xxser.getlstxuatxufromDB())
            {
                cbo_tenquocgia.Items.Add(x.TenQuocGia);
            }
            cbo_tenquocgia.SelectedIndex = 0;
        }
        public void loadduntich()
        {
            foreach (var x in _dtser.getlstdungtichfromDB())
            {
                cbo_soduntich.Items.Add(x.SoDungTich);
            }
            cbo_soduntich.SelectedIndex = 0;
        }
        public void loaddpath()
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
            FrmBackView frmBackView = new FrmBackView(_hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa) + 1,_cthhser.getlstchitietthanghoafromDB().Max(c=>c.IdthongTinHangHoa)+1 ,"", "", "", "", "Còn Hàng", "", "", "", "", Convert.ToDateTime("08-08-2020"), "", "", "", "", "", "", Convert.ToDateTime("08-08-2020"), "");
            frmBackView.Show();


        }
       
        private void cbo_anh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img1 = Image.FromFile(cbo_anh.Text);
            pic_anhhanghoa.Image = img1;
        }
        void reset()
        {
            cbo_mahh.Text = Convert.ToString("HHPS" + Convert.ToInt32(_hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa) + 1));
            cbo_tenhh.Text = "";
            txt_mavach.Text = "";
            txt_soluong.Text = "";
            txt_giaban.Text = "";
            txt_gianhap.Text = "";
            txt_model.Text = "";
        }
        private void btn_them_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

               if (dialogResult == DialogResult.Yes)
                {
                   

                    if (_cthhser.getlstchitietthanghoafromDB().Any(c => c.Mavach == txt_mavach.Text) == true)
                    {
                        MessageBox.Show("Mã  Vạch Đã tồn Tại yêu cầu nhập mã khác", "ERR");
                        return;
                    }

                    if (_dmser.getlstdanhmucfromDB().Any(c => c.TenDanhMuc == cbo_danhmuc.Text) == false)
                    {
                        MessageBox.Show("Tên Danh Mục Không Hợp Lệ", "ERR");
                        return;
                    }

                    // nhà sản xuất

                    if (_nsxser.getlstnxsfromDB().Any(c => c.TenNhaSanXuat == cbo_nsx.Text) == false)
                    {
                        MessageBox.Show("Tên Nhà Sản Xuất Không Hợp Lệ", "ERR");
                        return;
                    }

                    //chất kiệu

                    if (_clser.getlstchatlieufromDB().Any(c => c.TenChatLieu == cbo_tencl.Text) == false)
                    {
                        MessageBox.Show("Tên Chất Liệu Không Hợp Lệ", "ERR");
                        return;
                    }

                    //ảnh

                    if (_imgser.getlstanhfromDB().Any(c => c.DuongDan == cbo_anh.Text) == false)
                    {
                        MessageBox.Show("Dường Dẫn Không Hợp Lệ", "ERR");
                        return;

                    }
                        //vật chứa

                        if (_vtser.getlstvatchuafromDB().Any(c => c.TenVatChua == cbo_tenvatchua.Text) == false)
                        {
                            MessageBox.Show("Tên Vật Chứa Không Hợp Lệ", "ERR");
                            return;
                        }

                        // nhóm hương
                        if (_nhser.getlstnhomhuongfromDB().Any(c => c.TenNhomHuong == cbo_tennhomhuong.Text) == false)
                        {
                            MessageBox.Show("Tên Nhóm Hương Không Hợp Lệ", "ERR");
                            return;
                        }

                        //dung tích

                        if (_dtser.getlstdungtichfromDB().Any(c => c.SoDungTich == Convert.ToDouble(cbo_soduntich.Text)) == false)
                        {
                            MessageBox.Show(" Số Dung Tích Không Hợp Lệ", "ERR");
                            return;
                        }

                        // quốc gia

                        if (_xxser.getlstxuatxufromDB().Any(c => c.TenQuocGia == cbo_tenquocgia.Text) == false)
                        {
                            MessageBox.Show("Tên Quốc Gia Không Hợp Lệ", "ERR");
                            return;
                        }


                        if (check() == false)
                        {
                            return;
                        }
                        _qlhhser.AddSP(new HangHoa()
                        {
                            IdhangHoa = _hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa) + 1,
                            TenHangHoa = cbo_tenhh.Text,
                            MaHangHoa = cbo_mahh.Text,
                            TrangThai = Convert.ToInt32(chk_conhang.Checked),
                            IddanhMuc = _dmser.getlstdanhmucfromDB().Where(c => c.TenDanhMuc == cbo_danhmuc.Text).Select(c => c.IddanhMuc).FirstOrDefault(),
                            IdnhaSanXuat = _nsxser.getlstnxsfromDB().Where(c => c.TenNhaSanXuat == cbo_nsx.Text).Select(c => c.IdnhaSanXuat).FirstOrDefault()
                        });
                        _qlhhser.SaveHangHoa(hh);

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
                            IdhangHoa = _hhser.getlsthanghoafromDB().Max(c => c.IdhangHoa),
                            IdquocGia = _xxser.getlstxuatxufromDB().Where(c => c.TenQuocGia == cbo_tenquocgia.Text).Select(c => c.IdquocGia).FirstOrDefault(),
                            IddungTich = _dtser.getlstdungtichfromDB().Where(c => c.SoDungTich == Convert.ToDouble(cbo_soduntich.Text)).Select(c => c.IddungTich).FirstOrDefault(),
                            Idanh = _imgser.getlstanhfromDB().Where(c => c.DuongDan == cbo_anh.Text).Select(c => c.Idanh).FirstOrDefault(),
                            IdvatChua = _vtser.getlstvatchuafromDB().Where(c => c.TenVatChua == cbo_tenvatchua.Text).Select(c => c.IdvatChua).FirstOrDefault(),
                            Mavach = txt_mavach.Text.Trim()
                        });

                        _qlhhser.SaveChiTietHangHoa(cthh);
                    reset();
                        for (int i = 0; i < 2; i++)
                        {
                            this.Alert("Thêm Thành Công");

                        }

                    };

                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                
                if (dialogResult == DialogResult.Yes)
                {
                    if (_cthhser.getlstchitietthanghoafromDB().Any(c => c.Mavach == txt_mavach.Text) == true)
                    {
                        MessageBox.Show("Mã  Vạch Đã tồn Tại yêu cầu nhập mã khác", "ERR");
                        return;
                    }

                    if (_dmser.getlstdanhmucfromDB().Any(c => c.TenDanhMuc == cbo_danhmuc.Text) == false)
                    {
                        MessageBox.Show("Tên Danh Mục Không Hợp Lệ", "ERR");
                        return;
                    }

                    // nhà sản xuất

                    if (_nsxser.getlstnxsfromDB().Any(c => c.TenNhaSanXuat == cbo_nsx.Text) == false)
                    {
                        MessageBox.Show("Tên Nhà Sản Xuất Không Hợp Lệ", "ERR");
                        return;
                    }

                    //chất kiệu

                    if (_clser.getlstchatlieufromDB().Any(c => c.TenChatLieu == cbo_tencl.Text) == false)
                    {
                        MessageBox.Show("Tên Chất Liệu Không Hợp Lệ", "ERR");
                        return;
                    }

                    //ảnh

                    if (_imgser.getlstanhfromDB().Any(c => c.DuongDan == cbo_anh.Text) == false)
                    {
                        MessageBox.Show("Dường Dẫn Không Hợp Lệ", "ERR");
                        return;

                    }
                    //vật chứa

                    if (_vtser.getlstvatchuafromDB().Any(c => c.TenVatChua == cbo_tenvatchua.Text) == false)
                    {
                        MessageBox.Show("Tên Vật Chứa Không Hợp Lệ", "ERR");
                        return;
                    }

                    // nhóm hương
                    if (_nhser.getlstnhomhuongfromDB().Any(c => c.TenNhomHuong == cbo_tennhomhuong.Text) == false)
                    {
                        MessageBox.Show("Tên Nhóm Hương Không Hợp Lệ", "ERR");
                        return;
                    }

                    //dung tích

                    if (_dtser.getlstdungtichfromDB().Any(c => c.SoDungTich == Convert.ToDouble(cbo_soduntich.Text)) == false)
                    {
                        MessageBox.Show(" Số Dung Tích Không Hợp Lệ", "ERR");
                        return;
                    }

                    // quốc gia

                    if (_xxser.getlstxuatxufromDB().Any(c => c.TenQuocGia == cbo_tenquocgia.Text) == false)
                    {
                        MessageBox.Show("Tên Quốc Gia Không Hợp Lệ", "ERR");
                        return;
                    }


                    if (check() == false)
                    {
                        return;
                    }

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

                };

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
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
                // FormSanPham formSanPham = new FormSanPham();

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Hide();

              
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Chào Mừng Bạn Đến Với PerSoft Perfume <3");

                }
              
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
            connection.ConnectionString = "Data Source=TANA\\SQLEXPRESS;Initial Catalog=dcmmm;Persist Security Info=True;User ID=thuyen;Password=123";

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

        private void pic_mavach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mã Vạch Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FrmCreateNewBarCode frmCreateNewBarCode = new FrmCreateNewBarCode(id, Convert.ToInt32(_cthhser.getlstchitietthanghoafromDB().Where(c => c.IdhangHoa == id).Select(c => c.IdhangHoa).FirstOrDefault()), cbo_mahh.Text, cbo_tenhh.Text, cbo_nsx.Text, cbo_danhmuc.Text, trangthai, mavach, txt_soluong.Text, txt_gianhap.Text, txt_giaban.Text, dtp_ngaynhap.Value, cbo_tencl.Text, cbo_tenvatchua.Text, cbo_tennhomhuong.Text, cbo_tenquocgia.Text, cbo_soduntich.Text, cbo_anh.Text, dtp_hsd.Value, txt_model.Text);
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mã Vạch Thôi Nào");

                    }
                    frmCreateNewBarCode.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr(" Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;

            }
          
      

        }

        private void pic_danhmuc_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới Danh Mục Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FrmDanhMuc frmDanhMuc = new FrmDanhMuc();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Danh Mục Thôi Nào");

                    }
                    frmDanhMuc.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr(" Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;

            }
        }

        private void pic_anhadd_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới ảnh Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FrmAnh frmanh = new FrmAnh();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Ảnh  Thôi Nào");

                    }
                        frmanh.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;

            }
        }

        private void pic_cl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới Chất Liệu Chính Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FormChatLieu  formChatLieu = new FormChatLieu();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Chất Liệu Chính Thôi Nào");

                    }
                    formChatLieu.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;

            }
        }

        private void pic_vt_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới Vật Chứa Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FrmVatChua frmVatChua  = new FrmVatChua();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Vật Chứa Thôi Nào");

                    }
                    frmVatChua.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;

            }
        }

        private void pic_nhomhuong_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới Mùi Hương Chủ Đạo Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frmnhomhuong frmnhomhuong  = new Frmnhomhuong();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Mới Mùi Hương Chủ Đạo Thôi Nào");

                    }
                    frmnhomhuong.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;

            }
        }

        private void pic_xuatxu_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới Xuất Xứ Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FormXuatXu formXuatXu  = new FormXuatXu();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Xuất Xứ Thôi Nào");

                    }
                    formXuatXu.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;

            }
        }

        private void pic_dungtich_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới Dung Tích Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FormDungTich formDungTich  = new FormDungTich();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Xuất Xứ Thôi Nào");

                    }
                    formDungTich.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Thuyên");
                return;

            }
        }

        private void cbo_danhmuc_Click(object sender, EventArgs e)
        {
            loadanhmuc();
        }

        private void cbo_nsx_Click(object sender, EventArgs e)
        {
            loadnsx();
        }

        private void cbo_anh_Click(object sender, EventArgs e)
        {
            loaddpath();
        }

        private void cbo_tencl_Click(object sender, EventArgs e)
        {
            loadchatlieu();
        }

        private void cbo_tenvatchua_Click(object sender, EventArgs e)
        {
            loadvatchua();
        }

        private void cbo_tennhomhuong_Click(object sender, EventArgs e)
        {
            loadnhomhuong();
        }

        private void cbo_tenquocgia_Click(object sender, EventArgs e)
        {
            loadquocgia();
        }

        private void cbo_soduntich_Click(object sender, EventArgs e)
        {
            loadduntich();
        }
    }
    
}
