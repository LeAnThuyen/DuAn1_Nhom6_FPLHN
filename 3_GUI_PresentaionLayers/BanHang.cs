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
        private int IDHH;
        int flag = -1;
        private float tongtien = 0;
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
            LoadData();
            LoadHDCT();
            dgrid_sanpham.AllowUserToAddRows = false;

       
            this.dgrid_sanpham.DefaultCellStyle.ForeColor = Color.Black;
            this.dgridGioHang.DefaultCellStyle.ForeColor = Color.Black;
            LoadCbxNV();
            LoadCbxKH();
            btnDathang.Hide();
            css();
            LoadCbxRank();
            panel11.Hide();
            txtMaHDD.Visible = false;
            //txtMaHDD.Hide();
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
            dgrid_sanpham.ColumnCount = 7;
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

            dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQlyHangHoa.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                    x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                    x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.SoLuong);
            }
            //DataGridViewImageColumn img = new DataGridViewImageColumn();
            //img.HeaderText = "Ảnh";
            //img.Name = "img_sp";
            //img.ImageLayout = DataGridViewImageCellLayout.Stretch;

              
            //dgrid_sanpham.Columns.Add(img);
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
            //foreach (var x in _iQlyHoaDon.GetsList())
            //{
            //    dataGridView1.Rows.Add(x.HoaDonChiTiet.IdhoaDonChiTiet, x.HangHoa.MaHangHoa,
            //        x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
            //        x.HoaDonChiTiet.SoLuong, x.HoaDonChiTiet.DonGia, x.HoaDonChiTiet.ThanhTien);
            //}
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Xác nhận";
            buttonColumn.Text = "Sửa";
            buttonColumn.Name = "Sửa";
            buttonColumn.UseColumnTextForButtonValue = true;

            dgridGioHang.Columns.Add(buttonColumn);
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
            dgrid_sanpham.ColumnCount = 7;
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
            dgrid_sanpham.Rows.Clear();
            var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
            foreach (var x in _iQlyHangHoa.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                    x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                    x.ChiTietHangHoa.DonGiaBan, Convert.ToInt32(x.ChiTietHangHoa.SoLuong) - Convert.ToInt32(_lstHoaDonChiTiets.Where(c => c.IdthongTinHangHoa == x.ChiTietHangHoa.IdthongTinHangHoa).Select(c => c.SoLuong).LastOrDefault()), idlhd);
            }

            int counts = dgridGioHang.Rows.Count;
            tongtien = 0;
            for (int i = 0; i < counts - 1; i++)
            {
                tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
            }

            txtTongTien.Text = Convert.ToString(tongtien);






        }
        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {



                for (int a = 0; a < _iQlyHangHoa.GetsList().Count; a++)
                {
                    if (Convert.ToString(result) == _iQlyHangHoa.GetsList()[a].ChiTietHangHoa.Mavach)
                    {


                      
                            string content = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm", "Thêm Vào Giỏ Hàng","0", 500, 300);
                            if (content !="" && Convert.ToInt32( content) < Convert.ToInt32(_iQlyHangHoa.GetsList()[a].ChiTietHangHoa.SoLuong) &&Convert.ToInt32( _iQlyHangHoa.GetsList()[a].ChiTietHangHoa.SoLuong )>=1)
                            {
                                HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                                {
                                    IdhoaDonChiTiet = iQLyBanHang.GetsList().Max(c=>c.HoaDonChiTiet.IdhoaDonChiTiet)+1,
                                    MaHoaDonChiTiet = "HDCT000" +Convert.ToString(iQLyBanHang.GetsList().Max(c => c.HoaDonChiTiet.IdhoaDonChiTiet) + 1) ,
                                    DonGia = _iQlyHangHoa.GetsList().Where(c=>c.ChiTietHangHoa.Mavach==Convert.ToString( result)).Select(c=>c.ChiTietHangHoa.DonGiaBan).FirstOrDefault(),
                                
                                    SoLuong =Convert.ToInt32( content),
                                    IdthongTinHangHoa = _iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result)).Select(c => c.ChiTietHangHoa.IdthongTinHangHoa).FirstOrDefault(),
                                    TrangThai = 1,
                                    IdhoaDon = iQLyBanHang.GetsList().Max(c => c.HoaDonBan.IdhoaDon),
                                    ThanhTien =Convert.ToDouble(Convert.ToInt32( content)*(_iQlyHangHoa.GetsList().Where(c => c.ChiTietHangHoa.Mavach == Convert.ToString(result)).Select(c => c.ChiTietHangHoa.DonGiaBan).FirstOrDefault()))
                                };

                                _iQlyHoaDon.addHDCT(hoaDonChiTiet);
                                _iQlyHoaDon.SaveHDCT();
                                _lstHoaDonChiTiets.Add(hoaDonChiTiet);
                                acd();

                              

                            }
                            else
                            {
                                MessageBox.Show("Sản Phẩm Không Đủ Để Thêm", "Noticafition");
                                return;
                            }
                         
                       

                        break;
                    }






                   
                }





            }
            pic_cam.Image = bitmap;
        



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
            dgrid_sanpham.ColumnCount = 7;
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
            dgrid_sanpham.Rows.Clear();
            var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
            foreach (var x in _iQlyHangHoa.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                    x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                    x.ChiTietHangHoa.DonGiaBan, Convert.ToInt32(x.ChiTietHangHoa.SoLuong) + Convert.ToInt32(_lstHoaDonChiTiets.Where(c => c.IdthongTinHangHoa == x.ChiTietHangHoa.IdthongTinHangHoa).Select(c => c.SoLuong).LastOrDefault()), idlhd);
            }
        }

        private void dgrid_sanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = e.RowIndex;
            int countHDCT = _iQlyHoaDon.GetsListHDCT().Max(x => x.IdhoaDonChiTiet) + 1;
            if (_lstHoaDonChiTiets.Where(x =>
                    x.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())).Select(
                    x => x.IdthongTinHangHoa).FirstOrDefault() !=
                Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()))
            {
                IDHH = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[0].Value.ToString());
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

                dgrid_sanpham.ColumnCount = 7;
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
                dgrid_sanpham.Rows.Clear();
                var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
                foreach (var x in _iQlyHangHoa.GetsList())
                {
                    dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                        x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                        x.ChiTietHangHoa.DonGiaBan, Convert.ToInt32(x.ChiTietHangHoa.SoLuong) - Convert.ToInt32(_lstHoaDonChiTiets.Where(c => c.IdthongTinHangHoa == x.ChiTietHangHoa.IdthongTinHangHoa).Select(c => c.SoLuong).LastOrDefault()), idlhd);
                }

                int count = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString());
                }

                txtTongTien.Text = Convert.ToString(tongtien);



            }
            else
            {
                IDHH = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[0].Value.ToString());
                int countHDCT2 = _lstHoaDonChiTiets.Max(x => x.IdhoaDonChiTiet) + 1;
                HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                {
                    IdhoaDonChiTiet = countHDCT2,
                    MaHoaDonChiTiet = "HDCT000" + countHDCT2,
                    DonGia = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()),
                    SoLuong = _lstHoaDonChiTiets.Where(x => x.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())).Select(x => x.SoLuong).LastOrDefault() + 1,
                    IdthongTinHangHoa = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()),
                    TrangThai = 1,
                    IdhoaDon = Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()),
                    ThanhTien = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()) * (_lstHoaDonChiTiets.Where(x => x.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())).Select(x => x.SoLuong).LastOrDefault() + 1)
                };

                var hoadon = _lstHoaDonChiTiets.FirstOrDefault(x =>
                    x.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())
                    && x.IdhoaDon == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()));
                _lstHoaDonChiTiets.Remove(hoadon);
                _lstHoaDonChiTiets.Add(hoaDonChiTiet);
                var hoadon2 = _lstHoaDonChiTiets.FirstOrDefault(x =>
                    x.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())
                    && x.IdhoaDon == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()));
                var hdct = _lstHoaDonChiTiets.FirstOrDefault(x =>
                    x.IdhoaDon == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[6].Value.ToString()));
                //var hdct = _iQlyHoaDon.GetsListHDCT().FirstOrDefault(x =>
                //    x.IdhoaDonChiTiet == _iQlyHoaDon.GetsListHDCT().Where(c => c.IdthongTinHangHoa == Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString())).Select(c => c.IdhoaDonChiTiet).FirstOrDefault());
                hoadon.ThanhTien = float.Parse(dgrid_sanpham.Rows[row].Cells[4].Value.ToString()) * (_lstHoaDonChiTiets
                    .Where(x => x.IdthongTinHangHoa ==
                                Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()))
                    .Select(x => x.SoLuong).LastOrDefault());
                hoadon.SoLuong = _lstHoaDonChiTiets
                    .Where(x => x.IdthongTinHangHoa ==
                                Convert.ToInt32(dgrid_sanpham.Rows[row].Cells[1].Value.ToString()))
                    .Select(x => x.SoLuong).LastOrDefault();

                _iQlyHoaDon.updateHDCTV(hoadon);
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
                dgrid_sanpham.ColumnCount = 7;
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
                dgrid_sanpham.Rows.Clear();
                var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
                foreach (var x in _iQlyHangHoa.GetsList())
                {
                    dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                        x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                        x.ChiTietHangHoa.DonGiaBan, Convert.ToInt32(x.ChiTietHangHoa.SoLuong) - Convert.ToInt32(_lstHoaDonChiTiets.Where(c => c.IdthongTinHangHoa == x.ChiTietHangHoa.IdthongTinHangHoa).Select(c => c.SoLuong).LastOrDefault()), idlhd);
                }
                int count = dgridGioHang.Rows.Count;
                tongtien = 0;
                for (int i = 0; i < count - 1; i++)
                {
                    tongtien += float.Parse(dgridGioHang.Rows[i].Cells[5].Value.ToString()); //i++;
                }
                txtTongTien.Text = Convert.ToString(tongtien);

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
                MessageBox.Show("Số điểm của khách hàng không đủ, Số điểm hiện tại là: " + _iQlyKhachHang.GetsListDTD().Where(x => x.IddiemTieuDung == iddtd)
                    .Select(x => x.SoDiem).FirstOrDefault(), "Thông báo");
                return false;
            }

            return true;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            int iddtd =Convert.ToInt32(_iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text)
                .Select(x => x.IddiemTieuDung).FirstOrDefault());
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
                if (_iQlyKhachHang.GetsListDTD().Where(x=>x.IddiemTieuDung == iddtd).Select(x=>x.TrangThai).FirstOrDefault()==0)
                {
                    var diemtieudung = _iQlyKhachHang.GetsListDTD().FirstOrDefault(x => x.IddiemTieuDung == iddtd);
                    diemtieudung.SoDiem = tien < 100000 ? 20 :
                                          tien < 500000 ? 50 :
                                          tien < 1000000 ? 100 :
                                          tien < 5000000 ? 200 : 500 + (Convert.ToDouble(_iQlyKhachHang.GetsListDTD()
                            .Where(x => x.IddiemTieuDung == iddtd)
                            .Select(x => x.SoDiem).FirstOrDefault()));
                    _iQlyKhachHang.updateDiemTD(diemtieudung);
                    _iQlyKhachHang.SaveDTD(diemtieudung);
                }
                //else
                //{
                //    DiemTieuDung diemTieuDung = new DiemTieuDung()
                //    {
                //        IddiemTieuDung = _iQlyKhachHang.GetsListDTD().Max(x => x.IddiemTieuDung) + 1,
                //        TrangThai = 0,
                //        SoDiem = tien < 100000 ? 20 :
                //            tien < 500000 ? 50 :
                //            tien < 1000000 ? 100 :
                //            tien < 5000000 ? 200 : 500
                //    };
                //    _iQlyKhachHang.addDiemTD(diemTieuDung);
                //    _iQlyKhachHang.SaveDTD(diemTieuDung);
                //}
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
                    IddiemTieuDung = _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == cbxKH.Text).Select(x => x.IddiemTieuDung).FirstOrDefault()
                };
                var diemtieudung = _iQlyKhachHang.GetsListDTD().FirstOrDefault(x => x.IddiemTieuDung == iddtd);
                diemtieudung.SoDiem =  Convert.ToDouble(_iQlyKhachHang.GetsListDTD()
                        .Where(x => x.IddiemTieuDung == iddtd)
                        .Select(x => x.SoDiem).FirstOrDefault())-Convert.ToDouble(txtDiscount.Text);
                _iQlyKhachHang.updateDiemTD(diemtieudung);
                _iQlyKhachHang.SaveDTD(diemtieudung);
                _iQlyKhachHang.addLichSu(lichSuTieuDungDiem);
                _iQlyKhachHang.SaveLichSU(lichSuTieuDungDiem);
            }
            var x = MessageBox.Show("Bạn có chắc chắn muốn thanh toán không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                MessageBox.Show("Thanh Toán Thành Công","Thông Báo");
                return;
            }
            if (x == DialogResult.No)
            {
                return;
            }

            
            var hoadon = _iQlyHoaDon.GetsListHD().FirstOrDefault(c => c.IdhoaDon == Convert.ToInt32(txtMaHDD.Text));
            hoadon.TrangThai = 1;
            hoadon.NgayLap = DateTime.Now;
            hoadon.TongSoTien = float.Parse(txtTongTien.Text);
            int id = _iQlyKhachHang.GetsListKH().Where(c => c.TenKhachHang == cbxKH.Text).Select(c => c.IdkhachHang)
                .FirstOrDefault();
            hoadon.IdkhachHang = id;

             _iQlyHoaDon.updateHD(hoadon);
            _iQlyHoaDon.SaveHD();
        }
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
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

            int positionDigit = sNumber.Length;   // last -> first

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
                "PerSoft Perfume".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 20));
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
                "Phiếu Thanh Toán".ToUpper(), new Font("Courier New", 30, FontStyle.Bold), Brushes.Black, new PointF(190, y));


            y += 80;
            e.Graphics.DrawString("STT", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Tên hàng hóa", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("Số lượng", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            var id = _lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault();
            var list = from a in _iQlyHoaDon.GetsList().Where(x => x.HoaDonBan.IdhoaDon == id)
                       select a;
            int i = 1;
            y += 20;
            foreach (var x in list)
            {
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(x.HangHoa.TenHangHoa + "" + x.ChiTietHangHoa.Model, new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.HoaDonChiTiet.SoLuong), new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.ChiTietHangHoa.DonGiaBan), new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.HoaDonBan.TongSoTien), new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            }

            y += 40;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPEn, p1, p2);


            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Tiền khách đưa : "), new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Trả khách :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Thành chữ : {0} VND", NumberToText(Convert.ToDouble(txtTongTien.Text))), new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
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
                "PerSoft Perfume".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 20));
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
                "Phiếu Thanh Toán".ToUpper(), new Font("Courier New", 30, FontStyle.Bold), Brushes.Black, new PointF(190, y));


            y += 80;
            e.Graphics.DrawString("STT", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Tên hàng hóa", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("Số lượng", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            var id = _lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault();
            var list = from a in _iQlyHoaDon.GetsList().Where(x => x.HoaDonBan.IdhoaDon == id)
                       select a;
            int i = 1;
            y += 20;
            foreach (var x in list)
            {
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(x.HangHoa.TenHangHoa + "" + x.ChiTietHangHoa.Model, new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.HoaDonChiTiet.SoLuong), new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.ChiTietHangHoa.DonGiaBan), new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", x.HoaDonBan.TongSoTien), new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            }

            y += 40;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPEn, p1, p2);


            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Tiền khách đưa : "), new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Trả khách :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString(txtTongTien.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
            y += 20;
            e.Graphics.DrawString(string.Format("Thành chữ : {0} VND", NumberToText(Convert.ToDouble(txtTongTien.Text))), new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
        }

        #region mousehover
        private void button2_Click(object sender, EventArgs e)
        {
            flag *= -1;
            if (flag == 1)
            {
                btnDathang.Hide();
                btnThanhToan.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag *= -1;
            if (flag == 1)
            {
                btnDathang.Show();
                btnThanhToan.Hide();
            }
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
            str = _iQlyKhachHang.GetsList().Where(x => x.KhachHang.TenKhachHang == n).Select(x => x.KhachHang.Email).FirstOrDefault();
            //txtEmail.Text = str;
           
            var _lst = from a in _iQlyKhachHang.GetsList()
                where a.KhachHang.TenKhachHang == Convert.ToString(cbxKH.SelectedItem)
                       select a;
            txtEmail.Text = _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == Convert.ToString(cbxKH.SelectedItem))
                .Select(x => x.Email).FirstOrDefault();
            txtDT.Text = _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == Convert.ToString(cbxKH.SelectedItem))
                .Select(x => x.SoDienThoai).FirstOrDefault();
            int iddtd= Convert.ToInt32(_iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == Convert.ToString(cbxKH.SelectedItem))
                .Select(x => x.IddiemTieuDung).FirstOrDefault());
            txtDTD.Text =Convert.ToString(Convert.ToDouble(_iQlyKhachHang.GetsList().Where(x => x.DiemTieuDung.IddiemTieuDung == iddtd)
                .Select(x => x.DiemTieuDung.SoDiem).FirstOrDefault()));
            var bac= Convert.ToDouble(_iQlyKhachHang.GetsList().Where(x => x.DiemTieuDung.IddiemTieuDung == iddtd)
                .Select(x => x.DiemTieuDung.SoDiem).FirstOrDefault());
            cbxRank.Text = bac < 1000 ? "Bạc" :bac<200?"Vàng":string.IsNullOrEmpty(Convert.ToString(bac))?"Bạc":"Kim cương";
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
            f.Location = new Point(f.Width+590, 200);
            
            f.Show();
        }
        int a;
        private void button4_Click(object sender, EventArgs e)
        {
            var idhd = _iQlyHoaDon.GetsListHD().Max(x => x.IdhoaDon);
            HoaDonBan hoaDonBan = new HoaDonBan()
            {
                IdhoaDon = Convert.ToInt32(idhd) + 1,
                MaHoaDon = "HD0000" + _iQlyHoaDon.GetsListHD().Select(x => x.IdhoaDon).LastOrDefault() ,
                Iduser = _iQlyNhanVien.GetsList().Where(x => x.NhanVien.TenNhanVien == cbxNV.Text).Select(x => x.NhanVien.Iduser).FirstOrDefault(),

            };
            _lstHoaDonBans.Add(hoaDonBan);
            _iQlyHoaDon.addHD(hoaDonBan);
            _iQlyHoaDon.SaveHD();
            txtMaHDD.Text =Convert.ToString(_lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault());
            dgrid_sanpham.ColumnCount = 7;
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
            dgrid_sanpham.Rows.Clear();
            var idlhd = _lstHoaDonBans.Select(x => x.IdhoaDon).LastOrDefault();
            foreach (var x in _iQlyHangHoa.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa,
                    x.HangHoa.TenHangHoa + x.ChiTietHangHoa.Model,
                    x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.SoLuong, idlhd);
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
            flag *= -1;
            if (flag == 1)
            {
               panel11.Show();
            }
            else
            {
                panel11.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fXuLiDonHang f = new fXuLiDonHang();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
          
            _iQlyHoaDon.SaveHDCT();
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

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
                  textBox2.Text = "0";
            }
            if (txtDiscount.Text != "" || textBox2.Text !="")
            {
                string thue = Convert.ToString(Convert.ToInt32(txtTongTien.Text) - (1 - Convert.ToInt32(textBox2.Text) * 0.01)*(Convert.ToInt32(txtTongTien.Text)));
                txtKhachTra.Text = Convert.ToString(Convert.ToInt32(txtTongTien.Text) * (1 -Convert.ToInt32(txtDiscount.Text) * 0.01)+Convert.ToInt32(thue));

            }
           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && txtDiscount.Text=="")
            {
                txtDiscount.Text = "0";
                textBox2.Text = "0";
            }
            if (txtDiscount.Text != "" || textBox2.Text != "")
            {
                string thue = Convert.ToString(Convert.ToInt32(txtTongTien.Text) - (1 - Convert.ToInt32(textBox2.Text) * 0.01) * (Convert.ToInt32(txtTongTien.Text)));
                txtKhachTra.Text = Convert.ToString(Convert.ToInt32(txtTongTien.Text) * (1 - Convert.ToInt32(txtDiscount.Text) * 0.01) + Convert.ToInt32(thue));

            }
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (txtKhachDua.Text != "")
            {
                txtTienthua.Text = Convert.ToString(Convert.ToInt32(txtKhachDua.Text) - Convert.ToInt32(txtKhachTra.Text));
            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            NumberToText(Convert.ToDouble( txtKhachTra.Text), true);
        }
    }
}
