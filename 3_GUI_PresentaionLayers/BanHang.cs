using _2_BUS_BussinessLayer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using AForge.Video.DirectShow;
using ZXing;
using System.Threading;
using _1_DAL_DataAccessLayer.DALServices;
using FormatException = System.FormatException;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _3_GUI_PresentaionLayers
{
    public partial class BanHang : Form
    {
        private IQlyHoaDon _iQlyHoaDon;
        private IQLyBanHang iQLyBanHang;
        private IQlyHangHoa _iQlyHangHoa;
        private List<HoaDonBan> _lstHoaDonBans;
        private List<HoaDonChiTiet> _lstHoaDonChiTiets;
        private IQlyKhachHang _iQlyKhachHang;
        private IQlyNhanVien _iQlyNhanVien;
        private IServicesHoaDonChiTiet _hdctser;
        private IServicesHoaDon _hdser;
        private IKhachHangServices _ikhser;
        private IServicesNhanVien _invser;
        private ISendPoint _iSendPoint;
        private int IDHH;
        private int status;
        private int statusdt;
        private ChiTietHangHoa cthh;
        private HoaDonBan hoadon;
        int flag = -1;
        private float tongtien = 0;
        private HoaDonChiTiet hdct;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public BanHang()
        {
            InitializeComponent();
            _iQlyHoaDon = new QlyHoaDonServices();
            iQLyBanHang = new QLyBanHangServices();
            _iQlyHangHoa = new QlyHangHoaServices();
            _iQlyNhanVien = new QlyNhanVienServices();
            _iQlyKhachHang = new QLyKhachHangServices();
            _lstHoaDonBans = new List<HoaDonBan>();
            _lstHoaDonChiTiets = new List<HoaDonChiTiet>();
            _hdser = new HoaDonBanServices();
            _hdctser = new HoaDonChiTietServices();
            hdct = new HoaDonChiTiet();
            _ikhser = new KhachHangService();
            _invser = new NhanVienServices();
            _iSendPoint = new SendPointServices();
            LoadData();
            LoadHDCT();
            dgrid_sanpham.AllowUserToAddRows = false;
            cthh = new ChiTietHangHoa();
            hoadon = new HoaDonBan();

            this.dgrid_sanpham.DefaultCellStyle.ForeColor = Color.Black;
            this.dgridGioHang.DefaultCellStyle.ForeColor = Color.Black;
            LoadCbxNV();
            LoadCbxKH();
            // btnDathang.Hide();
            pn_dathang.Visible = false;
            css();
            LoadCbxRank();
            loadhoadonduyet();
            loadhoadonduyet3();
            dcmmm();
            txtMaHDD.Visible = false;
            //txtMaHDD.Hide();
            rbt_chuathanhtoan.Checked = true;
            rbt_dathangchuathanhtoan.Checked = true;
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

        private void button8_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 2; i++)
            //{
            //    this.Alert("Mở Camera Thành Công");
            //}

            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbo_webcam.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }


        void css()
        {
            label11.AutoSize = false;
            label11.Height = 2;
            label11.BorderStyle = BorderStyle.Fixed3D;
            label12.AutoSize = false;
            label12.Height = 2;
            label12.BorderStyle = BorderStyle.Fixed3D;
            label13.AutoSize = false;
            label13.Height = 2;
            label13.BorderStyle = BorderStyle.Fixed3D;
        }

        void LoadData()
        {
            dgrid_sanpham.ColumnCount = 8;
            dgrid_sanpham.Columns[0].Name = "ID";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "IDHHCT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[2].Name = "Mã sản phẩm";
            dgrid_sanpham.Columns[3].Name = "Tên sản phẩm";
            dgrid_sanpham.Columns[4].Name = "Đơn giá";
            dgrid_sanpham.Columns[5].Name = "Tồn kho";
            dgrid_sanpham.Columns[6].Name = "IDHD";
            dgrid_sanpham.Columns[6].Visible = false;
            dgrid_sanpham.Columns[7].Name = "Đường Dẫn";
            dgrid_sanpham.Columns[7].Visible = false;


            dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQlyHangHoa.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                    x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                    x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.SoLuong, x.Anh.DuongDan, x.Anh.DuongDan);
            }

            



        }

        void LoadCbxKH()
        {
            foreach (var x in _iQlyKhachHang.GetsListKH())
            {
                cbxKH.Items.Add(x.TenKhachHang);
            }
        }

        void LoadCbxRank()
        {
            cbxRank.Items.Add("Bạc");
            cbxRank.Items.Add("Vàng");
            cbxRank.Items.Add("Kim cương");
            cbxRank.SelectedIndex = 0;
        }

        void LoadCbxNV()
        {
            foreach (var x in _iQlyNhanVien.GetsList())
            {
                cbxNV.Items.Add(x.NhanVien.TenNhanVien);
            }
        }

        void LoadHDCT()
        {
            dgridGioHang.ColumnCount = 6;
            dgridGioHang.Columns[0].Name = "ID";
            dgridGioHang.Columns[0].Visible = false;
            dgridGioHang.Columns[1].Name = "Mã sản phẩm";
            dgridGioHang.Columns[2].Name = "Tên sản phẩm";
            dgridGioHang.Columns[3].Name = "Số lượng";
            dgridGioHang.Columns[4].Name = "Đơn giá";
            dgridGioHang.Columns[5].Name = "Thành tiền";
            dgridGioHang.Rows.Clear();

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Xác nhận";
            buttonColumn.Text = "Sửa";
            buttonColumn.Name = "Sửa";
            buttonColumn.UseColumnTextForButtonValue = true;

            dgridGioHang.Columns.Add(buttonColumn);
        }

        void dcmmm()
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Ảnh";
            img.Name = "img_sp";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgrid_sanpham.Columns.Add(img);
            //dgrid_sanpham.Columns["IDHD"].Width = 200;
            //dgrid_sanpham.RowTemplate.Height = 80;
            //
            for (int i = 0; i < dgrid_sanpham.RowCount; i++)
            {
                Image img1 = Image.FromFile(Convert.ToString(dgrid_sanpham.Rows[i].Cells["Đường Dẫn"].Value));

                dgrid_sanpham.Rows[i].Cells["img_sp"].Value = img1;

            }
        }

        void dcmmm1()
        {
            if (InvokeRequired) // Line #1
            {
                this.Invoke(new MethodInvoker(dcmmm1));
                return;
            }

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Ảnh";
            img.Name = "img_sp";
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgrid_sanpham.Columns.Add(img);
            //dgrid_sanpham.Columns["IDHD"].Width = 200;
            //dgrid_sanpham.RowTemplate.Height = 80;
            //
            for (int i = 0; i < dgrid_sanpham.RowCount; i++)
            {
                Image img1 = Image.FromFile(Convert.ToString(dgrid_sanpham.Rows[i].Cells["Đường Dẫn"].Value));

                dgrid_sanpham.Rows[i].Cells["img_sp"].Value = img1;

            }
        }

        void acd()
        {
            if (InvokeRequired) // Line #1
            {
                this.Invoke(new MethodInvoker(acd));
                return;
            }

            dgridGioHang.ColumnCount = 6;
            dgridGioHang.Columns[0].Name = "ID";
            dgridGioHang.Columns[0].Visible = false;
            dgridGioHang.Columns[1].Name = "Mã sản phẩm";
            dgridGioHang.Columns[2].Name = "Tên sản phẩm";
            dgridGioHang.Columns[3].Name = "Số lượng";
            dgridGioHang.Columns[4].Name = "Đơn giá";
            dgridGioHang.Columns[5].Name = "Thành tiền";
            dgridGioHang.Rows.Clear();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Xác nhận";
            buttonColumn.Text = "Sửa";
            buttonColumn.Name = "Sửa";
            buttonColumn.UseColumnTextForButtonValue = true;

            dgridGioHang.Columns.Add(buttonColumn);
            foreach (var x in _lstHoaDonChiTiets)
            {
                dgridGioHang.Rows.Add(x.IdhoaDonChiTiet,
                    _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                        .Select(c => c.HangHoa.MaHangHoa).FirstOrDefault(),
                    _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                        .Select(c => c.HangHoa.TenHangHoa).FirstOrDefault() + " " +
                    _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == x.IdthongTinHangHoa)
                        .Select(c => c.ChiTietHangHoa.Model).FirstOrDefault(), x.SoLuong,

                    x.DonGia, x.SoLuong * x.DonGia);
            }

            int count = dgridGioHang.Rows.Count;
            tongtien = 0;
            for (int i = 0; i < count - 1; i++)
            {
                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString()); //i++;
            }

            txtTongTien.Text = Convert.ToString(tongtien);

            //
            dgrid_sanpham.ColumnCount = 8;
            dgrid_sanpham.Columns[0].Name = "ID";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "IDHHCT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[2].Name = "Mã sản phẩm";
            dgrid_sanpham.Columns[3].Name = "Tên sản phẩm";
            dgrid_sanpham.Columns[4].Name = "Đơn giá";
            dgrid_sanpham.Columns[5].Name = "Tồn kho";
            dgrid_sanpham.Columns[6].Name = "IDhD";
            dgrid_sanpham.Columns[6].Visible = false;
            dgrid_sanpham.Columns[7].Name = "Đường Dẫn";
            dgrid_sanpham.Columns[7].Visible = false;

            dgrid_sanpham.Rows.Clear();
            var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
            foreach (var x in _iQlyHangHoa.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                    x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                    x.ChiTietHangHoa.DonGiaBan,
                    Convert.ToInt32(x.ChiTietHangHoa.SoLuong) - Convert.ToInt32(_lstHoaDonChiTiets
                        .Where(c => c.IdthongTinHangHoa == x.ChiTietHangHoa.IdthongTinHangHoa).Select(c => c.SoLuong)
                        .LastOrDefault()), idlhd, x.Anh.DuongDan);
            }

            dcmmm1();
            int count1 = dgridGioHang.Rows.Count;
            tongtien = 0;
            for (int i = 0; i < count1 - 1; i++)
            {
                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
         txtTongTien.Text= Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
         txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);

        }

        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap) eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            pic_cam.Image = bitmap;

            if (result != null)
            {
                if (Convert.ToString(result) == _iQlyHangHoa.GetsList()
                    .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                    .Select(c => c.ChiTietHangHoa.Mavach).FirstOrDefault())
                {



                    string content = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm", "Thêm Vào Giỏ Hàng", "0",
                        500, 300);

                    if (content != "")
                    {
                        if (Convert.ToInt32(content) < Convert.ToInt32(_iQlyHangHoa.GetsList()
                            .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                            .Select(c => c.ChiTietHangHoa.SoLuong).FirstOrDefault()))
                        {
                            int countHDCT = _iQlyHoaDon.GetsListHDCT().Max(x => x.IdhoaDonChiTiet) + 1;
                            HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                            {
                                IdhoaDonChiTiet = countHDCT,
                                MaHoaDonChiTiet = "HDCT000" + countHDCT,
                                DonGia = _iQlyHangHoa.GetsList()
                                    .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                                    .Select(c => c.ChiTietHangHoa.DonGiaBan).FirstOrDefault(),
                                
                                SoLuong = Convert.ToInt32(content),
                                IdthongTinHangHoa = _iQlyHangHoa.GetsList()
                                    .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                                    .Select(c => c.ChiTietHangHoa.IdthongTinHangHoa).FirstOrDefault(),
                                TrangThai = 1,
                                IdhoaDon = iQLyBanHang.GetsList().Max(c => c.HoaDonBan.IdhoaDon),
                                ThanhTien = Convert.ToDouble(Convert.ToInt32(content) * (_iQlyHangHoa.GetsList()
                                    .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                                    .Select(c => c.ChiTietHangHoa.DonGiaBan).FirstOrDefault()))
                            };
                            _iQlyHoaDon.addHDCT(hoaDonChiTiet);
                            _iQlyHoaDon.SaveHDCT();
                            _lstHoaDonChiTiets.Add(hoaDonChiTiet);

                    //        IdhoaDonChiTiet = countHDCT,
                    //MaHoaDonChiTiet = "HDCT000" + countHDCT,
                    //DonGia = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()),
                    //SoLuong = 1,
                    //IdthongTinHangHoa = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()),
                    //TrangThai = 1,
                    //IdhoaDon = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()),
                    //ThanhTien = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[4].Value.ToString())
                            result = null;
                            acd();

                            // pic_cam.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Sản Phẩm Không Đủ Để Thêm", "Noticafition");

                        }

                        pic_cam.Image = null;
                    }

                    result = null;

                }

                pic_cam.Image = null;

            }



        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void tbDark_CheckedChanged_1(object sender, EventArgs e)
        {
            if (tbDark.Checked)
            {
                this.BackColor = Color.RosyBrown;

            }
            else
            {
                this.BackColor = Color.DarkOliveGreen;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label17.Text = DateTime.Now.ToLongDateString();
        }


        private void BanHang_Load(object sender, EventArgs e)
        {
            //    var row = dgrid_sanpham.Rows;
            //    dgrid_sanpham.Rows[e.RowIndex].Cells["img_sp"].Value = Image.FromFile(Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells["Dường Dẫn"].Value));

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                cbo_webcam.Items.Add(device.Name);
            cbo_webcam.SelectedIndex = 0;
            dgridGioHang.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgridGioHang.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgridGioHang.RowHeadersVisible = false;
            dgrid_sanpham.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgrid_sanpham.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgrid_sanpham.RowHeadersVisible = false;

        }

        private void dgridGioHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            var Dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (Dialog == DialogResult.No)
            {
                return;
            }

            var id = _iQlyHangHoa.GetsList()
                .Where(x => x.HangHoa.MaHangHoa == dgridGioHang.Rows[row].Cells[1].Value.ToString())
                .Select(x => x.HangHoa.IdhangHoa).FirstOrDefault();
            var hoadon = _lstHoaDonChiTiets.FirstOrDefault(x =>
                x.IdthongTinHangHoa == Convert.ToInt32(id));
            _lstHoaDonChiTiets.Remove(hoadon);
            _iQlyHoaDon.removeHDCT(hoadon);
            _iQlyHoaDon.SaveHDCT();
            var Cthh = _iQlyHangHoa.GetsListCTHH().FirstOrDefault(x => x.IdthongTinHangHoa == IDHH);
            Cthh.SoLuong =
                Convert.ToString(
                    Convert.ToInt32(_iQlyHangHoa.GetsListCTHH().Where(x => x.IdthongTinHangHoa == IDHH)
                        .Select(x => x.SoLuong).FirstOrDefault()) -
                    Convert.ToInt32(dgridGioHang.Rows[row].Cells[3].Value.ToString()));
            _iQlyHangHoa.UpdateSPChiTiet(Cthh);
            _iQlyHangHoa.SaveChiTietHangHoa(Cthh);
            dgridGioHang.ColumnCount = 6;
            dgridGioHang.Columns[0].Name = "ID";
            dgridGioHang.Columns[0].Visible = false;
            dgridGioHang.Columns[1].Name = "Mã sản phẩm";
            dgridGioHang.Columns[2].Name = "Tên sản phẩm";
            dgridGioHang.Columns[3].Name = "Số lượng";
            dgridGioHang.Columns[4].Name = "Đơn giá";
            dgridGioHang.Columns[5].Name = "Thành tiền";
            dgridGioHang.Rows.Clear();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Xác nhận";
            buttonColumn.Text = "Sửa";
            buttonColumn.Name = "Sửa";
            buttonColumn.UseColumnTextForButtonValue = true;

            dgridGioHang.Columns.Add(buttonColumn);
            foreach (var x in _lstHoaDonChiTiets)
            {
                dgridGioHang.Rows.Add(x.IdhoaDonChiTiet,
                    _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                        .Select(c => c.HangHoa.MaHangHoa).FirstOrDefault(),
                    _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                        .Select(c => c.HangHoa.TenHangHoa).FirstOrDefault() + " " +
                    _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == x.IdthongTinHangHoa)
                        .Select(c => c.ChiTietHangHoa.Model).FirstOrDefault(), x.SoLuong,

                    x.DonGia, x.SoLuong * x.DonGia);
            }

            int count = dgridGioHang.Rows.Count;
            tongtien = 0;
            for (int i = 0; i < count - 1; i++)
            {
                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString()); //i++;
            }

            txtTongTien.Text = Convert.ToString(tongtien);
            dgrid_sanpham.ColumnCount = 8;
            dgrid_sanpham.Columns[0].Name = "ID";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "IDHHCT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[2].Name = "Mã sản phẩm";
            dgrid_sanpham.Columns[3].Name = "Tên sản phẩm";
            dgrid_sanpham.Columns[4].Name = "Đơn giá";
            dgrid_sanpham.Columns[5].Name = "Tồn kho";
            dgrid_sanpham.Columns[6].Name = "IDHD";
            dgrid_sanpham.Columns[6].Visible = false;
            dgrid_sanpham.Columns[7].Name = "Đường Dẫn";
            dgrid_sanpham.Columns[7].Visible = false;

            dgrid_sanpham.Rows.Clear();
            var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
            foreach (var x in _iQlyHangHoa.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                    x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                    x.ChiTietHangHoa.DonGiaBan,
                    Convert.ToInt32(x.ChiTietHangHoa.SoLuong) + Convert.ToInt32(_lstHoaDonChiTiets
                        .Where(c => c.IdthongTinHangHoa == x.ChiTietHangHoa.IdthongTinHangHoa).Select(c => c.SoLuong)
                        .LastOrDefault()), idlhd, x.Anh.DuongDan);
            }

            dcmmm();
        }

        bool checkSoluong(int x)
        {
            if (x < 1)
            {
                MessageBox.Show("Sản phẩm trong kho không đủ vui lòng chọn sản phẩm khác", "Thông báo");
                return false;
            }


            return true;
        }

        private void dgrid_sanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (checkSoluong(Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value.ToString())) == false) return;

            int countHDCT = _iQlyHoaDon.GetsListHDCT().Max(x => x.IdhoaDonChiTiet) + 1;
            if (_lstHoaDonChiTiets.Where(x =>
                    x.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())).Select(
                    x => x.IdthongTinHangHoa).FirstOrDefault() !=
                Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()))
            {
                IDHH = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString());
                HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                {
                    IdhoaDonChiTiet = countHDCT,
                    MaHoaDonChiTiet = "HDCT000" + countHDCT,
                    DonGia = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()),
                    SoLuong = 1,
                    IdthongTinHangHoa = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()),
                    TrangThai = 1,
                    IdhoaDon = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()),
                    ThanhTien = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[4].Value.ToString())
                };
                var Cthh = _iQlyHangHoa.GetsListCTHH().FirstOrDefault(x => x.IdthongTinHangHoa == IDHH);
                Cthh.SoLuong = Convert.ToString(Convert.ToInt32(_iQlyHangHoa.GetsListCTHH()
                    .Where(x => x.IdthongTinHangHoa == IDHH).Select(x => x.SoLuong).FirstOrDefault()) - 1);
                _iQlyHangHoa.UpdateSPChiTiet(Cthh);
                _iQlyHangHoa.SaveChiTietHangHoa(Cthh);
                _iQlyHoaDon.addHDCT(hoaDonChiTiet);
                _iQlyHoaDon.SaveHDCT();
                _lstHoaDonChiTiets.Add(hoaDonChiTiet);

                dgridGioHang.ColumnCount = 6;
                dgridGioHang.Columns[0].Name = "ID";
                dgridGioHang.Columns[0].Visible = false;
                dgridGioHang.Columns[1].Name = "Mã sản phẩm";
                dgridGioHang.Columns[2].Name = "Tên sản phẩm";
                dgridGioHang.Columns[3].Name = "Số lượng";
                dgridGioHang.Columns[4].Name = "Đơn giá";
                dgridGioHang.Columns[5].Name = "Thành tiền";
                dgridGioHang.Rows.Clear();
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Xác nhận";
                buttonColumn.Text = "Sửa";
                buttonColumn.Name = "Sửa";
                buttonColumn.UseColumnTextForButtonValue = true;

                dgridGioHang.Columns.Add(buttonColumn);

                foreach (var x in _lstHoaDonChiTiets)
                {
                    dgridGioHang.Rows.Add(x.IdhoaDonChiTiet,
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.MaHangHoa).FirstOrDefault(),
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.TenHangHoa).FirstOrDefault() + " " +
                        _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.ChiTietHangHoa.Model).FirstOrDefault(), x.SoLuong,

                        x.DonGia, x.SoLuong * x.DonGia);
                }

                dgrid_sanpham.ColumnCount = 8;
                dgrid_sanpham.Columns[0].Name = "ID";
                dgrid_sanpham.Columns[0].Visible = false;
                dgrid_sanpham.Columns[1].Name = "IDHHCT";
                dgrid_sanpham.Columns[1].Visible = false;
                dgrid_sanpham.Columns[2].Name = "Mã sản phẩm";
                dgrid_sanpham.Columns[3].Name = "Tên sản phẩm";
                dgrid_sanpham.Columns[4].Name = "Đơn giá";
                dgrid_sanpham.Columns[5].Name = "Tồn kho";
                dgrid_sanpham.Columns[6].Name = "IDhD";
                dgrid_sanpham.Columns[6].Visible = false;
                dgrid_sanpham.Columns[7].Name = "Đường Dẫn";
                dgrid_sanpham.Columns[7].Visible = false;

                dgrid_sanpham.Rows.Clear();
                var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
                foreach (var x in _iQlyHangHoa.GetsList())
                {
                    dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                        x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                        x.ChiTietHangHoa.DonGiaBan, Convert.ToInt32(x.ChiTietHangHoa.SoLuong), idlhd, x.Anh.DuongDan);
                }

                dcmmm();
                int count = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                }

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);

            }
            else
            {
                IDHH = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString());
                int countHDCT2 = _lstHoaDonChiTiets.Max(x => x.IdhoaDonChiTiet) + 1;
                HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                {
                    IdhoaDonChiTiet = countHDCT2,
                    MaHoaDonChiTiet = "HDCT000" + countHDCT2,
                    DonGia = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()),
                    SoLuong = _lstHoaDonChiTiets
                        .Where(x => x.IdthongTinHangHoa ==
                                    Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()))
                        .Select(x => x.SoLuong).LastOrDefault() + 1,
                    IdthongTinHangHoa = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()),
                    TrangThai = 1,
                    IdhoaDon = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()),
                    ThanhTien = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()) * (_lstHoaDonChiTiets
                        .Where(x => x.IdthongTinHangHoa ==
                                    Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()))
                        .Select(x => x.SoLuong).LastOrDefault() + 1)
                };

                var hoadon = _lstHoaDonChiTiets.FirstOrDefault(x =>
                    x.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())
                    && x.IdhoaDon == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()));
                _lstHoaDonChiTiets.Remove(hoadon);
                _lstHoaDonChiTiets.Add(hoaDonChiTiet);
                var hoadon2 = _iQlyHoaDon.GetsListHDCT().FirstOrDefault(x =>
                    x.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())
                    && x.IdhoaDon == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()));
                var hdct = _lstHoaDonChiTiets.FirstOrDefault(x =>
                    x.IdhoaDon == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()));
                //var hdct = _iQlyHoaDon.GetsListHDCT().FirstOrDefault(x =>
                //    x.IdhoaDonChiTiet == _iQlyHoaDon.GetsListHDCT().Where(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())).Select(c => c.IdhoaDonChiTiet).FirstOrDefault());
                hoadon2.ThanhTien = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()) * (_lstHoaDonChiTiets
                    .Where(x => x.IdthongTinHangHoa ==
                                Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()))
                    .Select(x => x.SoLuong).LastOrDefault());
                hoadon2.SoLuong = _lstHoaDonChiTiets
                    .Where(x => x.IdthongTinHangHoa ==
                                Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()))
                    .Select(x => x.SoLuong).LastOrDefault();
                var Cthh = _iQlyHangHoa.GetsListCTHH().FirstOrDefault(x => x.IdthongTinHangHoa == IDHH);
                Cthh.SoLuong = Convert.ToString(Convert.ToInt32(_iQlyHangHoa.GetsListCTHH()
                    .Where(x => x.IdthongTinHangHoa == IDHH).Select(x => x.SoLuong).FirstOrDefault()) - 1);
                _iQlyHangHoa.UpdateSPChiTiet(Cthh);
                _iQlyHangHoa.SaveChiTietHangHoa(Cthh);
                _iQlyHoaDon.updateHDCTV(hoadon2);
                _iQlyHoaDon.SaveHDCT();

                dgridGioHang.ColumnCount = 6;
                dgridGioHang.Columns[0].Name = "ID";
                dgridGioHang.Columns[0].Visible = false;
                dgridGioHang.Columns[1].Name = "Mã sản phẩm";
                dgridGioHang.Columns[2].Name = "Tên sản phẩm";
                dgridGioHang.Columns[3].Name = "Số lượng";
                dgridGioHang.Columns[4].Name = "Đơn giá";
                dgridGioHang.Columns[5].Name = "Thành tiền";
                dgridGioHang.Rows.Clear();
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Xác nhận";
                buttonColumn.Text = "Sửa";
                buttonColumn.Name = "Sửa";
                buttonColumn.UseColumnTextForButtonValue = true;

                dgridGioHang.Columns.Add(buttonColumn);
                foreach (var x in _lstHoaDonChiTiets)
                {
                    dgridGioHang.Rows.Add(x.IdhoaDonChiTiet,
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.MaHangHoa).FirstOrDefault(),
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.TenHangHoa).FirstOrDefault() + " " +
                        _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.ChiTietHangHoa.Model).FirstOrDefault(), x.SoLuong,

                        x.DonGia, x.SoLuong * x.DonGia);
                }

                dgrid_sanpham.ColumnCount = 8;
                dgrid_sanpham.Columns[0].Name = "ID";
                dgrid_sanpham.Columns[0].Visible = false;
                dgrid_sanpham.Columns[1].Name = "IDHHCT";
                dgrid_sanpham.Columns[1].Visible = false;
                dgrid_sanpham.Columns[2].Name = "Mã sản phẩm";
                dgrid_sanpham.Columns[3].Name = "Tên sản phẩm";
                dgrid_sanpham.Columns[4].Name = "Đơn giá";
                dgrid_sanpham.Columns[5].Name = "Tồn kho";
                dgrid_sanpham.Columns[6].Name = "IDhD";
                dgrid_sanpham.Columns[6].Visible = false;
                dgrid_sanpham.Columns[7].Name = "Đường Dẫn";
                dgrid_sanpham.Columns[7].Visible = false;

                dgrid_sanpham.Rows.Clear();
                var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
                foreach (var x in _iQlyHangHoa.GetsList())
                {
                    dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                        x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                        x.ChiTietHangHoa.DonGiaBan,
                        Convert.ToInt32(x.ChiTietHangHoa.SoLuong), idlhd, x.Anh.DuongDan);
                }

                dcmmm();
                int count = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString()); //i++;
                }

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                txtTongTien.Text =Convert.ToString( Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat));
                txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
            }

        }

        bool checkdiem(string diem)
        {
            int iddtd = Convert.ToInt32(_iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                .Select(x => x.IddiemTieuDung).FirstOrDefault());
            if (string.IsNullOrEmpty(txtDiscount.Text))
            {
                return true;
            }

            if (Convert.ToDouble(txtDiscount.Text) > _iQlyKhachHang.GetsListDTD().Where(x => x.IddiemTieuDung == iddtd)
                .Select(x => x.SoDiem).FirstOrDefault())
            {
                MessageBox.Show("Số điểm của khách hàng không đủ, Số điểm hiện tại là: " + _iQlyKhachHang.GetsListDTD()
                    .Where(x => x.IddiemTieuDung == iddtd)
                    .Select(x => x.SoDiem).FirstOrDefault(), "Thông báo");
                return false;
            }

            return true;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult =
                MessageBox.Show("bạn có muốn thanh toán hay không", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int iddtd = Convert.ToInt32(_iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                    .Select(x => x.IddiemTieuDung).FirstOrDefault());
                string tt = Convert.ToString(txtTongTien.Text);
                txtTongTien.Text = tt.Replace(".", "");
                float tien = float.Parse(txtTongTien.Text);
                if (checkdiem(txtDiscount.Text) == true)
                {

                }
                else
                {
                    if (checkdiem(txtMaHDD.Text) == false) return;
                }

                if (cbxKH.Text == _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                    .Select(x => x.TenKhachHang).FirstOrDefault())
                {
                    if (_iQlyKhachHang.GetsListDTD().Where(x => x.IddiemTieuDung == iddtd).Select(x => x.TrangThai)
                        .FirstOrDefault() == 0)
                    {
                        var diemtieudung = _iQlyKhachHang.GetsListDTD().FirstOrDefault(x => x.IddiemTieuDung == iddtd);
                        diemtieudung.SoDiem = (tien < 100000 ? tien * 0.0002 :
                            tien < 500000 ? tien * 0.0001 :
                            tien < 1000000 ? tien * 0.00012 :
                            tien < 5000000 ? tien * 0.00013 : tien * 0.00015) + Convert.ToDouble(_iQlyKhachHang
                            .GetsListDTD()
                            .Where(x => x.IddiemTieuDung == iddtd)
                            .Select(x => x.SoDiem).LastOrDefault());
                        _iQlyKhachHang.updateDiemTD(diemtieudung);
                        _iQlyKhachHang.SaveDTD(diemtieudung);
                        _iSendPoint.SendMail2(txtEmail.Text, tien < 100000 ? tien * 0.0002 :
                            tien < 500000 ? tien * 0.0001 :
                            tien < 1000000 ? tien * 0.00012 :
                            tien < 5000000 ? tien * 0.00013 : tien * 0.00015, Convert.ToDouble(_iQlyKhachHang
                                .GetsListDTD()
                                .Where(x => x.IddiemTieuDung == iddtd)
                                .Select(x => x.SoDiem).LastOrDefault()));
                    }

                }



                if (!string.IsNullOrEmpty(txtDiscount.Text))
                {
                    LichSuTieuDungDiem lichSuTieuDungDiem = new LichSuTieuDungDiem()
                    {
                        IdhoaDon = Convert.ToInt32(txtMaHDD.Text),
                        TrangThai = 1,
                        IdlichSuDiem = _iQlyKhachHang.GetsListLS().Max(x => x.IdlichSuDiem) + 1,
                        NgaySuDung = DateTime.Now,
                        SoDiemTieu = Convert.ToDouble(txtDiscount.Text),
                        IddiemTieuDung = _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                            .Select(x => x.IddiemTieuDung).FirstOrDefault()
                    };
                    var diemtieudung = _iQlyKhachHang.GetsListDTD().FirstOrDefault(x => x.IddiemTieuDung == iddtd);
                    diemtieudung.SoDiem = Convert.ToDouble(_iQlyKhachHang.GetsListDTD()
                        .Where(x => x.IddiemTieuDung == iddtd)
                        .Select(x => x.SoDiem).LastOrDefault()) - Convert.ToDouble(txtDiscount.Text);
                    _iQlyKhachHang.updateDiemTD(diemtieudung);
                    _iQlyKhachHang.SaveDTD(diemtieudung);
                    _iQlyKhachHang.addLichSu(lichSuTieuDungDiem);
                    _iQlyKhachHang.SaveLichSU(lichSuTieuDungDiem);
                    _iSendPoint.SendMail(txtEmail.Text, tien < 100000 ? 20 :
                        tien < 500000 ? 50 :
                        tien < 1000000 ? 100 :
                        tien < 5000000 ? 200 : 500, Convert.ToDouble(txtDiscount.Text), Convert.ToDouble(_iQlyKhachHang
                            .GetsListDTD()
                            .Where(x => x.IddiemTieuDung == iddtd)
                            .Select(x => x.SoDiem).LastOrDefault()));
                }

                //
                if (rbt_dathanhtoan.Checked)
                {
                    status = 1;
                }

                if (rbt_dacoc.Checked)
                {
                    status = 0;
                }

                if (rbt_chuathanhtoan.Checked)
                {
                    status = 2;
                }

                if (rbt_chogiaohang.Checked)
                {
                    status = 3;
                }

                if (rbt_dahuy.Checked)
                {
                    status = 4;
                }
                string aa = Convert.ToString(txtKhachTra.Text);
                string fn = aa.Replace(".", "");
                string bb = Convert.ToString(txtTongTien.Text);
                string fn1 = bb.Replace(".", "");

                hoadon = _iQlyHoaDon.GetsListHD().FirstOrDefault(x => x.IdhoaDon == Convert.ToInt32(txtMaHDD.Text));
                hoadon.TrangThai = Convert.ToInt32(status);
                hoadon.NgayLap = DateTime.Now;
                hoadon.MaHoaDon = _iQlyHoaDon.GetsListHD().Where(c => c.IdhoaDon == hoadon.IdhoaDon)
                    .Select(c => c.MaHoaDon).FirstOrDefault();
                hoadon.IdkhachHang = _ikhser.getlstkhachhangformDB().Where(c => c.Email == txtEmail.Text)
                    .Select(c => c.IdkhachHang).FirstOrDefault();
                hoadon.Iduser = _invser.getlstnhanvienfromDB().Where(c => c.TenNhanVien == cbxNV.Text)
                    .Select(c => c.Iduser).FirstOrDefault();


                hoadon.Tien = float.Parse(fn1);
                hoadon.TongSoTien = float.Parse(fn);
                hoadon.Thue = Convert.ToDouble(textBox2.Text);
                int id = _iQlyKhachHang.GetsListKH().Where(c => c.Email == txtEmail.Text).Select(c => c.IdkhachHang)
                    .FirstOrDefault();
                hoadon.IdkhachHang = id;
                hoadon.NgayLap = DateTime.Now;
                hoadon.GhiChu = Convert.ToString(richTextBox1.Text);
                _hdser.updatehdb(hoadon);
                _hdser.save();

                try
                {
                    int max = _hdser.getlsthdbfromDB().Max(c => c.IdhoaDon);
                    //var update = _iQlyHoaDon.GetsListHDCT()
                    //    .FirstOrDefault(x => x.IdhoaDon == Convert.ToInt32(txtMaHDD.Text));
                    //var _lstPrice = (from a in _iQlyHoaDon.GetsListHDCT()
                    //    where a.IdhoaDon == max
                    //    select a).ToList();
                
                    foreach (var x in _hdctser.getlsthdctfromDB().Where(c=>c.IdhoaDon==max))
                    {
                        string gg =Convert.ToString( textBox2.Text);
                        string cc = gg.Replace(".", "");
                        x.GiamGia = Convert.ToDouble(cc);
                        _hdctser.updatehdct(x);
                        _hdctser.save();
                    }


                


                    loadhoadonduyet(); //IDHHCT
                    loadhoadonduyet3(); //IDHHCT
                    
                }
                catch (FormatException FormatException)
                {
                    Console.WriteLine(FormatException);
                }

                //
                //
                dgridGioHang.ColumnCount = 6;
                dgridGioHang.Columns[0].Name = "ID";
                dgridGioHang.Columns[0].Visible = false;
                dgridGioHang.Columns[1].Name = "Mã sản phẩm";
                dgridGioHang.Columns[2].Name = "Tên sản phẩm";
                dgridGioHang.Columns[3].Name = "Số lượng";
                dgridGioHang.Columns[4].Name = "Đơn giá";
                dgridGioHang.Columns[5].Name = "Thành tiền";
                dgridGioHang.Rows.Clear();

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Xác nhận";
                buttonColumn.Text = "Sửa";
                buttonColumn.Name = "Sửa";
                buttonColumn.UseColumnTextForButtonValue = true;

                dgridGioHang.Columns.Add(buttonColumn);
                if (ckbIn.Checked == false)
                {

                }
                else
                {
                    inHoaDon();
                }

                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Thanh Toán Thành Công");
                }
                clear();
                return;

            }

            if (dialogResult == DialogResult.No)
            {
                return;
            }



        }

        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[]
                {"không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"};
            string[] placeValues = new string[] {"", "nghìn", "triệu", "tỷ"};
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length; // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }

                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }

                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }

                    result = " " + result;
                }
            }

            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }

        private void txtKhachDua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal a, b;
                a = Decimal.Parse(txtTongTien.Text);
                b = Decimal.Parse(txtKhachDua.Text);
                txtTienthua.Text = (b - a).ToString();
            }
        }

        private void btnsender_Click(object sender, EventArgs e)
        {

            dgridGioHang.Rows.Clear();
            int acbc = ((sender as Button).Tag as HoaDonBan).IdhoaDon;
            dgridGioHang.ColumnCount = 6;
            dgridGioHang.Columns[0].Name = "IDHDCT";
            dgridGioHang.Columns[0].Visible = false;
            dgridGioHang.Columns[1].Name = "Mã sản phẩm";
            dgridGioHang.Columns[2].Name = "Tên sản phẩm";
            dgridGioHang.Columns[3].Name = "Số lượng";
            dgridGioHang.Columns[4].Name = "Đơn giá";
            dgridGioHang.Columns[5].Name = "Thành tiền";
           
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Xác nhận";
            buttonColumn.Text = "Sửa";
            buttonColumn.Name = "Sửa";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgridGioHang.Rows.Clear();
            dgridGioHang.Columns.Add(buttonColumn);
            foreach(var x in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == acbc))
            {
                var qlhh = _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == x.IdthongTinHangHoa).FirstOrDefault();
                var hh = _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == qlhh.ChiTietHangHoa.IdhangHoa).FirstOrDefault();
                dgridGioHang.Rows.Add(x.IdhoaDonChiTiet, hh.HangHoa.MaHangHoa, hh.HangHoa.TenHangHoa, x.SoLuong, x.DonGia, x.ThanhTien);
            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
           
            double tongtientaiquan =Convert.ToDouble( _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.TongSoTien).FirstOrDefault());
            double thuetaiquan =Convert.ToDouble( _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.Thue).FirstOrDefault());
            double thanhtien =Convert.ToDouble( _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.Tien).FirstOrDefault());
            double giamgiataiquan =Convert.ToDouble( _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.GiamGia).FirstOrDefault());
            txtTongTien.Text = Convert.ToInt32(thanhtien).ToString("#,###", cul.NumberFormat);
            txtKhachTra.Text = Convert.ToInt32(tongtientaiquan).ToString("#,###", cul.NumberFormat);
            textBox2.Text = Convert.ToInt32(thuetaiquan).ToString("#,###", cul.NumberFormat);
            
            txtDiscount.Text = Convert.ToInt32(giamgiataiquan).ToString("#,###", cul.NumberFormat);
            
        }

        public void loadhoadonduyet()
        {

            flhoadon.Controls.Clear();
            foreach (var x in _hdser.getlsthdbfromDB().Where(c => c.TrangThai == 2))
            {

                Button btn = new Button() { Width = 80, Height = 80 };
                btn.Text = x.MaHoaDon + Environment.NewLine + (x.TrangThai == 2
                    ? "Chưa Thanh Toán"
                    : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"));
                btn.Tag = x;
                btn.Click += btnsender_Click;
                switch (x.TrangThai)
                {
                    case 2:
                    {
                        btn.BackColor = Color.Red;
                        break;
                    }
                    case 3:
                        btn.BackColor = Color.BlueViolet;
                        break;
                }

                flhoadon.Controls.Add(btn);
            }

        }
        void clear()
        {
            txtDiscount.Text = "0";
            textBox2.Text = "0";
            txtTongTien.Text = "";
            txtKhachTra.Text = "";
            txtKhachDua.Text = "";
            txtTienthua.Text = "";
            rbt_chuathanhtoan.Checked = true;
            richTextBox1.Text = "";
        }
        public void loadhoadonduyet3()
        {

            flhd3.Controls.Clear();
            foreach (var x in _hdser.getlsthdbfromDB().Where(c => c.TrangThai == 3))
            {

                Button btn = new Button() { Width = 80, Height = 80 };
                btn.Text = x.MaHoaDon + Environment.NewLine + (x.TrangThai == 2
                    ? "Chưa Thanh Toán"
                    : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"));
                btn.Tag = x;
                btn.Click += btnsender_Click;
                switch (x.TrangThai)
                {
                    case 2:
                        {
                            btn.BackColor = Color.Red;
                            break;
                        }
                    case 3:
                        btn.BackColor = Color.BlueViolet;
                        break;
                }

                flhd3.Controls.Add(btn);
            }

        }


        private void txtTongTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal a, b;
                a = Decimal.Parse(txtTongTien.Text);
                b = Decimal.Parse(txtKhachDua.Text);
                txtTienthua.Text = (b - a).ToString();
            }
        }

        void inHoaDon()
        {
            pPreDHoaDon.Document = pDHoaDon;
            pPreDHoaDon.ShowDialog();
        }

        private void pDHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            var w = pDHoaDon.DefaultPageSettings.PaperSize.Width;
            //Lấy tên cửa hàng

            e.Graphics.DrawString(
                "PerSoft Perfume".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black,
                new PointF(100, 20));
            //Mã hóa đơn

            e.Graphics.DrawString(
                String.Format("{0}", _lstHoaDonBans.Select(x => x.MaHoaDon).FirstOrDefault()),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black, new PointF(w / 2 + 200, 20));

            //Dịa chỉ sdt
            //e.Graphics.DrawString(
            //    String.Format("{0} - {1}", _iKhachHangServices.getlstkhachhangformDB().Select(x => x.TenKhachHang).FirstOrDefault(), _iKhachHangServices.getlstkhachhangformDB().Select(x => x.TenKhachHang).FirstOrDefault()),
            //    new Font("Courier New", 8, FontStyle.Bold),
            //    Brushes.Black, new PointF(100, 45));

            //Ngày giờ xuất hóa đơn

            e.Graphics.DrawString(
                String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:MM")),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black, new PointF(w / 2 + 200, 45));

            Pen blackPEn = new Pen(Color.Black, 1);
            var y = 70;

            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPEn, p1, p2);

            y += 30;
            e.Graphics.DrawString(
                "Phiếu Thanh Toán".ToUpper(), new Font("Courier New", 30, FontStyle.Bold), Brushes.Black,
                new PointF(190, y));


            y += 80;
            e.Graphics.DrawString("STT", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Tên hàng hóa", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                new Point(50, y));
            e.Graphics.DrawString("Số lượng", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                new Point(w - 200, y));
            //var id = _lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault();
            var list = _iQlyHoaDon.GetsList().Where(x => x.HoaDonChiTiet.IdhoaDon == Convert.ToInt32(txtMaHDD.Text));

            int i = 1;
            y += 20;
            foreach (var x in _lstHoaDonChiTiets)
            {
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black,
                    new Point(10, y));
                e.Graphics.DrawString("" + _iQlyHangHoa.GetsList()
                                          .Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                                          .Select(c => c.HangHoa.TenHangHoa).FirstOrDefault() + " " +
                                      _iQlyHangHoa.GetsList().Where(c =>
                                              c.ChiTietHangHoa.IdthongTinHangHoa == x.IdthongTinHangHoa)
                                          .Select(c => c.ChiTietHangHoa.Model).FirstOrDefault(),
                    new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.SoLuong), new Font("Varial", 8, FontStyle.Bold),
                    Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.DonGia), new Font("Varial", 8, FontStyle.Bold),
                    Brushes.Black, new Point(w / 2 + 100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.ThanhTien), new Font("Varial", 8, FontStyle.Bold),
                    Brushes.Black, new Point(w - 200, y));
                y += 20;
            }

            y += 40;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPEn, p1, p2);


            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Tiền khách đưa : "), new Font("Varial", 13, FontStyle.Bold),
                Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString(txtKhachDua.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Trả khách :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w / 2, y));
            e.Graphics.DrawString(txtTienthua.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(
                string.Format("Thành chữ : {0} VND", NumberToText(Convert.ToDouble(txtTongTien.Text))),
                new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 30, y));
        }

        void inDonhang()
        {
            pPreDHoaDon.Document = pDDatHang;
            pPreDHoaDon.ShowDialog();
        }

        private void pDDatHang_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var w = pDHoaDon.DefaultPageSettings.PaperSize.Width;
            //Lấy tên cửa hàng

            e.Graphics.DrawString(
                "PerSoft Perfume".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black,
                new PointF(100, 20));
            //Mã hóa đơn

            e.Graphics.DrawString(
                String.Format("{0}", _lstHoaDonBans.Select(x => x.MaHoaDon).FirstOrDefault()),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black, new PointF(w / 2 + 200, 20));

            //Dịa chỉ sdt
            //e.Graphics.DrawString(
            //    String.Format("{0} - {1}", _iKhachHangServices.getlstkhachhangformDB().Select(x => x.TenKhachHang).FirstOrDefault(), _iKhachHangServices.getlstkhachhangformDB().Select(x => x.TenKhachHang).FirstOrDefault()),
            //    new Font("Courier New", 8, FontStyle.Bold),
            //    Brushes.Black, new PointF(100, 45));

            //Ngày giờ xuất hóa đơn

            e.Graphics.DrawString(
                String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:MM")),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black, new PointF(w / 2 + 200, 45));

            Pen blackPEn = new Pen(Color.Black, 1);
            var y = 70;

            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPEn, p1, p2);

            y += 30;
            e.Graphics.DrawString(
                "Phiếu Thanh Toán".ToUpper(), new Font("Courier New", 30, FontStyle.Bold), Brushes.Black,
                new PointF(190, y));


            y += 80;
            e.Graphics.DrawString("STT", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Tên hàng hóa", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                new Point(50, y));
            e.Graphics.DrawString("Số lượng", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                new Point(w - 200, y));
            var id = _lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault();
            var list = from a in _iQlyHoaDon.GetsList().Where(x => x.HoaDonBan.IdhoaDon == id)
                select a;
            int i = 1;
            y += 20;
            foreach (var x in list)
            {
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black,
                    new Point(10, y));
                e.Graphics.DrawString(x.HangHoa.TenHangHoa + "" + x.ChiTietHangHoa.Model,
                    new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.HoaDonChiTiet.SoLuong),
                    new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.ChiTietHangHoa.DonGiaBan),
                    new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.HoaDonBan.TongSoTien),
                    new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            }

            y += 40;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPEn, p1, p2);


            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Tiền khách đưa : "), new Font("Varial", 13, FontStyle.Bold),
                Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Trả khách :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(
                string.Format("Thành chữ : {0} VND", NumberToText(Convert.ToDouble(txtTongTien.Text))),
                new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
        }

        #region mousehover

        private void button2_Click(object sender, EventArgs e)
        {
            //flag *= -1;
            //if (flag == 1)
            //{
            //    btnDathang.Hide();
            //    btnThanhToan.Show();
            //}
            pn_dathang.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //flag *= -1;
            //if (flag == 1)
            //{
            //    btnDathang.Show();
            //    btnThanhToan.Hide();
            //}
            pn_dathang.Visible = true;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.DarkOrange;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkOrange;
            button3.BackColor = Color.MediumBlue;
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.DarkOrange;
            button2.BackColor = Color.MediumBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.MediumBlue;
        }

        #endregion

        private void btnDathang_Click(object sender, EventArgs e)
        {

        }

        private void cbxKH_TextChanged(object sender, EventArgs e)
        {
            //string str;
            ////if (cbxKH.Text == "")
            ////{
            ////    txtEmail.Text = "";
            ////    txtDTD.Text = "";
            ////}

            //string n = Convert.ToString(cbxKH.SelectedValue);
            //str = _iQlyKhachHang.GetsList().Where(x => x.KhachHang.TenKhachHang == n).Select(x => x.KhachHang.Email).FirstOrDefault();
            ////txtEmail.Text = str;
            //txtDT.Text= _iQlyKhachHang.GetsList().Where(x => x.KhachHang.TenKhachHang == cbxKH.SelectedItem.ToString()).Select(x => x.KhachHang.SoDienThoai).FirstOrDefault();
            //var _lst = from a in _iQlyKhachHang.GetsList()
            //    where a.KhachHang.TenKhachHang == cbxKH.SelectedValue
            //    select a;
            //txtEmail.Text = _lst.Select(x => x.KhachHang.Email).FirstOrDefault();

        }

        private void cbxKH_SelectedValueChanged(object sender, EventArgs e)
        {
            string str;
            if (cbxKH.Text == "")
            {
                txtEmail.Text = "";
                txtDTD.Text = "";
            }

            string n = Convert.ToString(cbxKH.SelectedValue);
            str = _iQlyKhachHang.GetsList().Where(x => x.KhachHang.TenKhachHang == n).Select(x => x.KhachHang.Email)
                .FirstOrDefault();
            //txtEmail.Text = str;

            var _lst = from a in _iQlyKhachHang.GetsList()
                where a.KhachHang.TenKhachHang == Convert.ToString(cbxKH.SelectedItem)
                select a;
            txtEmail.Text = _iQlyKhachHang.GetsListKH()
                .Where(x => x.TenKhachHang == Convert.ToString(cbxKH.SelectedItem))
                .Select(x => x.Email).FirstOrDefault();
            txtDT.Text = _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == Convert.ToString(cbxKH.SelectedItem))
                .Select(x => x.SoDienThoai).FirstOrDefault();
            int iddtd = Convert.ToInt32(_iQlyKhachHang.GetsListKH()
                .Where(x => x.TenKhachHang == Convert.ToString(cbxKH.SelectedItem))
                .Select(x => x.IddiemTieuDung).FirstOrDefault());
            txtDTD.Text = Convert.ToString(Convert.ToDouble(_iQlyKhachHang.GetsList()
                .Where(x => x.DiemTieuDung.IddiemTieuDung == iddtd)
                .Select(x => x.DiemTieuDung.SoDiem).FirstOrDefault()));
            var bac = Convert.ToDouble(_iQlyKhachHang.GetsList().Where(x => x.DiemTieuDung.IddiemTieuDung == iddtd)
                .Select(x => x.DiemTieuDung.SoDiem).FirstOrDefault());
            cbxRank.Text = bac < 1000 ? "Bạc" :
                bac < 200 ? "Vàng" :
                string.IsNullOrEmpty(Convert.ToString(bac)) ? "Bạc" : "Kim cương";
        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            fKhachHang f = new fKhachHang();
            BanHang fbanhang = new BanHang();
            f.Show();
            ////SetBounds(Screen.GetWorkingArea(f).Width-Width,Screen.GetWorkingArea(f).Height-Height,Width-1000,Height+300)  ;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.StartPosition = FormStartPosition.Manual;
            //f.Location = new Point(fbanhang.Width / 2 - f.Width / 2 + fbanhang.Location.X,
            //    fbanhang.Height / 2 - f.Height / 2 + fbanhang.Location.Y);
            f.Location = new Point(f.Width + 590, 200);

            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Hóa Đơn Hay Không ?", "Thông Báo",
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Tạo Hóa Đơn Thành Công");

                }

                var idhd = _iQlyHoaDon.GetsListHD().Max(x => x.IdhoaDon);
                HoaDonBan hoaDonBan = new HoaDonBan()
                {
                    IdhoaDon = Convert.ToInt32(idhd) + 1,
                    MaHoaDon = "HD0000" + _iQlyHoaDon.GetsListHD().Select(x => x.IdhoaDon).LastOrDefault(),
                    //  Iduser = _iQlyNhanVien.GetsList().Where(x => x.NhanVien.TenNhanVien == cbxNV.Text).Select(x => x.NhanVien.Iduser).FirstOrDefault(),

                };
                _lstHoaDonBans.Add(hoaDonBan);
                _iQlyHoaDon.addHD(hoaDonBan);
                _iQlyHoaDon.SaveHD();
                txtMaHDD.Text = Convert.ToString(_lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault());
                dgrid_sanpham.ColumnCount = 8;
                dgrid_sanpham.Columns[0].Name = "ID";
                dgrid_sanpham.Columns[0].Visible = false;
                dgrid_sanpham.Columns[1].Name = "IDHHCT";
                dgrid_sanpham.Columns[1].Visible = false;
                dgrid_sanpham.Columns[2].Name = "Mã sản phẩm";
                dgrid_sanpham.Columns[3].Name = "Tên sản phẩm";
                dgrid_sanpham.Columns[4].Name = "Đơn giá";
                dgrid_sanpham.Columns[5].Name = "Tồn kho";
                dgrid_sanpham.Columns[6].Name = "IDhD";
                dgrid_sanpham.Columns[6].Visible = false;
                dgrid_sanpham.Columns[7].Name = "Đường Dẫn";
                dgrid_sanpham.Columns[7].Visible = false;

                dgrid_sanpham.Rows.Clear();
                var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
                foreach (var x in _iQlyHangHoa.GetsList())
                {
                    dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                        x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                        x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.SoLuong, idlhd, x.Anh.DuongDan);
                }

                dcmmm();
                return;
            }

            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.AlertErr("Tạo Hóa Đơn Thất Bại");

                }

                return;
            }

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

            BanHang fbanhang = new BanHang();
            //int iddtd = Convert.ToInt32(_iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
            //    .Select(x => x.IddiemTieuDung).FirstOrDefault());
            //////SetBounds(Screen.GetWorkingArea(f).Width-Width,Screen.GetWorkingArea(f).Height-Height,Width-1000,Height+300);
            fLichSuDungDiem f = new fLichSuDungDiem();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.StartPosition = FormStartPosition.Manual;
            //f.Location = new Point(fbanhang.Width / 2 - f.Width / 2 + fbanhang.Location.X,
            //    fbanhang.Height / 2 - f.Height / 2 + fbanhang.Location.Y);
            f.Location = new Point(f.Width + 762, 260);


            f.label2.Text = cbxKH.Text;
            f.Show();

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            fXuLiDonHang f = new fXuLiDonHang();
            f.Show();
        }


        private void button9_Click(object sender, EventArgs e)
        {

           
        }

        private void label11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_TextChanged(object sender, EventArgs e)
        {
            // if (txtDiscount.Text== "") return;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {

         

            //
            try
            {
                if (txtKhachDua.Text != "")
                {
                    decimal khachdua;
                    decimal khachtra;

                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                    //khachdua = Convert.ToDecimal(txtKhachDua.Text);

                    //khachtra = Convert.ToDecimal(txtKhachTra.Text);
                    //
                    string fkhachtra = Convert.ToString(txtKhachTra.Text);
                    string tkhachtra = fkhachtra.Replace(".", "");

                    string fkhachdua = Convert.ToString(txtKhachDua.Text);
                    string tkhachdua = fkhachdua.Replace(".", "");
                    //
                 
                    double  ftienthua =Convert.ToDouble(Convert.ToDouble(tkhachdua)-Convert.ToDouble(tkhachtra));
                  
                  

                    txtTienthua.Text = Convert.ToInt32(ftienthua).ToString("#,###", cul.NumberFormat);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception + "", "Thông báo");

            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            try
            {

                if (txtDiscount.Text != "" && textBox2.Text != "")
                {
                    decimal thue;
                    decimal giamgia;

                    string tt = Convert.ToString(txtTongTien.Text);
                    string fn = tt.Replace(".", "");
                    thue = Convert.ToDecimal(textBox2.Text);
                    giamgia = Convert.ToDecimal(txtDiscount.Text);

                    double khach = Convert.ToDouble(Convert.ToInt32(fn) -
                                                        Convert.ToDouble(giamgia) * 500 +
                                                        Convert.ToDouble(thue) * 0.01 *
                                                        Convert.ToInt32(fn));
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                    txtKhachTra.Text = Convert.ToInt32(khach).ToString("#,###", cul.NumberFormat);

                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Bạn phải nhập vào số nguyên" + fe);
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

          

            if (txtDiscount.Text != "" && textBox2.Text != "")
            {




                decimal thue;
                decimal giamgia;
         
                string tt = Convert.ToString(txtTongTien.Text);
              string fn = tt.Replace(".", "");
                thue = Convert.ToDecimal(textBox2.Text);
                giamgia = Convert.ToDecimal(txtDiscount.Text);
                
                double khach = Convert.ToDouble(Convert.ToInt32(fn) -
                                                    Convert.ToDouble(giamgia) * 500 +
                                                    Convert.ToDouble(thue) * 0.01 *
                                                    Convert.ToInt32(fn));
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                txtKhachTra.Text = Convert.ToInt32(khach).ToString("#,###", cul.NumberFormat);

            }
        }



        private void label10_TextChanged(object sender, EventArgs e)
        {
            //NumberToText(Convert.ToDouble( txtKhachTra.Text), true);
        }

        private void rbt_dathanhtoan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_dathanhtoan.Checked)
            {
                rbt_chuathanhtoan.Checked = false;
                rbt_dacoc.Checked = false;
                rbt_chogiaohang.Checked = false;
                rbt_dahuy.Checked = false;
            }
        }

        private void rbt_chuathanhtoan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_chuathanhtoan.Checked)
            {
                rbt_dathanhtoan.Checked = false;
                rbt_dacoc.Checked = false;
                rbt_chogiaohang.Checked = false;
                rbt_dahuy.Checked = false;
            }

        }

        private void rbt_chogiaohang_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_chogiaohang.Checked)
            {
                rbt_dathanhtoan.Checked = false;
                rbt_dacoc.Checked = false;
                rbt_chuathanhtoan.Checked = false;
                rbt_dahuy.Checked = false;
            }
        }

        private void rbt_dahuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_dahuy.Checked)
            {
                rbt_dathanhtoan.Checked = false;
                rbt_dacoc.Checked = false;
                rbt_chuathanhtoan.Checked = false;
                rbt_chogiaohang.Checked = false;
            }
        }

        private void rbt_dacoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_dacoc.Checked)
            {
                rbt_dathanhtoan.Checked = false;
                rbt_dahuy.Checked = false;
                rbt_chuathanhtoan.Checked = false;
                rbt_chogiaohang.Checked = false;
            }
        }

        private void txtTienthua_TextChanged(object sender, EventArgs e)
        {




        }

        private void txt_dathangthue_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_dathangthue.Text != "" && txt_dathanggiamgia.Text != "")
            {
                //decimal thue;
                //decimal giamgia;
                //thue = Convert.ToDecimal(txt_dathangthue.Text);
                //giamgia = Convert.ToDecimal(txt_dathanggiamgia.Text);
                //double khach = Convert.ToDouble(
                //    Convert.ToInt32(txt_dathangtongtien.Text) * (1 - Convert.ToInt32(giamgia) * 0.01) + Convert.ToInt32(
                //        Convert.ToInt32(Convert.ToInt32(txt_dathangtongtien.Text) - (1 - Convert.ToInt32(thue) * 0.01) *
                //            (Convert.ToInt32(txt_dathangtongtien.Text)))));

                //CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                //txt_dathangkhachtra.Text = Convert.ToInt32(khach).ToString("#,###", cul.NumberFormat);


                decimal thue;
                decimal giamgia;

                string tt = Convert.ToString(txt_dathangtongtien.Text);
                string fn = tt.Replace(".", "");
                thue = Convert.ToDecimal(txt_dathangthue.Text);
                giamgia = Convert.ToDecimal(txt_dathanggiamgia.Text);

                double khach = Convert.ToDouble(Convert.ToInt32(fn) -
                                                    Convert.ToDouble(giamgia) * 500 +
                                                    Convert.ToDouble(thue) * 0.01 *
                                                    Convert.ToInt32(fn));
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                txt_dathangkhachtra.Text = Convert.ToInt32(khach).ToString("#,###", cul.NumberFormat);


            }
        }

      
      

        private void rbt_dathangchuathanhtoan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_dathangchuathanhtoan.Checked)
            {
                rbt_dathangdacoc.Checked = false;
                rbt_dathangdahuy.Checked = false;
                rbt_dathanhtoan.Checked = false;
                rbt_dathangchogiaohang.Checked = false;
            }
        }

        private void rbt_dathangdathanhtoan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_dathanhtoan.Checked)
            {
                rbt_dathangdacoc.Checked = false;
                rbt_dathangdahuy.Checked = false;
                rbt_dathangchuathanhtoan.Checked = false;
                rbt_dathangchogiaohang.Checked = false;
            }
        }

        private void rbt_dathangchogiaohang_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_dathangchogiaohang.Checked)
            {
                rbt_dathangdacoc.Checked = false;
                rbt_dathangdahuy.Checked = false;
                rbt_dathangchuathanhtoan.Checked = false;
                rbt_dathanhtoan.Checked = false;
            }
        }

        private void rbt_dathangdacoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_dathangdacoc.Checked)
            {
                rbt_dathangchogiaohang.Checked = false;
                rbt_dathangdahuy.Checked = false;
                rbt_dathangchuathanhtoan.Checked = false;
                rbt_dathanhtoan.Checked = false;
            }
        }

        private void rbt_dathangdahuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_dathangdahuy.Checked)
            {
                rbt_dathangchogiaohang.Checked = false;
                rbt_dathangdacoc.Checked = false;
                rbt_dathangchuathanhtoan.Checked = false;
                rbt_dathanhtoan.Checked = false;
            }
        }

    

        private void dgridGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int row = e.RowIndex;
            if (Convert.ToInt32(dgridGioHang.Rows[row].Cells[3].Value.ToString()) > Convert.ToInt32(_iQlyHangHoa
                .GetsList().Where(c => c.HangHoa.MaHangHoa == dgridGioHang.Rows[row].Cells[1].Value.ToString())
                .Select(c => c.ChiTietHangHoa.SoLuong).FirstOrDefault()))
            {
                MessageBox.Show("Sản phẩm trong kho không đủ \n Số sản phẩm hiện tại là;" + Convert.ToInt32(_iQlyHangHoa
                    .GetsList().Where(c => c.HangHoa.MaHangHoa == dgridGioHang.Rows[row].Cells[1].Value.ToString())
                    .Select(c => c.ChiTietHangHoa.SoLuong).FirstOrDefault()) + "Mời chọn sản phẩm khác","Thông báo");
                return;
            }
                if (e.ColumnIndex == dgridGioHang.Columns["Sửa"].Index)
            {

                var diaglog = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (diaglog == DialogResult.No)
                {
                    return;
                }

                var hdctiet = _iQlyHoaDon.GetsListHDCT()
                    .FirstOrDefault(x => x.IdhoaDon == Convert.ToInt32(txtMaHDD.Text));
                hdctiet.SoLuong = Convert.ToInt32(dgridGioHang.Rows[row].Cells[3].Value.ToString());
                _iQlyHoaDon.updateHDCTV(hdctiet);
                _iQlyHoaDon.SaveHDCT();
                int idhhct = Convert.ToInt32(_iQlyHangHoa
                    .GetsList().Where(c => c.HangHoa.MaHangHoa == dgridGioHang.Rows[row].Cells[1].Value.ToString())
                    .Select(c => c.ChiTietHangHoa.IdthongTinHangHoa).FirstOrDefault());
                var Cthh = _iQlyHangHoa.GetsListCTHH().FirstOrDefault(x => x.IdthongTinHangHoa == idhhct);
                Cthh.SoLuong = Convert.ToString(Convert.ToInt32(_iQlyHangHoa.GetsListCTHH()
                    .Where(x => x.IdthongTinHangHoa == idhhct).Select(x => x.SoLuong).FirstOrDefault()) +Convert.ToInt32(_lstHoaDonChiTiets.Where(x=>x.IdthongTinHangHoa== idhhct).Select(x=>x.SoLuong).FirstOrDefault())- Convert.ToInt32(dgridGioHang.Rows[row].Cells[3].Value.ToString()));
                _iQlyHangHoa.UpdateSPChiTiet(Cthh);
                _iQlyHangHoa.SaveChiTietHangHoa(Cthh);
                dgrid_sanpham.ColumnCount = 8;
                dgrid_sanpham.Columns[0].Name = "ID";
                dgrid_sanpham.Columns[0].Visible = false;
                dgrid_sanpham.Columns[1].Name = "IDHHCT";
                dgrid_sanpham.Columns[1].Visible = false;
                dgrid_sanpham.Columns[2].Name = "Mã sản phẩm";
                dgrid_sanpham.Columns[3].Name = "Tên sản phẩm";
                dgrid_sanpham.Columns[4].Name = "Đơn giá";
                dgrid_sanpham.Columns[5].Name = "Tồn kho";
                dgrid_sanpham.Columns[6].Name = "IDhD";
                dgrid_sanpham.Columns[6].Visible = false;
                dgrid_sanpham.Columns[7].Name = "Đường Dẫn";
                dgrid_sanpham.Columns[7].Visible = false;

                dgrid_sanpham.Rows.Clear();
                var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
                foreach (var x in _iQlyHangHoa.GetsList())
                {
                    dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                        x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                        x.ChiTietHangHoa.DonGiaBan, Convert.ToInt32(x.ChiTietHangHoa.SoLuong), idlhd, x.Anh.DuongDan);
                }

                dcmmm();
                int count = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                }

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
            }
        }
        private void txt_dathangthue_TextChanged(object sender, EventArgs e)
        {
            if (txt_dathangthue.Text != "" && txt_dathanggiamgia.Text != "")
            {
                decimal thue;
                decimal giamgia;

                string tt = Convert.ToString(txt_dathangtongtien.Text);
                string fn = tt.Replace(".", "");
                thue = Convert.ToDecimal(txt_dathangthue.Text);
                giamgia = Convert.ToDecimal(txt_dathanggiamgia.Text);

                double khach = Convert.ToDouble(Convert.ToInt32(fn) -
                                                    Convert.ToDouble(giamgia) * 500 +
                                                    Convert.ToDouble(thue) * 0.01 *
                                                    Convert.ToInt32(fn));
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                txt_dathangkhachtra.Text = Convert.ToInt32(khach).ToString("#,###", cul.NumberFormat);
            }
        }

        private void txt_dathanggiamgia_TextChanged(object sender, EventArgs e)
        {
            if (txt_dathangthue.Text != "" && txt_dathanggiamgia.Text != "")
            {
                decimal thue;
                decimal giamgia;

                string tt = Convert.ToString(txt_dathangtongtien.Text);
                string fn = tt.Replace(".", "");
                thue = Convert.ToDecimal(txt_dathangthue.Text);
                giamgia = Convert.ToDecimal(txt_dathanggiamgia.Text);

                double khach = Convert.ToDouble(Convert.ToInt32(fn) -
                                                    Convert.ToDouble(giamgia) * 500 +
                                                    Convert.ToDouble(thue) * 0.01 *
                                                    Convert.ToInt32(fn));
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                txt_dathangkhachtra.Text = Convert.ToInt32(khach).ToString("#,###", cul.NumberFormat);
            }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            DialogResult dialogResult =
               MessageBox.Show("bạn có muốn thanh toán hay không", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int iddtd = Convert.ToInt32(_iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                    .Select(x => x.IddiemTieuDung).FirstOrDefault());
                string tt = Convert.ToString(txt_dathangtongtien.Text);
                txt_dathangtongtien.Text = tt.Replace(".", "");
                float tien = float.Parse(txt_dathangtongtien.Text);

                if (checkdiem(txtDiscount.Text) == true)
                {

                }
                else
                {
                    if (checkdiem(txtMaHDD.Text) == false) return;
                }

                if (cbxKH.Text == _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                    .Select(x => x.TenKhachHang).FirstOrDefault())
                {
                    if (_iQlyKhachHang.GetsListDTD().Where(x => x.IddiemTieuDung == iddtd).Select(x => x.TrangThai)
                        .FirstOrDefault() == 0)
                    {
                        var diemtieudung = _iQlyKhachHang.GetsListDTD().FirstOrDefault(x => x.IddiemTieuDung == iddtd);
                        diemtieudung.SoDiem = tien < 100000 ? tien * 0.0002 :
                            tien < 500000 ? tien * 0.0001 :
                            tien < 1000000 ? tien * 0.00012 :
                            tien < 5000000 ? tien * 0.00013 : tien * 0.00015 + (Convert.ToDouble(_iQlyKhachHang
                                .GetsListDTD()
                                .Where(x => x.IddiemTieuDung == iddtd)
                                .Select(x => x.SoDiem).FirstOrDefault()));
                        _iQlyKhachHang.updateDiemTD(diemtieudung);
                        _iQlyKhachHang.SaveDTD(diemtieudung);
                        _iSendPoint.SendMail(txtEmail.Text, tien < 100000 ? tien * 0.0002 :
                            tien < 500000 ? tien * 0.0001 :
                            tien < 1000000 ? tien * 0.00012 :
                            tien < 5000000 ? tien * 0.00013 : tien * 0.00015, Convert.ToDouble(txtDiscount.Text),
                            Convert.ToDouble(_iQlyKhachHang.GetsListDTD()
                                .Where(x => x.IddiemTieuDung == iddtd)
                                .Select(x => x.SoDiem).LastOrDefault()));
                    }

                }



                if (!string.IsNullOrEmpty(txtDiscount.Text))
                {
                    LichSuTieuDungDiem lichSuTieuDungDiem = new LichSuTieuDungDiem()
                    {
                        IdhoaDon = Convert.ToInt32(txtMaHDD.Text),
                        TrangThai = 1,
                        IdlichSuDiem = _iQlyKhachHang.GetsListLS().Max(x => x.IdlichSuDiem) + 1,
                        NgaySuDung = DateTime.Now,
                        SoDiemTieu = Convert.ToDouble(txtDiscount.Text),
                        IddiemTieuDung = _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                            .Select(x => x.IddiemTieuDung).FirstOrDefault()
                    };
                    var diemtieudung = _iQlyKhachHang.GetsListDTD().FirstOrDefault(x => x.IddiemTieuDung == iddtd);
                    diemtieudung.SoDiem = Convert.ToDouble(_iQlyKhachHang.GetsListDTD()
                        .Where(x => x.IddiemTieuDung == iddtd)
                        .Select(x => x.SoDiem).FirstOrDefault()) - Convert.ToDouble(txtDiscount.Text);
                    _iQlyKhachHang.updateDiemTD(diemtieudung);
                    _iQlyKhachHang.SaveDTD(diemtieudung);
                    _iQlyKhachHang.addLichSu(lichSuTieuDungDiem);
                    _iQlyKhachHang.SaveLichSU(lichSuTieuDungDiem);
                    _iSendPoint.SendMail2(txtEmail.Text, tien < 100000 ? tien * 0.0002 :
                        tien < 500000 ? tien * 0.0001 :
                        tien < 1000000 ? tien * 0.00012 :
                        tien < 5000000 ? tien * 0.00013 : tien * 0.00015, Convert.ToDouble(_iQlyKhachHang.GetsListDTD()
                            .Where(x => x.IddiemTieuDung == iddtd)
                            .Select(x => x.SoDiem).LastOrDefault()));
                }

                //
                if (rbt_dathangdathanhtoan.Checked)
                {
                    statusdt = 1;
                }

                if (rbt_dathangdacoc.Checked)
                {
                    statusdt = 0;
                }

                if (rbt_dathangchuathanhtoan.Checked)
                {
                    statusdt = 2;
                }

                if (rbt_dathangchogiaohang.Checked)
                {
                    statusdt = 3;
                }

                if (rbt_dathangdahuy.Checked)
                {
                    statusdt = 4;
                }
                string aa = Convert.ToString(txt_dathangkhachtra.Text);
                string fn = aa.Replace(".", "");
                string bb = Convert.ToString(txt_dathangtongtien.Text);
                string fn1 = bb.Replace(".", "");
                string cc = Convert.ToString(txt_coc.Text);
                string fn2 = cc.Replace(".", "");



                hoadon = _iQlyHoaDon.GetsListHD().FirstOrDefault(x => x.IdhoaDon == Convert.ToInt32(txtMaHDD.Text));
                hoadon.TrangThai = Convert.ToInt32(statusdt);
                hoadon.NgayLap = DateTime.Now;
                hoadon.IdkhachHang = _ikhser.getlstkhachhangformDB().Where(c => c.Email == txtEmail.Text)
                    .Select(c => c.IdkhachHang).FirstOrDefault();
                hoadon.Iduser = _invser.getlstnhanvienfromDB().Where(c => c.TenNhanVien == cbxNV.Text)
                    .Select(c => c.Iduser).FirstOrDefault();
                hoadon.Tien = float.Parse(fn1);

                hoadon.TongSoTien = float.Parse(fn);
                hoadon.Thue = Convert.ToDouble(textBox2.Text);
                int id = _iQlyKhachHang.GetsListKH().Where(c => c.Email == txtEmail.Text).Select(c => c.IdkhachHang)
                    .FirstOrDefault();
                hoadon.MaHoaDon = _iQlyHoaDon.GetsListHD().Where(c => c.IdhoaDon == hoadon.IdhoaDon)
                    .Select(c => c.MaHoaDon).FirstOrDefault();
                hoadon.IdkhachHang = id;
                hoadon.NgayLap = DateTime.Now;
                hoadon.NgayShipHang = Convert.ToDateTime(dtp_ship.Value);
                hoadon.NgayNhanHang = Convert.ToDateTime(dtp_nhanhang.Value);
                hoadon.GhiChu = Convert.ToString(rtx_ghichu2.Text);
                hoadon.TienCoc = Convert.ToDouble(fn2);
                _hdser.updatehdb(hoadon);
                _hdser.save();
                int idhd = Convert.ToInt32(_hdser.getlsthdbfromDB().Max(c => c.IdhoaDon));


                try
                {


                    int max = _hdser.getlsthdbfromDB().Max(c => c.IdhoaDon);
                    //var update = _iQlyHoaDon.GetsListHDCT()
                    //    .FirstOrDefault(x => x.IdhoaDon == Convert.ToInt32(txtMaHDD.Text));
                    //var _lstPrice = (from a in _iQlyHoaDon.GetsListHDCT()
                    //    where a.IdhoaDon == max
                    //    select a).ToList();

                    foreach (var x in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == max))
                    {
                        string gg = Convert.ToString(txt_dathanggiamgia.Text);
                        string hh = gg.Replace(".", "");
                        x.GiamGia = Convert.ToDouble(hh);
                        _hdctser.updatehdct(x);
                        _hdctser.save();
                    }

                    loadhoadonduyet(); //IDHHCT
                    loadhoadonduyet3(); //IDHHCT
                }
                catch (System.FormatException FormatException)
                {
                    Console.WriteLine(FormatException);
                    throw;
                }

                loadhoadonduyet();
                dgridGioHang.ColumnCount = 6;
                dgridGioHang.Columns[0].Name = "ID";
                dgridGioHang.Columns[0].Visible = false;
                dgridGioHang.Columns[1].Name = "Mã sản phẩm";
                dgridGioHang.Columns[2].Name = "Tên sản phẩm";
                dgridGioHang.Columns[3].Name = "Số lượng";
                dgridGioHang.Columns[4].Name = "Đơn giá";
                dgridGioHang.Columns[5].Name = "Thành tiền";
                dgridGioHang.Rows.Clear();

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Xác nhận";
                buttonColumn.Text = "Sửa";
                buttonColumn.Name = "Sửa";
                buttonColumn.UseColumnTextForButtonValue = true;

                dgridGioHang.Columns.Add(buttonColumn);
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Thanh Toán Thành Công");
                }

                return;
            }

            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.AlertErr("Thanh Toán Thất Bại");
                }

                return;
            }
        }

        private void txt_dathangtongtien_TextChanged(object sender, EventArgs e)
        {
            string ss = txt_dathangtongtien.Text;
            string sss = ss.Replace(".", "");
            if (Convert.ToInt32(sss) > 1000000) //trên 1tr cọc 30%
            {
                double tiencoc = Convert.ToDouble(Convert.ToInt32(sss) * 0.3);
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                txt_coc.Text = Convert.ToInt32(tiencoc).ToString("#,###", cul.NumberFormat);
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            LoadHDCT();
            clear();
        }
    }
}
