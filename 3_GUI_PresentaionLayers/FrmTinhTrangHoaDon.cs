using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmTinhTrangHoaDon : Form
    {

        private IServicesTinhTrangHoaDon _istatus;
        Attachment attach = null;
        private string em;
        public FrmTinhTrangHoaDon()
        {
            InitializeComponent();
            _istatus = new ServiceTinhTrangHoaDon();
            loadnam();
            loadngay();
            loadcbo();
            loaddata();
            loadloc();
            pn_sendemail.Visible = false;
            txt_dataemail.Visible = false;
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
        public string[] Getnam()
        {
            string[] TempNs = new string[2030 - 2010];
            for (int i = 0; i < TempNs.Length; i++)
            {
                TempNs[i] = Convert.ToString(2010 + i);
            }
            return TempNs;
        }
        public string[] Getngay()
        {
            string[] TempNs = new string[32 - 1];
            for (int i = 0; i < TempNs.Length; i++)
            {
                TempNs[i] = Convert.ToString(1 + i);
            }
            return TempNs;
        }
        void loadnam()
        {
            foreach (var x in Getnam())
            {
                cbo_nam.Items.Add(x);
            }

        }
        void loadngay()
        {
            foreach (var x in Getngay())
            {
                cbo_ngay.Items.Add(x);
            }

        }
        //loadloc
        void loadloc()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Đã Thanh Toán");
            row.Add("Đã Cọc");
            row.Add("Chưa Thanh Toán");
            row.Add("Đang Chờ Giao Hàng");
            row.Add("Đã Hủy");
            cbo_loadloc.Items.AddRange(row.ToArray());
        }
        void loadcbo()
        {

            string[] lstmon = new string[12];
            lstmon[0] = "1";
            lstmon[1] = "2";
            lstmon[2] = "3";
            lstmon[3] = "4";
            lstmon[4] = "5";
            lstmon[5] = "6";
            lstmon[6] = "7";
            lstmon[7] = "8";
            lstmon[8] = "9";
            lstmon[9] = "10";
            lstmon[10] = "11";
            lstmon[11] = "12";

            foreach (var x in lstmon)
            {
                cbo_loc.Items.Add(x);
            }

        }
        private void cbo_nam_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_loc.Text == "" && cbo_ngay.Text == "")
            {
                loaddataforlocnam(cbo_nam.Text);
                return;
            }
            else
            {
                loaddataforlocall(cbo_ngay.Text, cbo_loc.Text, cbo_nam.Text);
                return;
            }

        }

        private void cbo_ngay_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_loc.Text == "" && cbo_nam.Text == "")
            {
                loaddataforlocngay(cbo_ngay.Text);
                return;
            }
            else
            {
                loaddataforlocall(cbo_ngay.Text, cbo_loc.Text, cbo_nam.Text);
                return;
            }

        }

        private void cbo_loc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_ngay.Text == "" && cbo_nam.Text == "")
            {
                loaddataforlocthang(cbo_loc.Text);
                return;
            }
            else
            {
                loaddataforlocall(cbo_ngay.Text, cbo_loc.Text, cbo_nam.Text);
                return;
            }

        }
        void loaddata()
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd())
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                //
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }
        //lọc
        void loaddataforlocngay(string ngay)
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.NgayLap.Value.Day.ToString() == ngay))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
        }
        void loaddataforlocnam(string nam)
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.NgayLap.Value.Year.ToString() == nam))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                //
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }
        //tháng
        void loaddataforlocthang(string thang)
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.NgayLap.Value.Month.ToString() == thang))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }
        void loaddataforlocall(string ngay, string thang, string nam)
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.NgayLap.Value.Day.ToString() == ngay && c.NgayLap.Value.Month.ToString() == thang && c.NgayLap.Value.Year.ToString() == nam))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);

            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }

        private void lbl_tongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pn_sendemail.Show();
            rightpanel.BackColor = Color.RosyBrown;

        }
        //tiến hành
        #region
        void loaddatafordathanhtoan()
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.TrangThai == 1))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                //
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }
        void loaddatafordacoc()
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.TrangThai == 0))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                //
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }

        void loaddataforchuathanhtoan()
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.TrangThai == 2))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                //
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }

        void loaddatafordangchogiaohang()
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.TrangThai == 3))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                //
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }

        void loaddatafordahuy()
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            dgrid_tinhtrang.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.TrangThai != 0 && c.TrangThai != 1 && c.TrangThai != 2 && c.TrangThai != 3))
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                //
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
            }
        }
        #endregion
        //gửi mail
        void SendEmail(string to, string subject, string mess, Attachment attachment)
        {
           

                MailMessage mailMessage = new MailMessage("leanthuyen08122002.work@gmail.com", to, subject, mess);
                if (attach != null)
                {
                    mailMessage.Attachments.Add(attach);
                }
            mailMessage.IsBodyHtml = true;
            string newLine = Environment.NewLine;
            String body = "<br /> Follow Us : <a href='https://soundcloud.com/'>This Is My Fanpage PerSoft Perfumes</a>";
            mailMessage.Body=mess  + body;
          
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("leanthuyen08122002.work@gmail.com", "anthuyenle08");
                smtpClient.Send(mailMessage);

           
            //try
            //{
            //    SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            //    NetworkCredential cred = new NetworkCredential("leanthuyen08122002.work@gmail.com", "anthuyenle08");
            //    MailMessage mgs = new MailMessage();
            //    mgs.From = new MailAddress(to,"Thuyen");
            //    mgs.To.Add(to);
            //    mgs.Subject = subject;
            //    mgs.Body =mess;
            //    client.Credentials = cred;
            //    client.EnableSsl = true;
            //    client.Send(mgs);

            //}
            //catch (Exception e)
            //{

            //}
        }



        private void cbo_loadloc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_loadloc.Text == "Đã Thanh Toán")
            {
                loaddatafordathanhtoan();
                return;
            }
            if (cbo_loadloc.Text == "Đã Cọc")
            {
                loaddatafordacoc();
                return;
            }
            if (cbo_loadloc.Text == "Chưa Thanh Toán")
            {
                loaddataforchuathanhtoan();
                return;
            }
            if (cbo_loadloc.Text == "Đang Chờ Giao Hàng")
            {
                loaddatafordangchogiaohang();
                return;
            }
            if (cbo_loadloc.Text == "Đã Hủy")
            {
                loaddatafordahuy();
                return;
            }
            if (cbo_loadloc.Text == "")
            {
                loaddata();
                return;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_dataemail.Text = saveFileDialog.FileName;
                    //
                    TextWriter textWriter = new StreamWriter(txt_dataemail.Text);
                    for (int i = 0; i < dgrid_tinhtrang.RowCount - 1; i++)//row
                    {

                        textWriter.Write(Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Email"].Value + "\n"));

                    }
                    textWriter.Close();
                 for(int i =0; i<2; i++)
                    {
                        this.Alert("In Danh Sách Email Thành Công");
                    }
                }
            }
        }
      
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_fileattach.Text = openFileDialog.FileName;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_emailname.Text = openFileDialog.FileName;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Gửi Mail Hàng Loạt Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    FileInfo file = new FileInfo(txt_fileattach.Text);
                    attach = new Attachment(txt_fileattach.Text);


                    //đọc file số lượng lớn email


                }
                catch (Exception)
                {

                    for (int i = 0; i < 2; i++)
                    {
                        this.AlertErr("Đính Kèm File Bị Lỗi Rồi Khắc Phục Thôi Nào");
                    }
                }

                using (var reader = new StreamReader(txt_emailname.Text))
                {
                    string line;
                
                    while ((line = reader.ReadLine()) != null)
                    {
                        SendEmail(line, txt_sub.Text, rtx_content.Text, attach);
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Gửi Mail Thành Công");
                }

                return;
            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.AlertErr("Gửi Mail Thất Bại");
                }
                return;
            }

           
        






            }


    }
}

