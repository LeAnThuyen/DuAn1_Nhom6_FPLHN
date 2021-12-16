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
        private IServicesChiTietHangHoa _isercthh;
        private IQLyBanHang iQLyBanHang;
        private IQlyHangHoa _iQlyHangHoa;
        private IServicesHangHoa  _iserhh;
        private IServicesAnh  _imgser;
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
            _isercthh = new ChiTietHangHoaServices();
            _hdctser = new HoaDonChiTietServices();
            hdct = new HoaDonChiTiet();
            _ikhser = new KhachHangService();
            _invser = new NhanVienServices();
            _iSendPoint = new SendPointServices();
            _iserhh = new HangHoaServices();
            _imgser = new AnhServices();
            LoadData();
            LoadHDCT();
            dgrid_sanpham.AllowUserToAddRows = false;
            cthh = new ChiTietHangHoa();
            hoadon = new HoaDonBan();
            txt_idhoadoncho.Visible = false;
            txt_createnew.Visible = false;
            this.dgrid_sanpham.DefaultCellStyle.ForeColor = Color.Black;
            this.dgridGioHang.DefaultCellStyle.ForeColor = Color.Black;
            LoadCbxNV();
           // LoadCbxKH();
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
            txt_idhoadoncho.Text = "";
            button7.Visible = false;
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
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Mở Camera Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {


                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbo_webcam.SelectedIndex].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Mở Camera Thành Công");
                    }
                };

                if (dialogResult == DialogResult.No)
                {

                    for (int i = 0; i < 2; i++)
                    {
                        this.AlertErr("Mở Camera Thất Bại");
                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }



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
            try
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
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

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
            try
            {
                foreach (var x in _iQlyNhanVien.GetsList())
                {
                    cbxNV.Items.Add(x.NhanVien.TenNhanVien);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }

        void LoadHDCT()
        {
            try
            {
                dgridGioHang.ColumnCount = 6;
                dgridGioHang.Columns[0].Name = "ID";
                dgridGioHang.Columns[0].Visible = false;
                dgridGioHang.Columns[1].Name = "Mã sản phẩm";
                dgridGioHang.Columns[2].Name = "Tên sản phẩm";
                dgridGioHang.Columns[3].Name = "Số lượng";
                dgridGioHang.Columns[4].Name = "Đơn giá";
                dgridGioHang.Columns[5].Name = "Thành tiền";
                dgridGioHang.Columns[5].Name = "Thành tiền";
                dgridGioHang.Rows.Clear();

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Xác nhận";
                buttonColumn.Text = "Sửa";
                buttonColumn.Name = "Sửa";
                buttonColumn.UseColumnTextForButtonValue = true;

                dgridGioHang.Columns.Add(buttonColumn);
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }

        void dcmmm()
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }

        void dcmmm1()
        {
            try
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

                for (int i = 0; i < dgrid_sanpham.RowCount; i++)
                {
                    Image img1 = Image.FromFile(Convert.ToString(dgrid_sanpham.Rows[i].Cells["Đường Dẫn"].Value));

                    dgrid_sanpham.Rows[i].Cells["img_sp"].Value = img1;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        void refreshcam()
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(refreshcam));
                    return;
                }
                if (pic_cam.Image != null)
                {
                    pic_cam.Image = null;
                    pic_cam.ImageLocation = null;
                    //pic_cam.Image = null;
                    pic_cam.Update();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }

        void loadsanphamsender()
        {
            try
            {

                if (InvokeRequired) // Line #1
                {
                    this.Invoke(new MethodInvoker(loadsanphamsender));
                    return;
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

                foreach (var x in _isercthh.getlstchitietthanghoafromDB())
                {
                    var sp = _iserhh.getlsthanghoafromDB().Where(c => c.IdhangHoa == x.IdhangHoa).FirstOrDefault();
                    var anh = _imgser.getlstanhfromDB().Where(c => c.Idanh == x.Idanh).FirstOrDefault();
                    dgrid_sanpham.Rows.Add(sp.IdhangHoa, x.IdthongTinHangHoa, sp.MaHangHoa,
                        sp.TenHangHoa + x.Model,
                        x.DonGiaBan,
                      x.SoLuong, idlhd, anh.DuongDan);
                }
                dcmmm1();
                int count1 = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count1 - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                }
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }

        }
        void loadsanphamtimkiem(string maten)
        {

            try
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
                dgrid_sanpham.Columns[6].Name = "IDhD";
                dgrid_sanpham.Columns[6].Visible = false;
                dgrid_sanpham.Columns[7].Name = "Đường Dẫn";
                dgrid_sanpham.Columns[7].Visible = false;

                dgrid_sanpham.Rows.Clear();
                var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
                foreach (var x in _iQlyHangHoa.GetsList().Where(c => c.HangHoa.MaHangHoa.StartsWith(maten) || c.HangHoa.TenHangHoa.StartsWith(maten)))
                {
                    dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                        x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                        x.ChiTietHangHoa.DonGiaBan,
                       x.ChiTietHangHoa.SoLuong, idlhd, x.Anh.DuongDan);
                }

                dcmmm1();
                int count1 = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count1 - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                }
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        void acdforsender()
        {
            try
            {
                if (InvokeRequired) // Line #1
                {
                    this.Invoke(new MethodInvoker(acdforsender));
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
                foreach (var f in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)))
                {
                    var qlhh = _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == f.IdthongTinHangHoa).FirstOrDefault();
                    var hh = _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == qlhh.ChiTietHangHoa.IdhangHoa).FirstOrDefault();
                    dgridGioHang.Rows.Add(f.IdhoaDonChiTiet,
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == f.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.MaHangHoa).FirstOrDefault(),
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == f.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.TenHangHoa).FirstOrDefault() + " " +
                        _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == f.IdthongTinHangHoa)
                            .Select(c => c.ChiTietHangHoa.Model).FirstOrDefault(), f.SoLuong,
                        f.DonGia, f.SoLuong * f.DonGia);
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
                       x.ChiTietHangHoa.SoLuong, idlhd, x.Anh.DuongDan);
                }

                dcmmm1();
                int count1 = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count1 - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                }
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        void acd()
        {
            try
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
                foreach (var f in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)))
                {
                    var qlhh = _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == f.IdthongTinHangHoa).FirstOrDefault();
                    var hh = _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == qlhh.ChiTietHangHoa.IdhangHoa).FirstOrDefault();
                    dgridGioHang.Rows.Add(f.IdhoaDonChiTiet,
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == f.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.MaHangHoa).FirstOrDefault(),
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == f.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.TenHangHoa).FirstOrDefault() + " " +
                        _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == f.IdthongTinHangHoa)
                            .Select(c => c.ChiTietHangHoa.Model).FirstOrDefault(), f.SoLuong,
                        f.DonGia, f.SoLuong * f.DonGia);
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
                       x.ChiTietHangHoa.SoLuong, idlhd, x.Anh.DuongDan);
                }

                dcmmm1();
                int count1 = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count1 - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                }
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);

            }
            catch (Exception ex) 
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        //barcode
        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(bitmap);
                pic_cam.Image = bitmap;
                //trương hợp 1 xét là của id hóa đơn
                if (txt_idhoadoncho.Text == "")
                {
                    if (result != null)
                    {
                        int idctt = Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.IdthongTinHangHoa).FirstOrDefault());
                        //trường hợp 1 là phải xét xem đã có trong bảng giỏ hàng hay chưa
                        //xét chưa có hóa đơn
                        if (_hdser.getlsthdbfromDB().Any(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)) == true && _hdctser.getlsthdctfromDB().Any(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)) == false)
                        {
                            if (Convert.ToString(result) == _iQlyHangHoa.GetsList()
                            .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                            .Select(c => c.ChiTietHangHoa.Mavach).FirstOrDefault())
                            {



                                string content = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm", "Thêm Vào Giỏ Hàng", "",
                                    500, 300);
                                if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                    return;
                                }
                                if (Regex.IsMatch(content, @"^\d+$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                    return;
                                }
                                if (content.Length > 6)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content) < 0)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                                    return;
                                }
                                if(Convert.ToInt32(content)>=Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.SoLuong).FirstOrDefault()))
                                {
                                    MessageBox.Show("Số Lượng Không Đủ", "ERR");
                                    return;
                                }
                                if (content.Length > 0 && content != "0" && content.Length < 6)
                                {
                                    if (Convert.ToInt32(content) < Convert.ToInt32(_iQlyHangHoa.GetsList()
                                        .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                                        .Select(c => c.ChiTietHangHoa.SoLuong).FirstOrDefault()))
                                    {
                                        int countHDCT = _hdctser.getlsthdctfromDB().Max(x => x.IdhoaDonChiTiet) + 1;
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
                                            IdhoaDon = Convert.ToInt32(txt_createnew.Text),
                                            ThanhTien = Convert.ToDouble(Convert.ToInt32(content) * (_iQlyHangHoa.GetsList()
                                             .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                                            .Select(c => c.ChiTietHangHoa.DonGiaBan).FirstOrDefault()))
                                        };
                                        _hdctser.addhdct(hoaDonChiTiet);
                                        _hdctser.save();



                                        result = null;
                                        acd();
                                        suynghi();
                                        refreshcam();

                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sản Phẩm Không Đủ Để Thêm", "Noticafition");

                                    }

                                    // pic_cam.Image = null;
                                }
                                else
                                {
                                    return;
                                }



                            }
                            return;
                        }
                        //xét tiếp đã tồn tại
                        //
                        var newwlist = _hdctser.getlsthdctfromDB().Where(x =>
                            x.IdhoaDon == Convert.ToInt32(txt_createnew.Text)).ToList();
                        //loop
                        for (int z = 0; z < dgrid_sanpham.Rows.Count; z++)
                        {

                            bool gg = newwlist.Any(c => c.IdthongTinHangHoa == idctt);
                            if (gg == true)
                            {//trùng
                                string content = Interaction.InputBox("Sản Phẩm Này Đã Có Trong Giỏ Hàng Mời Bạn Nhập Số Lượng Muốn Cập Nhật", "Cập Nhật Vào Giỏ Hàng", "",
                                         500, 300);
                                if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                    return;
                                }
                                if (Regex.IsMatch(content, @"^\d+$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                    return;
                                }
                                if (content.Length > 6)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content) < 0)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content) >= Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.SoLuong).FirstOrDefault()))
                                {
                                    MessageBox.Show("Số Lượng Không Đủ", "ERR");
                                    return;
                                }
                                if (content.Length > 0 && content != "0" && content.Length < 6)
                                {
                                    foreach (var x in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)))
                                    {
                                        if (Convert.ToInt32(idctt) == x.IdthongTinHangHoa)
                                        {
                                            x.SoLuong = Convert.ToInt32(content);

                                            _hdctser.updatehdct(x);
                                            _hdctser.save();
                                        }

                                    }


                                    acd();
                                    suynghi();
                                    refreshcam();
                                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                                    txtTongTien.Text = Convert.ToString(Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat));
                                    txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                                    this.Alert("Cập nhật Thành Công");
                                    return;


                                }
                                else
                                {
                                    return;
                                }
                              

                            }
                            //
                            else
                            {
                                //không trùng
                                string content1 = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm", "Thêm Vào Giỏ Hàng", "0",
                                  500, 300);
                                //thêm khác 0
                                if (Regex.IsMatch(content1, @"^[a-zA-Z0-9 ]*$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                    return;
                                }
                                if (Regex.IsMatch(content1, @"^\d+$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                    return;
                                }
                                if (content1.Length > 6)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content1) < 0)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content1) >= Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.SoLuong).FirstOrDefault()))
                                {
                                    MessageBox.Show("Số Lượng Không Đủ", "ERR");
                                    return;
                                }
                                if (content1.Length > 0 && content1 != "0" && content1.Length < 6)
                                {
                                    int countHDCT = _hdctser.getlsthdctfromDB().Max(x => x.IdhoaDonChiTiet) + 1;
                                    IDHH = Convert.ToInt32(idctt);
                                    HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                                    {
                                        IdhoaDonChiTiet = countHDCT,
                                        MaHoaDonChiTiet = "HDCT000" + countHDCT,
                                        DonGia = Convert.ToDouble(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.DonGiaBan).FirstOrDefault()),
                                        SoLuong = Convert.ToInt32(content1),
                                        IdthongTinHangHoa = Convert.ToInt32(idctt),
                                        TrangThai = 1,
                                        IdhoaDon = Convert.ToInt32(txt_createnew.Text),
                                        ThanhTien = Convert.ToDouble(Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.IdthongTinHangHoa).FirstOrDefault() * Convert.ToInt32(content1)))
                                    };


                                    _hdctser.addhdct(hoaDonChiTiet);
                                    _hdctser.save();


                                    acd();
                                    suynghi();
                                    refreshcam();
                                    int count = dgridGioHang.Rows.Count;
                                    tongtien = 0;
                                    for (int i = 0; i < count - 1; i++)
                                    {
                                        tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                                    }

                                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                                    txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                                    txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);


                                    this.Alert("Thêm Thành Công");
                                    return;
                                }
                                else
                                {
                                    return;
                                }



                            }
                        }

                    }
                    return;
                }
                //trường hợp 2 xét của sender


                else
                {
                    if (result != null)
                    {
                        int idctt = Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.IdthongTinHangHoa).FirstOrDefault());
                        //trường hợp 1 là phải xét xem đã có trong bảng giỏ hàng hay chưa
                        //xét chưa có hóa đơn
                        if (_hdser.getlsthdbfromDB().Any(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)) == true && _hdctser.getlsthdctfromDB().Any(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)) == false)
                        {
                            if (Convert.ToString(result) == _iQlyHangHoa.GetsList()
                            .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                            .Select(c => c.ChiTietHangHoa.Mavach).FirstOrDefault())
                            {



                                string content = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm", "Thêm Vào Giỏ Hàng", "",
                                    500, 300);
                                if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                    return;
                                }
                                if (Regex.IsMatch(content, @"^\d+$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                    return;
                                }
                                if (content.Length > 6)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content) < 0)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content) >= Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.SoLuong).FirstOrDefault()))
                                {
                                    MessageBox.Show("Số Lượng Không Đủ", "ERR");
                                    return;
                                }
                                if (content.Length > 0 && content != "0" && content.Length < 6)
                                {
                                    if (Convert.ToInt32(content) < Convert.ToInt32(_iQlyHangHoa.GetsList()
                                        .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                                        .Select(c => c.ChiTietHangHoa.SoLuong).FirstOrDefault()))
                                    {
                                        int countHDCT = _hdctser.getlsthdctfromDB().Max(x => x.IdhoaDonChiTiet) + 1;
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
                                            IdhoaDon = Convert.ToInt32(txt_idhoadoncho.Text),
                                            ThanhTien = Convert.ToDouble(Convert.ToInt32(content) * (_iQlyHangHoa.GetsList()
                                             .Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result))
                                            .Select(c => c.ChiTietHangHoa.DonGiaBan).FirstOrDefault()))
                                        };
                                        _hdctser.addhdct(hoaDonChiTiet);
                                        _hdctser.save();




                                        acdforsender();
                                        suynghiforsender();
                                        refreshcam();
                                        result = null;
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sản Phẩm Không Đủ Để Thêm", "Noticafition");

                                    }

                                    // pic_cam.Image = null;
                                }
                                else
                                {
                                    return;
                                }



                            }
                            return;
                        }
                        //xét tiếp đã tồn tại
                        //
                        var newwlist = _hdctser.getlsthdctfromDB().Where(x =>
                            x.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)).ToList();
                        //loop
                        for (int z = 0; z < dgrid_sanpham.Rows.Count; z++)
                        {

                            bool gg = newwlist.Any(c => c.IdthongTinHangHoa == idctt);
                            if (gg == true)
                            {//trùng
                                string content = Interaction.InputBox("Sản Phẩm Này Đã Có Trong Giỏ Hàng Mời Bạn Nhập Số Lượng Muốn Cập Nhật", "Cập Nhật Vào Giỏ Hàng", "",
                                         500, 300);
                                if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                    return;
                                }
                                if (Regex.IsMatch(content, @"^\d+$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                    return;
                                }
                                if (content.Length > 6)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content) < 0)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content) >= Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.SoLuong).FirstOrDefault()))
                                {
                                    MessageBox.Show("Số Lượng Không Đủ", "ERR");
                                    return;
                                }
                                if (content.Length > 0 && content != "0" && content.Length<6)
                                {
                                    foreach (var x in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)))
                                    {
                                        if (Convert.ToInt32(idctt) == x.IdthongTinHangHoa)
                                        {
                                            x.SoLuong = Convert.ToInt32(content);

                                            _hdctser.updatehdct(x);
                                            _hdctser.save();
                                        }

                                    }


                                    acdforsender();
                                    suynghiforsender();
                                    refreshcam();
                                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                                    txtTongTien.Text = Convert.ToString(Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat));
                                    txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                                    this.Alert("Cập nhật Thành Công");
                                    return;


                                }
                                else
                                {
                                    return;
                                }


                            }
                            //
                            else
                            {
                                //không trùng
                                string content1 = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm", "Thêm Vào Giỏ Hàng", "0",
                                  500, 300);
                                //thêm khác 0
                                if (Regex.IsMatch(content1, @"^[a-zA-Z0-9 ]*$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                    return;
                                }
                                if (Regex.IsMatch(content1, @"^\d+$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                    return;
                                }
                                if (content1.Length > 6)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content1) < 0)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(content1) >= Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.SoLuong).FirstOrDefault()))
                                {
                                    MessageBox.Show("Số Lượng Không Đủ", "ERR");
                                    return;
                                }
                                if (content1.Length > 0 && content1 != "0" && content1.Length < 6)
                                {
                                    int countHDCT = _hdctser.getlsthdctfromDB().Max(x => x.IdhoaDonChiTiet) + 1;
                                    IDHH = Convert.ToInt32(idctt);
                                    HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                                    {
                                        IdhoaDonChiTiet = countHDCT,
                                        MaHoaDonChiTiet = "HDCT000" + countHDCT,
                                        DonGia = Convert.ToDouble(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.DonGiaBan).FirstOrDefault()),
                                        SoLuong = Convert.ToInt32(content1),
                                        IdthongTinHangHoa = Convert.ToInt32(idctt),
                                        TrangThai = 1,
                                        IdhoaDon = Convert.ToInt32(txt_idhoadoncho.Text),
                                        ThanhTien = Convert.ToDouble(Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.Mavach == Convert.ToString(result)).Select(c => c.IdthongTinHangHoa).FirstOrDefault() * Convert.ToInt32(content1)))
                                    };


                                    _hdctser.addhdct(hoaDonChiTiet);
                                    _hdctser.save();


                                    acdforsender();
                                    suynghiforsender();
                                    refreshcam();
                                    int count = dgridGioHang.Rows.Count;
                                    tongtien = 0;
                                    for (int i = 0; i < count - 1; i++)
                                    {
                                        tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                                    }

                                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                                    txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                                    txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);


                                    this.Alert("Thêm Thành Công");
                                    return;
                                }
                                else
                                {
                                    return;
                                }



                            }
                        }
                    }
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

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

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }


        }

        private void dgridGioHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                //trường hợp 1//trường hợp sender
                if (txt_idhoadoncho.Text != "")
                {
                    var Dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
                    if (Dialog == DialogResult.Yes)
                    {

                        hdct = _hdctser.getlsthdctfromDB().FirstOrDefault(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[row].Cells[0].Value));
                        if (hdct != null)
                        {
                            foreach (var sp in _isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == hdct.IdthongTinHangHoa))
                            {
                                sp.SoLuong = Convert.ToString(Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == hdct.IdthongTinHangHoa).Select(c => c.SoLuong).FirstOrDefault()) + Convert.ToInt32(dgridGioHang.Rows[row].Cells["Số lượng"].Value));
                                _isercthh.updatechitiet(sp);
                                _isercthh.save(sp);
                            }





                            _hdctser.deletehdct(hdct);
                            _hdctser.save();
                            acdforsender();
                        }

                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }

                    }

                }////thiếu load lại sản phẩm


                //trường hợp 2// trường hợp của có hóa đơn rồi

                if (txt_idhoadoncho.Text == "")
                {
                    var Dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);
                    if (Dialog == DialogResult.Yes)
                    {

                        hdct = _hdctser.getlsthdctfromDB().FirstOrDefault(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[row].Cells[0].Value));
                        if (hdct != null)
                        {
                            foreach (var sp in _isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == hdct.IdthongTinHangHoa))
                            {
                                sp.SoLuong = Convert.ToString(Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == hdct.IdthongTinHangHoa).Select(c => c.SoLuong).FirstOrDefault()) + Convert.ToInt32(dgridGioHang.Rows[row].Cells["Số lượng"].Value));
                                _isercthh.updatechitiet(sp);
                                _isercthh.save(sp);
                            }





                            _hdctser.deletehdct(hdct);
                            _hdctser.save();
                            acd();
                        }

                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }

                    }
                }//thiếu load lại sản phẩm


            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }

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
            try
            {
                //trường hợp 1
                if (txt_idhoadoncho.Text == "")
                {
                    int row = e.RowIndex;
                    if (checkSoluong(Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value.ToString())) == false) return;
                    //kiểm tra xem đã có hóa đơn chi tiết chưa
                    if (_hdser.getlsthdbfromDB().Any(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)) == true && _hdctser.getlsthdctfromDB().Any(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)) == false)
                    {
                        string content = Interaction.InputBox("Mời Bạn Nhập Số Lượng Sản Phẩm Muốn Thêm ?", "Cập Nhật Vào Giỏ Hàng", "",
                               500, 300);
                        if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                            return;
                        }
                        if (Regex.IsMatch(content, @"^\d+$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                            return;
                        }
                        if (content.Length > 6)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) < 0)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) >= Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value))
                        {
                            MessageBox.Show("Số Lượng Không Đủ", "ERR");
                            return;
                        }
                        if (content.Length > 0 && content != "0"&& content.Length<6)
                        {
                            int countHDCT = _hdctser.getlsthdctfromDB().Max(x => x.IdhoaDonChiTiet) + 1;
                            IDHH = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString());
                            HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                            {
                                IdhoaDonChiTiet = countHDCT,
                                MaHoaDonChiTiet = "HDCT000" + countHDCT,
                                DonGia = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()),
                                SoLuong = Convert.ToInt32(content),
                                IdthongTinHangHoa = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()),
                                TrangThai = 1,
                                IdhoaDon = Convert.ToInt32(txt_createnew.Text),
                                ThanhTien = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[4].Value.ToString())
                            };


                            _hdctser.addhdct(hoaDonChiTiet);
                            _hdctser.save();


                            acd();

                            int count = dgridGioHang.Rows.Count;
                            tongtien = 0;
                            for (int i = 0; i < count - 1; i++)
                            {
                                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                            }

                            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                            txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                            txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                            suynghi();
                        }
                        else
                        {
                            return;
                        }


                        return;
                    }


                    var newwlist = _hdctser.getlsthdctfromDB().Where(x =>
                            x.IdhoaDon == Convert.ToInt32(txt_createnew.Text)).ToList();
                    //kiểm tra đã tồn tại trong giỏ hàng
                    bool gg = newwlist.Any(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value));
                    if (gg == true)
                    {
                        string content = Interaction.InputBox("Sản Phẩm Này Đã Có Trong Giỏ Hàng Mời Bạn Nhập Số Lượng Muốn Cập Nhật", "Cập Nhật Vào Giỏ Hàng", "",
                                 500, 300);
                        if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                            return;
                        }
                        if (Regex.IsMatch(content, @"^\d+$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                            return;
                        }
                        if (content.Length > 6)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) < 0)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) >= Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value))
                        {
                            MessageBox.Show("Số Lượng Không Đủ", "ERR");
                            return;
                        }
                        if (content.Length > 0 && content != "0"&&content.Length<6)
                        {
                            foreach (var x in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)))
                            {
                                if (Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()) == x.IdthongTinHangHoa)
                                {
                                    x.SoLuong = Convert.ToInt32(content);

                                    _hdctser.updatehdct(x);
                                    _hdctser.save();
                                }

                            }


                            acd();


                            int count = dgridGioHang.Rows.Count;
                            tongtien = 0;
                            for (int i = 0; i < count - 1; i++)
                            {
                                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString()); //i++;
                            }

                            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                            txtTongTien.Text = Convert.ToString(Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat));
                            txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                            this.Alert("Cập nhật Thành Công");
                            suynghi();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {

                        string content1 = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm", "Thêm Vào Giỏ Hàng", "",
                          500, 300);
                        //thêm khác 0
                        if (Regex.IsMatch(content1, @"^[a-zA-Z0-9 ]*$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                            return;
                        }
                        if (Regex.IsMatch(content1, @"^\d+$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                            return;
                        }
                        if (content1.Length > 6)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content1) < 0)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content1) >= Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value))
                        {
                            MessageBox.Show("Số Lượng Không Đủ", "ERR");
                            return;
                        }
                        if (content1.Length > 0 && content1 != "0"&&content1.Length<6 )
                        {
                            int countHDCT = _hdctser.getlsthdctfromDB().Max(x => x.IdhoaDonChiTiet) + 1;
                            IDHH = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString());
                            HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                            {
                                IdhoaDonChiTiet = countHDCT,
                                MaHoaDonChiTiet = "HDCT000" + countHDCT,
                                DonGia = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()),
                                SoLuong = Convert.ToInt32(content1),
                                IdthongTinHangHoa = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()),
                                TrangThai = 1,
                                IdhoaDon = Convert.ToInt32(txt_createnew.Text),
                                ThanhTien = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[4].Value.ToString())
                            };


                            _hdctser.addhdct(hoaDonChiTiet);
                            _hdctser.save();



                            acd();

                            int count = dgridGioHang.Rows.Count;
                            tongtien = 0;
                            for (int i = 0; i < count - 1; i++)
                            {
                                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                            }

                            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                            txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                            txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);


                            this.Alert("Thêm Thành Công");
                            suynghi();
                        }
                        //
                        else
                        {
                            return;
                        }


                    }


                }





                // trường hợp 2done(sender)
                if (txt_idhoadoncho.Text != "")
                {
                    int row = e.RowIndex;
                    if (checkSoluong(Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value.ToString())) == false) return;
                    //kiểm tra xem đã có hóa đơn chi tiết chưa
                    if (_hdser.getlsthdbfromDB().Any(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)) == true && _hdctser.getlsthdctfromDB().Any(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)) == false)
                    {
                        string content = Interaction.InputBox("Mời Bạn Nhập Số Lượng Sản Phẩm Muốn Thêm ?", "Cập Nhật Vào Giỏ Hàng", "",
                               500, 300);
                        if (content.Length > 0 && content != "0" && content.Length < 6)
                        {
                            if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                            {

                                MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                return;
                            }
                            if (Regex.IsMatch(content, @"^\d+$") == false)
                            {

                                MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                return;
                            }
                            if (content.Length > 6)
                            {
                                MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                return;
                            }
                            if (Convert.ToInt32(content) < 0)
                            {
                                MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                                return;
                            }
                            if (Convert.ToInt32(content) >= Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value))
                            {
                                MessageBox.Show("Số Lượng Không Đủ", "ERR");
                                return;
                            }
                            int countHDCT = _hdctser.getlsthdctfromDB().Max(x => x.IdhoaDonChiTiet) + 1;
                            IDHH = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString());
                            HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                            {
                                IdhoaDonChiTiet = countHDCT,
                                MaHoaDonChiTiet = "HDCT000" + countHDCT,
                                DonGia = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()),
                                SoLuong = Convert.ToInt32(content),
                                IdthongTinHangHoa = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()),
                                TrangThai = 1,
                                IdhoaDon = Convert.ToInt32(txt_idhoadoncho.Text),
                                ThanhTien = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[4].Value.ToString())
                            };


                            _hdctser.addhdct(hoaDonChiTiet);
                            _hdctser.save();


                            acdforsender();

                            int count = dgridGioHang.Rows.Count;
                            tongtien = 0;
                            for (int i = 0; i < count - 1; i++)
                            {
                                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                            }

                            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                            txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                            txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                            suynghiforsender();
                        }
                        else
                        {
                            return;
                        }


                        return;
                    }




                    var newwlist = _hdctser.getlsthdctfromDB().Where(x =>
                            x.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)).ToList();

                    bool gg = newwlist.Any(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value));
                    if (gg == true)
                    {
                        string content = Interaction.InputBox("Sản Phẩm Này Đã Có Trong Giỏ Hàng Mời Bạn Nhập Số Lượng Muốn Cập Nhật", "Cập Nhật Vào Giỏ Hàng", "",
                                 500, 300);
                        if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                            return;
                        }
                        if (Regex.IsMatch(content, @"^\d+$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                            return;
                        }
                        if (content.Length > 6)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) < 0)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) >= Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value))
                        {
                            MessageBox.Show("Số Lượng Không Đủ", "ERR");
                            return;
                        }
                        if (content != "0" && content.Length > 0 && content.Length < 6)
                        {
                            foreach (var x in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)))
                            {
                                if (Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()) == x.IdthongTinHangHoa)
                                {
                                    x.SoLuong = Convert.ToInt32(content);

                                    _hdctser.updatehdct(x);
                                    _hdctser.save();
                                }

                            }


                            acdforsender();

                            suynghiforsender();
                            int count = dgridGioHang.Rows.Count;
                            tongtien = 0;
                            for (int i = 0; i < count - 1; i++)
                            {
                                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString()); //i++;
                            }

                            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                            txtTongTien.Text = Convert.ToString(Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat));
                            txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                            this.Alert("Cập nhật Thành Công");
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {

                        string content1 = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm", "Thêm Vào Giỏ Hàng", "",
                          500, 300);
                        //thêm khác 0
                        if (Regex.IsMatch(content1, @"^[a-zA-Z0-9 ]*$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                            return;
                        }
                        if (Regex.IsMatch(content1, @"^\d+$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                            return;
                        }
                        if (content1.Length > 6)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content1) < 0)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content1) >= Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[5].Value))
                        {
                            MessageBox.Show("Số Lượng Không Đủ", "ERR");
                            return;
                        }
                        if (content1 != "0" && content1.Length > 0 && content1.Length < 6)
                        {
                            int countHDCT = _hdctser.getlsthdctfromDB().Max(x => x.IdhoaDonChiTiet) + 1;
                            IDHH = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString());
                            HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                            {
                                IdhoaDonChiTiet = countHDCT,
                                MaHoaDonChiTiet = "HDCT000" + countHDCT,
                                DonGia = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()),
                                SoLuong = Convert.ToInt32(content1),
                                IdthongTinHangHoa = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()),
                                TrangThai = 1,
                                IdhoaDon = Convert.ToInt32(txt_idhoadoncho.Text),
                                ThanhTien = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[4].Value.ToString())
                            };


                            _hdctser.addhdct(hoaDonChiTiet);
                            _hdctser.save();


                            acdforsender();
                            suynghiforsender();
                            int count = dgridGioHang.Rows.Count;
                            tongtien = 0;
                            for (int i = 0; i < count - 1; i++)
                            {
                                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                            }

                            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                            txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                            txt_dathangtongtien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);


                            this.Alert("Thêm Thành Công");
                            return;
                        }
                        //
                        else
                        {
                            return;
                        }

                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }


        }

        bool checkdiem(string diem)
        {
              int iddtd = Convert.ToInt32(_iQlyKhachHang.GetsListKH().Where(x => x.Email == txtEmail.Text)
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
            try
            {
                string thienthua = Convert.ToString(txtTienthua.Text);
                string fntienthua = thienthua.Replace(".", "");
                if (String.IsNullOrEmpty(txtTongTien.Text))
                {
                    MessageBox.Show("Giỏ hàng rỗng", "Thông báo");
                    return;
                }
                if (String.IsNullOrEmpty(txtTienthua.Text) || Convert.ToInt32(fntienthua) < 0)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại tiền khách trả", "Thông báo");
                    return;
                }
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
                        var count = from b in _iQlyHangHoa.GetsListCTHH()
                                    join c in _iQlyHoaDon.GetsListHDCT() on b.IdthongTinHangHoa equals c.IdthongTinHangHoa
                                    where b.IdthongTinHangHoa == c.IdthongTinHangHoa
                                    select b;



                        var price = from a in _iQlyHoaDon.GetsListHDCT()
                                    where a.IdhoaDon == Convert.ToInt32(txtMaHDD.Text)
                                    select a;
                        foreach (var x in price.ToList())
                        {
                            _iQlyHoaDon.removeHDCT(x);
                            _iQlyHoaDon.SaveHDCT();
                        }

                    }
                    string aa = Convert.ToString(txtKhachTra.Text);
                    string fn = aa.Replace(".", "");
                    string bb = Convert.ToString(txtTongTien.Text);
                    string fn1 = bb.Replace(".", "");

                    foreach (var x in _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)))
                    {
                        x.TrangThai = Convert.ToInt32(status);
                        x.NgayLap = DateTime.Now;
                        x.IdkhachHang = _ikhser.getlstkhachhangformDB().Where(c => c.Email == txtEmail.Text).Select(c => c.IdkhachHang).FirstOrDefault();
                        x.Iduser = _invser.getlstnhanvienfromDB().Where(c => c.TenNhanVien == cbxNV.Text)
                        .Select(c => c.Iduser).FirstOrDefault();
                        x.Tien = float.Parse(fn1);
                        x.TongSoTien = float.Parse(fn);
                        x.GhiChu = Convert.ToString(richTextBox1.Text);
                        x.Thue = Convert.ToDouble(textBox2.Text);
                        x.TienCoc = 0;

                        _hdser.updatehdb(x);
                        _hdser.save();
                        suynghiforthanhtoan();
                    }



                    try
                    {
                        int max = _hdser.getlsthdbfromDB().Max(c => c.IdhoaDon);


                        foreach (var x in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == max))
                        {
                            string gg = Convert.ToString(textBox2.Text);
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
                    loadsanphamsender();
                    clear();
                    txtMaHDD.Text = "";
                    _lstHoaDonChiTiets.Clear();
                    return;
                }
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }

        }
        private void button5_Click_2(object sender, EventArgs e)
        {
            try
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
                    //
                    foreach (var x in _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)))
                    {
                        x.TrangThai = Convert.ToInt32(statusdt);
                        x.NgayLap = DateTime.Now;
                        x.IdkhachHang = _ikhser.getlstkhachhangformDB().Where(c => c.Email == txtEmail.Text).Select(c => c.IdkhachHang).FirstOrDefault();
                        x.Iduser = _invser.getlstnhanvienfromDB().Where(c => c.TenNhanVien == cbxNV.Text)
                        .Select(c => c.Iduser).FirstOrDefault();
                        x.Tien = float.Parse(fn1);
                        x.TongSoTien = float.Parse(fn);
                        x.GhiChu = Convert.ToString(rtx_ghichu2.Text);
                        x.TienCoc = Convert.ToDouble(fn2);
                        x.NgayShipHang = Convert.ToDateTime(dtp_ship.Value);
                        x.NgayNhanHang = Convert.ToDateTime(dtp_nhanhang.Value);
                        x.GhiChu = Convert.ToString(rtx_ghichu2.Text);
                        x.Thue = Convert.ToDouble(txt_dathangthue.Text);
                        _hdser.updatehdb(x);
                        _hdser.save();
                        suynghiforthanhtoan();

                    }






                    try
                    {
                        int max = _hdser.getlsthdbfromDB().Max(c => c.IdhoaDon);


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
                    clear();
                    txtMaHDD.Text = "";
                    _lstHoaDonChiTiets.Clear();
                    loadsanphamsender();
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
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
              string[] unitNumbers = new string[]
                        {"không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"};
                string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    decimal a, b;
                    a = Decimal.Parse(txtTongTien.Text);
                    b = Decimal.Parse(txtKhachDua.Text);
                    txtTienthua.Text = (b - a).ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Bạn nhập vào phải là số"+ exception.Message, "Thông báo");
            }
        }

        private void btnsender_Click(object sender, EventArgs e)
        {
            try
            {
                dgridGioHang.Rows.Clear();

                int acbc = ((sender as Button).Tag as HoaDonBan).IdhoaDon;
                txt_idhoadoncho.Text = Convert.ToString(acbc);
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
                foreach (var x in _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == acbc))
                {
                    var qlhh = _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == x.IdthongTinHangHoa).FirstOrDefault();
                    var hh = _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == qlhh.ChiTietHangHoa.IdhangHoa).FirstOrDefault();
                    dgridGioHang.Rows.Add(x.IdhoaDonChiTiet,
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.MaHangHoa).FirstOrDefault(),
                        _iQlyHangHoa.GetsList().Where(c => c.HangHoa.IdhangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.HangHoa.TenHangHoa).FirstOrDefault() + " " +
                        _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.IdthongTinHangHoa == x.IdthongTinHangHoa)
                            .Select(c => c.ChiTietHangHoa.Model).FirstOrDefault(), x.SoLuong,
                        x.DonGia, x.SoLuong * x.DonGia);
                }
                //đăt hàng
                if (_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(x => x.TrangThai).FirstOrDefault() == 3)
                {
                    pn_dathang.Visible = true;
                    btnThanhToan.Visible = false;
                    button5.Visible = false;
                    btnDathang.Visible = false;
                    button7.Visible = true;
                    button4.Visible = false;
                    int nvc = Convert.ToInt32(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(x => x.Iduser).FirstOrDefault());
                    int khc = Convert.ToInt32(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(x => x.IdkhachHang).FirstOrDefault());
                    cbxNV.Text = Convert.ToString(_invser.getlstnhanvienfromDB().Where(c => c.Iduser == nvc).Select(c => c.TenNhanVien).FirstOrDefault());
                    cbxKH.Text = Convert.ToString(_ikhser.getlstkhachhangformDB().Where(c => c.IdkhachHang == khc).Select(c => c.TenKhachHang).FirstOrDefault());
                    rbt_chuathanhtoan.Checked = false;
                    //
                    double tongtiendathang = Convert.ToDouble(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.Tien).FirstOrDefault());

                    double thuedathang = Convert.ToDouble(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.Thue).FirstOrDefault());

                    double thanhtiendathang = Convert.ToDouble(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.TongSoTien).FirstOrDefault());

                    double giamgiadathang = Convert.ToDouble(_hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.GiamGia).FirstOrDefault());

                    DateTime? ngayship = Convert.ToDateTime(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.NgayShipHang).FirstOrDefault());

                    DateTime? ngaydukien = Convert.ToDateTime(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.NgayNhanHang).FirstOrDefault());

                    double tiencoc = Convert.ToDouble(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.TienCoc).FirstOrDefault());
                    string ghichu = Convert.ToString(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.GhiChu).FirstOrDefault());
                    btnDathang.Visible = false;
                    btnThanhToan.Visible = false;//
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    int count = dgridGioHang.Rows.Count;
                    double tongtiendat = 0;
                    for (int i = 0; i < count - 1; i++)
                    {
                        tongtiendat += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString()); //i++;
                    }
                    txt_dathangtongtien.Text = Convert.ToInt32(tongtiendat).ToString("#,###", cul.NumberFormat);
                    txt_dathanggiamgia.Text = Convert.ToString(giamgiadathang);
                    txt_dathangthue.Text = Convert.ToString(thuedathang);
                    txt_dathangkhachtra.Text = Convert.ToInt32(thanhtiendathang).ToString("#,###", cul.NumberFormat);
                    txt_coc.Text = Convert.ToInt32(tiencoc).ToString("#,###", cul.NumberFormat);
                    rtx_ghichu2.Text = Convert.ToString(ghichu);
                    //dtp_nhanhang.Value =Convert.ToDateTime( ngaydukien.Value.ToString("MM-dd-yyyy"));
                    //dtp_ship.Value =Convert.ToDateTime( ngayship.Value.ToString("MM-dd-yyyy"));

                }
                //tại quầy
                if (_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(x => x.TrangThai).FirstOrDefault() == 2)
                {
                    pn_dathang.Visible = false;

                    btnThanhToan.Visible = false;//
                    button5.Visible = false;
                    btnDathang.Visible = false;
                    button7.Visible = true;
                    button4.Visible = false;
                    int nvc = Convert.ToInt32(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(x => x.Iduser).FirstOrDefault());
                    int khc = Convert.ToInt32(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(x => x.IdkhachHang).FirstOrDefault());
                    cbxNV.Text = Convert.ToString(_invser.getlstnhanvienfromDB().Where(c => c.Iduser == nvc).Select(c => c.TenNhanVien).FirstOrDefault());
                    cbxKH.Text = Convert.ToString(_ikhser.getlstkhachhangformDB().Where(c => c.IdkhachHang == khc).Select(c => c.TenKhachHang).FirstOrDefault());
                    rbt_dathangchuathanhtoan.Checked = false;
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    int count = dgridGioHang.Rows.Count;
                    tongtien = 0;
                    for (int i = 0; i < count - 1; i++)
                    {
                        tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString()); //i++;
                    }
                    double tongtientaiquan = Convert.ToDouble(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.TongSoTien).FirstOrDefault());

                    double thuetaiquan = Convert.ToDouble(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.Thue).FirstOrDefault());

                    double thanhtien = Convert.ToDouble(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.Tien).FirstOrDefault());

                    double giamgiataiquan = Convert.ToDouble(_hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.GiamGia).FirstOrDefault());
                    string ghichutaiquan = Convert.ToString(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == acbc).Select(c => c.GhiChu).FirstOrDefault());
                    txtTongTien.Text = Convert.ToInt32(tongtien).ToString("#,###", cul.NumberFormat);
                    txtKhachTra.Text = Convert.ToInt32(tongtientaiquan).ToString("#,###", cul.NumberFormat);
                    textBox2.Text = Convert.ToString(thuetaiquan);
                    txtDiscount.Text = Convert.ToString(giamgiataiquan);
                    button5.Visible = false;
                    btnThanhToan.Visible = false;//
                    richTextBox1.Text = Convert.ToString(ghichutaiquan);










                }
                txtMaHDD.Text = Convert.ToString(_hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == acbc).Select(x => x.IdhoaDon)
                    .FirstOrDefault());

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }

        }

        public void loadhoadonduyet()
        {
            try
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
                    btn.ForeColor = Color.Aquamarine;
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
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        void clear()
        {
            try
            {
                txtDiscount.Text = "0";
                textBox2.Text = "0";
                txtTongTien.Text = "0";
                txtKhachTra.Text = "0";
                txtKhachDua.Text = "0";
                txtTienthua.Text = "0";
                rbt_chuathanhtoan.Checked = true;
                richTextBox1.Text = "";
                txt_dathanggiamgia.Text = "0";
                txt_dathangthue.Text = "0";
                txt_coc.Text = "0";
                txt_dathangtongtien.Text = "0";
                 ckbIn.Checked = false;
                rbt_dathangchuathanhtoan.Checked = true;
                cbxKH.Text = default;
                cbxNV.Text = default;
                cbxKH.Text = default;
                txt_idhoadoncho.Text = "";
                txt_createnew.Text = "";
                btnDathang.Visible = true;
                btnThanhToan.Visible = true;//
                button7.Visible = false;
                button5.Visible = true;
                btnDathang.Visible = true;
                txt_dathangkhachtra.Text = "0";
                flhd3.Visible = true;
                flhoadon.Visible = true;
                button4.Visible = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        public void loadhoadonduyet3()
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

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
            try
            {
                //trường hợp 1 của hóa đơn!!!!!!!!!!!!
                if (txt_idhoadoncho.Text == "")
                {
                    var w = pDHoaDon.DefaultPageSettings.PaperSize.Width;
                    //Lấy tên cửa hàng

                    e.Graphics.DrawString(
                        "PerSoft Perfume".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black,
                        new PointF(100, 20));
                    //Mã hóa đơn

                    e.Graphics.DrawString(
                        String.Format("{0}", _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)).Select(c => c.MaHoaDon).FirstOrDefault()),
                        new Font("Courier New", 12, FontStyle.Bold),
                        Brushes.Black, new PointF(w / 2 + 200, 20));



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
                    var list = _hdctser.getlsthdctfromDB().Where(x => x.IdhoaDon == Convert.ToInt32(txt_createnew.Text));

                    int i = 1;
                    y += 20;
                    foreach (var x in _hdctser.getlsthdctfromDB().Where(x => x.IdhoaDon == Convert.ToInt32(txt_createnew.Text)))
                    {
                        e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black,
                            new Point(10, y));
                        e.Graphics.DrawString("" + _iserhh.getlsthanghoafromDB()
                                                  .Where(c => c.IdhangHoa == x.IdthongTinHangHoa)
                                                  .Select(c => c.TenHangHoa).FirstOrDefault() + " " +
                                              _isercthh.getlstchitietthanghoafromDB().Where(c =>
                                                      c.IdthongTinHangHoa == x.IdthongTinHangHoa)
                                                  .Select(c => c.Model).FirstOrDefault(),
                            new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", x.SoLuong), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w / 2, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", x.DonGia), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w / 2 + 100, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", Convert.ToInt32(Convert.ToInt32(x.SoLuong) * Convert.ToInt32(x.DonGia))), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w - 200, y));
                        y += 20;
                    }

                    y += 40;
                    p1 = new Point(10, y);
                    p2 = new Point(w - 10, y);
                    e.Graphics.DrawLine(blackPEn, p1, p2);

                    string tt = Convert.ToString(txtTongTien.Text);
                    string fn = tt.Replace(".", "");
                    y += 20;
                    e.Graphics.DrawString(string.Format("Tổng tiền :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                        new Point(w / 2, y));
                    e.Graphics.DrawString(txtKhachTra.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
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
                        string.Format("Thành chữ : {0} VND", NumberToText(Convert.ToDouble(fn))),
                        new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 30, y));
                }
                // trường hợp 2 của hóa đơn chờ
                if (txt_idhoadoncho.Text != "")
                {
                    var w = pDHoaDon.DefaultPageSettings.PaperSize.Width;
                    //Lấy tên cửa hàng

                    e.Graphics.DrawString(
                        "PerSoft Perfume".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black,
                        new PointF(100, 20));
                    //Mã hóa đơn

                    e.Graphics.DrawString(
                        String.Format("{0}", _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)).Select(c => c.MaHoaDon).FirstOrDefault()),
                        new Font("Courier New", 12, FontStyle.Bold),
                        Brushes.Black, new PointF(w / 2 + 200, 20));



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
                    var list = _hdctser.getlsthdctfromDB().Where(x => x.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text));

                    int i = 1;
                    y += 20;
                    foreach (var x in _hdctser.getlsthdctfromDB().Where(x => x.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)))
                    {
                        e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black,
                            new Point(10, y));
                        e.Graphics.DrawString("" + _iserhh.getlsthanghoafromDB()
                                                  .Where(c => c.IdhangHoa == x.IdthongTinHangHoa)
                                                  .Select(c => c.TenHangHoa).FirstOrDefault() + " " +
                                              _isercthh.getlstchitietthanghoafromDB().Where(c =>
                                                      c.IdthongTinHangHoa == x.IdthongTinHangHoa)
                                                  .Select(c => c.Model).FirstOrDefault(),
                            new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", x.SoLuong), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w / 2, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", x.DonGia), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w / 2 + 100, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", Convert.ToInt32(Convert.ToInt32(x.SoLuong) * Convert.ToInt32(x.DonGia))), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w - 200, y));
                        y += 20;
                    }

                    y += 40;
                    p1 = new Point(10, y);
                    p2 = new Point(w - 10, y);
                    e.Graphics.DrawLine(blackPEn, p1, p2);

                    string tt = Convert.ToString(txtTongTien.Text);
                    string fn = tt.Replace(".", "");
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
                        string.Format("Thành chữ : {0} VND", NumberToText(Convert.ToDouble(fn))),
                        new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 30, y));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
               
            }
           
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
        }
        private void cbxKH_SelectedValueChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex )
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ 19008298");
                return;
            }
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
                    TrangThai = 2,
                    NgayLap=DateTime.Now
                    
                    


                };
                _lstHoaDonBans.Add(hoaDonBan);
                _hdser.addhdb(hoaDonBan);
                _hdser.save();
                txtMaHDD.Text = Convert.ToString(_lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault());
                txt_createnew.Text =Convert.ToString( _hdser.getlsthdbfromDB().Max(c => c.IdhoaDon));
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
                        x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.SoLuong, txt_createnew.Text, x.Anh.DuongDan);
                }

                dcmmm();
                loadhoadonduyet();
                loadhoadonduyet3();
                flhd3.Visible = false;
                flhoadon.Visible = false;
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
            try
            {
                BanHang fbanhang = new BanHang();
                //int iddtd = Convert.ToInt32(_iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                //    .Select(x => x.IddiemTieuDung).FirstOrDefault());
                //////SetBounds(Screen.GetWorkingArea(f).Width-Width,Screen.GetWorkingArea(f).Height-Height,Width-1000,Height+300);
                var id = _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text).Select(c => c.IddiemTieuDung)
                    .FirstOrDefault();
                fLichSuDungDiem f = new fLichSuDungDiem();
                f.txtMa.Text = Convert.ToString(Convert.ToInt32(id));
                f.lblTenKH.Text = cbxKH.Text;
                f.lblBacKH.Text = cbxRank.Text;
                f.lblMaKH.Text = Convert.ToString(_iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                    .Select(c => c.MaKhachHang)
                    .FirstOrDefault());
                f.lblDiem.Text = Convert.ToString(_iQlyKhachHang.GetsListDTD().Where(x => x.IddiemTieuDung == id)
                    .Select(c => c.SoDiem)
                    .FirstOrDefault());
                f.StartPosition = FormStartPosition.CenterScreen;
                f.StartPosition = FormStartPosition.Manual;
                //f.Location = new Point(fbanhang.Width / 2 - f.Width / 2 + fbanhang.Location.X,
                //    fbanhang.Height / 2 - f.Height / 2 + fbanhang.Location.Y);
                f.Location = new Point(f.Width + 762, 260);
                f.lblTenKH.Text = cbxKH.Text;
                f.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pic_cam.Image != null)
            {
                // pic_cam.Image = null;
              //  pic_cam.Refresh();
                pic_cam.Image = null;
                pic_cam.ImageLocation = null;
                //pic_cam.Image = null;
                pic_cam.Update();
            }
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
            try
            {
                if (Regex.IsMatch(txtKhachDua.Text, @"^[a-zA-Z0-9 ]*$") == false)
                {

                    MessageBox.Show("Tiền hách đưa không được chứa ký tự đặc biệt", "ERR");
                    return;
                }
                if (Regex.IsMatch(txtKhachDua.Text, @"^\d+$") == false)
                {

                    MessageBox.Show("Tiền khách đưa không được chứa ký tự đặc biệt", "ERR");
                    return;
                }
                if (txtKhachDua.Text.Length > 13)
                {
                    MessageBox.Show("Tiền Khách Đưa Không Cho Phép", "ERR");
                    return;
                }
                if (Convert.ToInt32(txtKhachDua.Text) < 0)
                {
                    MessageBox.Show("Tiền Khách Đưa Không Cho Phép Âm", "ERR");
                    return;
                }
               
                //
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
                string help = txtDiscount.Text;
                string fnal = help.Replace(".", "");
                if (Regex.IsMatch(fnal, @"^[a-zA-Z0-9 ]*$") == false)
                {

                    MessageBox.Show("giảm giá không được chứa ký tự đặc biệt", "ERR");
                    return;
                }
                
                if (Regex.IsMatch(fnal, @"^\d+$") == false)
                {

                    MessageBox.Show("giảm giá không được chứa ký tự ", "ERR");
                    return;
                }
                if (Regex.IsMatch(fnal, @"^[a-zA-Z0-9 ]*$") == false)
                if (fnal.Length > 6)
                {
                    MessageBox.Show("giảm giá Không Cho Phép", "ERR");
                    return;
                }
                if (Convert.ToInt32(fnal) < 0)
                {
                    MessageBox.Show("giảm giá Không Cho Phép Âm", "ERR");
                    return;
                }
                if (Convert.ToInt32(fnal.Length) >= 5)
                {
                    MessageBox.Show("giảm giá không được vượt quá 10000 ", "ERR");
                    return;
                }
                //
                if (txtDiscount.Text != "0" && textBox2.Text != "0")
                {
                    if (txtTongTien.Text != "0")
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
                        //  txtKhachDua.Text = Convert.ToInt32(khach).ToString("#,###", cul.NumberFormat);
                    }


                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Bạn phải nhập vào số nguyên" + fe);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string help = textBox2.Text;
                string fnal1 = help.Replace(".", "");
                if (Regex.IsMatch(fnal1, @"^[a-zA-Z0-9 ]*$") == false)
                {

                    MessageBox.Show("Thuế đưa không được chứa ký tự đặc biệt", "ERR");
                    return;
                }
                
                    if (Regex.IsMatch(fnal1, @"^\d+$") == false)
                    {

                        MessageBox.Show("Thuế, khách đưa không được chứa ký tự", "ERR");
                        return;
                    }
                if (Regex.IsMatch(fnal1, @"^[a-zA-Z0-9 ]*$") == false)
                    if (fnal1.Length > 6)
                    {
                        MessageBox.Show("thuế Không Cho Phép", "ERR");
                        return;
                    }
                if (Convert.ToInt32(fnal1) < 0)
                {
                    MessageBox.Show("thuế Không Cho Phép Âm", "ERR");
                    return;
                }
                if (Convert.ToInt32(fnal1.Length) >= 5)
                {
                    MessageBox.Show("thuế không được vượt quá 10000 ", "ERR");
                    return;
                }
                if (txtDiscount.Text != "0" && textBox2.Text != "0")
                {
                    if (txtTongTien.Text != "0")
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
                        //  txtKhachDua.Text = Convert.ToInt32(khach).ToString("#,###", cul.NumberFormat);
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Không Được Chứa Chữ Cái Hoặc Kí Tự Đặc Biệt{}");
                return;
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
            try
            {
                if (txt_dathangthue.Text != "0" && txt_dathanggiamgia.Text != "0")
                {


                    if (txt_dathangtongtien.Text != "0")
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Không Được Chứa Chữ Cái Hoặc Kí Tự Đặc Biệt");
                return;
            }
        }

        private void dgridGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        void LoadGioHang2()
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
        }
        private void txt_dathangthue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string help = txt_dathangthue.Text;
                string fnal2 = help.Replace(".", "");
                if (Regex.IsMatch(fnal2, @"^[a-zA-Z0-9 ]*$") == false)
                {

                    MessageBox.Show("Thuế đưa không được chứa ký tự đặc biệt", "ERR");
                    return;
                }
               
                    if (Regex.IsMatch(fnal2, @"^\d+$") == false)
                    {

                        MessageBox.Show("Thuế, không được chứa chữ", "ERR");
                        return;
                    }
             
                    if (fnal2.Length > 6)
                    {
                        MessageBox.Show("thuế Không Cho Phép", "ERR");
                        return;
                    }
                if (Convert.ToInt32(fnal2) < 0)
                {
                    MessageBox.Show("thuế Không Cho Phép Âm", "ERR");
                    return;
                }
                if (Convert.ToInt32(fnal2.Length) >= 5)
                {
                    MessageBox.Show("thuế không được vượt quá 10000 ", "ERR");
                    return;
                }
                if (txt_dathangthue.Text != "0" && txt_dathanggiamgia.Text != "0")
                {


                    if (txt_dathangtongtien.Text != "0")
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
            }
            catch (Exception ex)
            {


                MessageBox.Show(Convert.ToString(ex.Message), "Không Được Nhập Chữ Hoặc Kí Tự Đặc Biệt");
                return;
            }
        }

        private void txt_dathanggiamgia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string help = txt_dathanggiamgia.Text;
                string fnal3 = help.Replace(".", "");
                if (Regex.IsMatch(fnal3, @"^[a-zA-Z0-9 ]*$") == false)
                {

                    MessageBox.Show("giảm giá không được chứa ký tự đặc biệt", "ERR");
                    return;
                }

                if (Regex.IsMatch(fnal3, @"^\d+$") == false)
                {

                    MessageBox.Show("giảm giá không được chứa ký tự ", "ERR");
                    return;
                }
               
                    if (fnal3.Length > 6)
                    {
                        MessageBox.Show("giảm giá Không Cho Phép", "ERR");
                        return;
                    }
                if (Convert.ToInt32(fnal3) < 0)
                {
                    MessageBox.Show("giảm giá Không Cho Phép Âm", "ERR");
                    return;
                }
                if (Convert.ToInt32(fnal3.Length) >= 5)
                {
                    MessageBox.Show("giảm giá không được vượt quá 10000 ", "ERR");
                    return;
                }
                //
                if (txt_dathangthue.Text != "0" && txt_dathanggiamgia.Text != "0")
                {


                    if (txt_dathangtongtien.Text != "0")
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Không Được Nhập Chữ Hoặc Kí Tự Đặc Biệt1");
                return;
            }
        }

        

        private void txt_dathangtongtien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (pn_dathang.Visible == true && txt_createnew.Text != "")
                {
                    string coc = txt_dathangtongtien.Text;
                    string fncoc = coc.Replace(".", "");
                    if (Convert.ToInt32(fncoc) > 2000000)
                    {
                        double fcoc = Convert.ToInt32(fncoc) * 0.3;
                        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                        txt_coc.Text = Convert.ToInt32(fcoc).ToString("#,###", cul.NumberFormat);


                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Không Được Nhập Chữ Hoặc Kí Tự Đặc Biệt1");
                return;
            }
          
           
        }
        void suynghi()
        {

            try
            {
                for (int i = 0; i < dgrid_sanpham.RowCount; i++)
                {
                    var newwlist = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)).ToList();
                    bool gg = newwlist.Any(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[1].Value));
                    if (gg == true)
                    {

                        dgrid_sanpham.Rows[i].Cells[5].Value = Convert.ToInt32(Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[5].Value) - Convert.ToInt32(newwlist.Where(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[1].Value)).Select(c => c.SoLuong).FirstOrDefault()));



                    }
                }
            }
            catch (Exception ex)
            {


                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
        }
        
        void suynghiforthanhtoan()// đã có mã hóa đơn sẵn(cập nhật số lượng)
        {

            try
            {
                for (int i = 0; i < dgrid_sanpham.RowCount; i++)
                {
                    var newwlist = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_createnew.Text)).ToList();
                    bool gg = newwlist.Any(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[1].Value));
                    if (gg == true)
                    {



                        foreach (var x in _isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[1].Value)))
                        {
                            x.SoLuong = Convert.ToString(dgrid_sanpham.Rows[i].Cells[5].Value);
                            _isercthh.updatechitiet(x);
                            _isercthh.save(x);

                        }

                    }
                }
            }
            catch (Exception ex)
            {


                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
        }
        //
        void capnhatsoluongsender()// đã có mã hóa đơn sẵn(cập nhật số lượng)
        {

            try
            {
                for (int i = 0; i < dgrid_sanpham.RowCount; i++)
                {
                    var newwlist = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)).ToList();
                    bool gg = newwlist.Any(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[1].Value));
                    if (gg == true)
                    {



                        foreach (var x in _isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[1].Value)))
                        {
                            x.SoLuong = Convert.ToString(dgrid_sanpham.Rows[i].Cells[5].Value);
                            _isercthh.updatechitiet(x);
                            _isercthh.save(x);

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
        }
        void suynghiforsender()
        {

            try
            {
                for (int i = 0; i < dgrid_sanpham.RowCount; i++)
                {
                    var newwlist = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(txt_idhoadoncho.Text)).ToList();
                    bool gg = newwlist.Any(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[1].Value));
                    if (gg == true)
                    {

                        dgrid_sanpham.Rows[i].Cells[5].Value = Convert.ToInt32(Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[5].Value) - Convert.ToInt32(newwlist.Where(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[i].Cells[1].Value)).Select(c => c.SoLuong).FirstOrDefault()));



                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
        }
        private void btn_reload_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Reaload Lại Hay Không ?", "Thông Báo",
                     MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                LoadHDCT();
                clear();
            }
            if (dialogResult == DialogResult.No)
            {

                for(int i=0;i<2; i++)
                {
                    this.AlertErr("Reload Thất Bại");
                }
                return;
            }
            
        }

        private void flhd3_Paint(object sender, PaintEventArgs e)
        {

        }
        void forsender()
        {
            try
            {
                dgridGioHang.ColumnCount = 6;
                dgridGioHang.Columns[0].Name = "IDHDCT";
                dgridGioHang.Columns[0].Visible = false;
                dgridGioHang.Columns[1].Name = "Mã sản phẩm";
                dgridGioHang.Columns[2].Name = "Tên sản phẩm";
                dgridGioHang.Columns[3].Name = "Số lượng";
                dgridGioHang.Columns[4].Name = "Đơn giá";
                dgridGioHang.Columns[5].Name = "Thành tiền";
                dgridGioHang.Columns[5].Name = "Thành tiền";
                dgridGioHang.Rows.Clear();

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Xác nhận";
                buttonColumn.Text = "Sửa";
                buttonColumn.Name = "Sửa";
                buttonColumn.UseColumnTextForButtonValue = true;

                dgridGioHang.Columns.Add(buttonColumn);
            }
            catch (Exception ex)
            {


                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Cập Nhật Hay Không ?", "Thông Báo",
                      MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (ckbIn.Checked && rbt_dahuy.Checked == false)
                    {
                        inHoaDon();
                    }
                    // bán tại quầy
                    string aa = Convert.ToString(txtKhachTra.Text);
                    string fn = aa.Replace(".", "");
                    string bb = Convert.ToString(txtTongTien.Text);
                    string fn1 = bb.Replace(".", "");
                    string thue = Convert.ToString(textBox2.Text);
                    string thuef = thue.Replace(".", "");
                    string giamgia = Convert.ToString(txtDiscount.Text);
                    string giamgiaf = giamgia.Replace(".", "");
                    // đặt hàng
                    string aa1 = Convert.ToString(txt_dathangkhachtra.Text);
                    string fn3 = aa1.Replace(".", "");
                    string bb1 = Convert.ToString(txt_dathangtongtien.Text);
                    string fn4 = bb1.Replace(".", "");//
                    string cc = Convert.ToString(txt_coc.Text);
                    string fn2 = cc.Replace(".", "");//c ần sử lý
                    string giamgiamdat = Convert.ToString(txt_dathanggiamgia.Text);
                    string giamgiamdatf = giamgiamdat.Replace(".", "");//c ần sử lý

                    for (int i = 0; i < dgridGioHang.RowCount; i++)
                    {
                        dgridGioHang.ColumnCount = 6;
                        dgridGioHang.Columns[0].Name = "IDHDCT";
                        dgridGioHang.Columns[0].Visible = false;
                        dgridGioHang.Columns[1].Name = "Mã sản phẩm";
                        dgridGioHang.Columns[2].Name = "Tên sản phẩm";
                        dgridGioHang.Columns[3].Name = "Số lượng";
                        dgridGioHang.Columns[4].Name = "Đơn giá";
                        dgridGioHang.Columns[5].Name = "Thành tiền";
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
                        //đặt hàng
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
                        //không hủy
                        if (rbt_chogiaohang.Checked == true || rbt_dacoc.Checked == true || rbt_dathanhtoan.Checked == true || rbt_chuathanhtoan.Checked == true)
                        {
                            for (int t = 0; t < dgridGioHang.RowCount; t++)
                            {


                                hdct = _hdctser.getlsthdctfromDB().FirstOrDefault(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[t].Cells[0].Value));
                                if (hdct != null)
                                {

                                    hdct.MaHoaDonChiTiet = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[t].Cells[0].Value)).Select(c => c.MaHoaDonChiTiet).FirstOrDefault();
                                    hdct.DonGia = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[t].Cells[0].Value)).Select(c => c.DonGia).FirstOrDefault();
                                    hdct.SoLuong = Convert.ToInt32(dgridGioHang.Rows[t].Cells["Số lượng"].Value);
                                    hdct.GiamGia = Convert.ToDouble(giamgiaf);
                                    hdct.ThanhTien = Convert.ToDouble(Convert.ToInt32(dgridGioHang.Rows[t].Cells["Số lượng"].Value) * Convert.ToInt32(_hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[t].Cells[0].Value)).Select(c => c.DonGia).FirstOrDefault()));
                                    hdct.IdhoaDon = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[t].Cells[0].Value)).Select(c => c.IdhoaDon).FirstOrDefault();
                                    hdct.IdthongTinHangHoa = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[t].Cells[0].Value)).Select(c => c.IdthongTinHangHoa).FirstOrDefault();

                                    hdct.GhiChu = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[t].Cells[0].Value)).Select(c => c.GhiChu).FirstOrDefault();
                                    hdct.TrangThai = Convert.ToInt32(status);
                                    foreach (var x in _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == hdct.IdhoaDon))
                                    {
                                        //cần xử lý

                                        x.TrangThai = Convert.ToInt32(status);
                                        x.TongSoTien = float.Parse(fn);
                                        x.Tien = float.Parse(fn1);
                                        _hdser.updatehdb(x);
                                        _hdser.save();
                                        x.GhiChu = Convert.ToString(richTextBox1.Text);

                                    }
                                    loadhoadonduyet();
                                    loadhoadonduyet3();

                                    _hdctser.updatehdct(hdct);
                                    _hdctser.save();
                                    capnhatsoluongsender();
                                    loadsanphamsender();

                                }

                            }
                            forsender();
                            clear();
                        }
                        //đặt hàng không hủy
                        if (rbt_dathangchogiaohang.Checked == true || rbt_dathangdacoc.Checked == true || rbt_dathangchuathanhtoan.Checked == true || rbt_dathangdathanhtoan.Checked == true)
                        {
                            for (int d = 0; d < dgridGioHang.RowCount; d++)
                            {
                                hdct = _hdctser.getlsthdctfromDB().FirstOrDefault(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[d].Cells[0].Value));
                                if (hdct != null)
                                {

                                    hdct.MaHoaDonChiTiet = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[d].Cells[0].Value)).Select(c => c.MaHoaDonChiTiet).FirstOrDefault();
                                    hdct.DonGia = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[d].Cells[0].Value)).Select(c => c.DonGia).FirstOrDefault();
                                    hdct.SoLuong = Convert.ToInt32(dgridGioHang.Rows[d].Cells["Số lượng"].Value);
                                    hdct.GiamGia = Convert.ToDouble(giamgiamdatf);
                                    hdct.ThanhTien = Convert.ToDouble(Convert.ToInt32(dgridGioHang.Rows[d].Cells["Số lượng"].Value) * Convert.ToInt32(_hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[d].Cells[0].Value)).Select(c => c.DonGia).FirstOrDefault()));
                                    hdct.IdhoaDon = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[d].Cells[0].Value)).Select(c => c.IdhoaDon).FirstOrDefault();
                                    hdct.IdthongTinHangHoa = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[d].Cells[0].Value)).Select(c => c.IdthongTinHangHoa).FirstOrDefault();

                                    hdct.GhiChu = _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[d].Cells[0].Value)).Select(c => c.GhiChu).FirstOrDefault();
                                    hdct.TrangThai = Convert.ToInt32(status);
                                    foreach (var x in _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == hdct.IdhoaDon))
                                    {
                                        x.TrangThai = Convert.ToInt32(statusdt);
                                        x.TongSoTien = Convert.ToDouble(fn3);
                                        x.Tien = float.Parse(fn4);
                                        if (fn2 == "")
                                        {
                                            x.TienCoc = 0;
                                        }
                                        else
                                        {
                                            x.TienCoc = float.Parse(fn2);
                                        }
                                        x.GhiChu = Convert.ToString(rtx_ghichu2.Text);
                                        _hdser.updatehdb(x);
                                        _hdser.save();

                                    }

                                    _hdctser.updatehdct(hdct);
                                    _hdctser.save();
                                    loadhoadonduyet();
                                    loadhoadonduyet3();

                                    capnhatsoluongsender();
                                    loadsanphamsender();

                                }
                            }


                            forsender();
                            clear();


                        }

                        if (rbt_dahuy.Checked == true)
                        {
                            for (int a = 0; a < dgridGioHang.RowCount; a++)
                            {
                                hdct = _hdctser.getlsthdctfromDB().FirstOrDefault(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[a].Cells[0].Value));
                                if (hdct != null)
                                {
                                    foreach (var x in _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == hdct.IdhoaDon))
                                    {
                                        x.Thue = 0;
                                        x.Tien = 0;
                                        x.TienCoc = 0;
                                        x.TongSoTien = 0;
                                        x.TrangThai = 4;
                                        x.GhiChu = richTextBox1.Text;
                                        _hdser.updatehdb(x);
                                        _hdser.save();
                                    }
                                    //tìm ra sản phẩm cần trả lại
                                    foreach (var sp in _isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == hdct.IdthongTinHangHoa))
                                    {
                                        sp.SoLuong = Convert.ToString(Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == hdct.IdthongTinHangHoa).Select(c => c.SoLuong).FirstOrDefault()) + Convert.ToInt32(dgridGioHang.Rows[a].Cells["Số lượng"].Value));
                                        _isercthh.updatechitiet(sp);
                                        _isercthh.save(sp);
                                    }




                                    _hdctser.deletehdct(hdct);
                                    _hdctser.save();
                                    loadhoadonduyet();
                                    loadhoadonduyet3();

                                    loadsanphamsender();
                                    //chỉ cần load lại sản phẩm

                                }


                            }
                            forsender();
                            clear();
                        }
                        //đặt hàng hủy
                        if (rbt_dathangdahuy.Checked == true)
                        {
                            for (int a = 0; a < dgridGioHang.RowCount; a++)
                            {
                                hdct = _hdctser.getlsthdctfromDB().FirstOrDefault(c => c.IdhoaDonChiTiet == Convert.ToInt32(dgridGioHang.Rows[a].Cells[0].Value));
                                if (hdct != null)
                                {
                                    foreach (var x in _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == hdct.IdhoaDon))
                                    {
                                        x.Thue = 0;
                                        x.Tien = 0;
                                        x.TienCoc = 0;
                                        x.TongSoTien = 0;
                                        x.TrangThai = 4;
                                        x.GhiChu = rtx_ghichu2.Text;
                                        _hdser.updatehdb(x);
                                        _hdser.save();
                                    }
                                    //tìm ra sản phẩm cần trả lại
                                    foreach (var sp in _isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == hdct.IdthongTinHangHoa))
                                    {
                                        sp.SoLuong = Convert.ToString(Convert.ToInt32(_isercthh.getlstchitietthanghoafromDB().Where(c => c.IdthongTinHangHoa == hdct.IdthongTinHangHoa).Select(c => c.SoLuong).FirstOrDefault()) + Convert.ToInt32(dgridGioHang.Rows[a].Cells["Số lượng"].Value));
                                        _isercthh.updatechitiet(sp);
                                        _isercthh.save(sp);
                                    }




                                    _hdctser.deletehdct(hdct);
                                    _hdctser.save();
                                    loadhoadonduyet();
                                    loadhoadonduyet3();

                                    //
                                    loadsanphamsender();


                                }


                            }
                            forsender();
                            clear();
                        }
                    }
                }
                if (dialogResult == DialogResult.No)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        this.AlertErr("Nhập Nhật Thất Bại");
                    }
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
           
        }

        private void cbxKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxKH_Click(object sender, EventArgs e)
        {
            try
            {
                flag *= -1;
                if (flag == 1)
                {
                    //cbxKH.Items.Clear();
                    LoadCbxKH();
                }
                else
                {
                    cbxKH.Items.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
           // bỏ vào tk click vs cmt loadcbxKH trên form load lại
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                loadsanphamtimkiem(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;


            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "Tìm Kiếm Theo Mã Sản Phẩm Hoặc Tên")
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = "Tìm Kiếm Theo Mã Sản Phẩm Hoặc Tên";
                    textBox1.ForeColor = Color.Black;
                    loadsanphamsender();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
    }
}
