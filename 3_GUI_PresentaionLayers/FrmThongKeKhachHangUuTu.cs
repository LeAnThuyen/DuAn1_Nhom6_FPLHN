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
    public partial class FrmThongKeKhachHangUuTu : Form
    {

        private IThongKeKhachHangServices _itkkhser;
        private IThongKeKhachHangSer _tver2kh;
      
        public FrmThongKeKhachHangUuTu()
        {
            InitializeComponent();
            _itkkhser = new DoanhThuKhachHangServices();
            _tver2kh = new ThongKeKhachHangSer();
            grb_ctsp.Visible = false;
            label1.Visible = false;
            dtp_loc.Visible = false;
            loaddoanhthudefaut();
           
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
        void loaddoanhthudefaut()
        {
            dgrid_khut.ColumnCount = 5;
            dgrid_khut.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_khut.Columns[0].Visible = false;
            dgrid_khut.Columns[1].Name = "Mã Khác Hàng";
            //dgrid_khut.Columns[1].Visible =false;
            dgrid_khut.Columns[2].Name = "Tên Khách Hàng";
          //  dgrid_khut.Columns[2].Visible = false;
            dgrid_khut.Columns[3].Name = "Tổng Tiền Đã Mua Hàng";
            dgrid_khut.Columns[4].Name = "Tổng Lượt Khách Hàng Đã Mua Ủng Hộ Cửa Hàng";
            dgrid_khut.Columns[4].Visible = false;
            dgrid_khut.Rows.Clear();
            foreach (var x in _tver2kh.Getlisttkkhtheongay().OrderByDescending(c => c.TongSoTiens))
            {

                dgrid_khut.Rows.Add(x.NgayLap, x.MaKhachHangs, x.TenKhachHangs, x.TongSoTiens);
            }
           
        }
        void loaddoanhthudetail()
        {
            dgrid_cthh.ColumnCount = 4;
           
            dgrid_cthh.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_cthh.Columns[1].Name = "Mã Khác Hàng";
        
            dgrid_cthh.Columns[2].Name = "Tên Khách Hàng";
          
            dgrid_cthh.Columns[3].Name = "Tổng Tiền Đã Mua Hàng";
         
            dgrid_cthh.Rows.Clear();
            foreach (var x in _itkkhser.Getlisttkkh().OrderByDescending(c => c.TongSoTiens))
            {

                dgrid_cthh.Rows.Add(x.NgayLap, x.MaKhachHangs, x.TenKhachHangs, x.TongSoTiens);
            }
        }
        void loaddoanhthudetailforloc(DateTime? ngay)
        {
            dgrid_cthh.ColumnCount = 4;

            dgrid_cthh.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_cthh.Columns[1].Name = "Mã Khác Hàng";

            dgrid_cthh.Columns[2].Name = "Tên Khách Hàng";

            dgrid_cthh.Columns[3].Name = "Tổng Tiền Đã Mua Hàng";

            dgrid_cthh.Rows.Clear();
            foreach (var x in _itkkhser.Getlisttkkh().Where(c=>Convert.ToDateTime(c.NgayLap)==ngay)  .OrderByDescending(c => c.TongSoTiens))
            {

                dgrid_cthh.Rows.Add(x.NgayLap, x.MaKhachHangs, x.TenKhachHangs, x.TongSoTiens);
            }
        }
        //khoảng
        void loaddoanhthudetailforlockhoang(DateTime? fisrtdate,DateTime? lastdate)
        {
            dgrid_cthh.ColumnCount = 4;

            dgrid_cthh.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_cthh.Columns[1].Name = "Mã Khác Hàng";

            dgrid_cthh.Columns[2].Name = "Tên Khách Hàng";

            dgrid_cthh.Columns[3].Name = "Tổng Tiền Đã Mua Hàng";

            dgrid_cthh.Rows.Clear();
            foreach (var x in _itkkhser.Getlisttkkh().Where(c => Convert.ToDateTime(c.NgayLap) >=fisrtdate && Convert.ToDateTime(c.NgayLap)<=lastdate).OrderByDescending(c => c.TongSoTiens))
            {

                dgrid_cthh.Rows.Add(x.NgayLap, x.MaKhachHangs, x.TenKhachHangs, x.TongSoTiens);
            }
        }
        //sss
        void ss(string mon , string year)
        {
            dgrid_ss.ColumnCount = 4;

            dgrid_ss.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_ss.Columns[1].Name = "Mã Khác Hàng";

            dgrid_ss.Columns[2].Name = "Tên Khách Hàng";

            dgrid_ss.Columns[3].Name = "Tổng Tiền Đã Mua Hàng";

            dgrid_ss.Rows.Clear();
            foreach (var x in _itkkhser.Getlisttkkh().Where(c =>c.NgayLap.Substring(0,2)==mon && c.NgayLap.Substring(6,4)==year).OrderByDescending(c => c.TongSoTiens))
            {

                dgrid_ss.Rows.Add(x.NgayLap, x.MaKhachHangs, x.TenKhachHangs, x.TongSoTiens);
            }
        }
        ///fordtloc
        void loaddoanhthudefautfordtploc(DateTime? ngay)
        {
            dgrid_khut.ColumnCount = 5;
            dgrid_khut.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_khut.Columns[1].Name = "Mã Khác Hàng";
            dgrid_khut.Columns[1].Visible =false;
            dgrid_khut.Columns[2].Name = "Tên Khách Hàng";
            dgrid_khut.Columns[2].Visible = false;
            dgrid_khut.Columns[3].Name = "Tổng Tiền Đã Mua Hàng";
            dgrid_khut.Columns[4].Name = "Tổng Lượt Khách Hàng Đã Mua Ủng Hộ Cửa Hàng";
            dgrid_khut.Rows.Clear();
            foreach (var x in _itkkhser.Getlisttkkh().OrderByDescending(c => c.TongSoTiens).Where(c=>Convert.ToDateTime(c.NgayLap)==ngay))
            {

                dgrid_khut.Rows.Add(x.NgayLap, x.MaKhachHangs, x.TenKhachHangs, x.TongSoTiens, x.SoKhachs);
            }
}

private void dtp_loc_ValueChanged(object sender, EventArgs e)
        {
           
                 loaddoanhthudetailforloc(Convert.ToDateTime(dtp_loc.Value.ToString("MM-dd-yyyy")));
           
          
        }

        private void btn_lockhoangtg_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xem Chi Tiết Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    label1.Visible = true;
                    dtp_loc.Visible = true;
                    lbl_end.Visible = true;
                    lbl_start.Visible = true;
                    dtp_end.Visible = true;
                    dtp_start.Visible = true;
                    grb_ctsp.Visible = true;
                    //
                    btn_reload.Visible = true;
                    lab_closedetail.Visible = true;
                    lbl_ss.Visible = true;
                    button1.Visible = true;
                    loaddoanhthudetail();
                  //  loaddoanhthu();
                    // lbl_chuathanhtoan.Text = "0";
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("Hãy Tiến Hành Xem Chi Tiết Thôi Nào");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                    return;
                }

            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.AlertErr("Xem Chi Tiết Thất Bại");
                }
                return;
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn ReLoad Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    lbl_end.Visible = false;
                    lbl_start.Visible = false;
                    dtp_end.Visible = false;
                    dtp_start.Visible = false;
                    grb_ctsp.Visible = false;
                    btn_reload.Visible = false;
                    lab_closedetail.Visible = false;
                    lbl_ss.Visible = false;
                    button1.Visible = false;
                    loaddoanhthudefaut();
                    label1.Visible = false;
                    dtp_loc.Visible = false;
                    grb_hide.Visible = false;
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("Reload Thành Công");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                    return;
                }

            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.AlertErr("Reload Thất Bại");
                }
                return;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn So Sánh Với Tháng Trước Hay Không ", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    grb_hide.Visible = true;
                    DateTime dtpmon = DateTime.Now;
                    string forngay = dtpmon.Month.ToString();
                    string foryear = dtpmon.Year.ToString();
                    int fn = Convert.ToInt32(forngay) - 01;
                    ss(Convert.ToString(fn), foryear);
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("So Sánh Thành Công Với Tháng" + Convert.ToString(fn));
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                    return;
                }

            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {
                    DateTime dtpmon = DateTime.Now;
                    string forngay = dtpmon.Month.ToString();
                    int fn = Convert.ToInt32(forngay) - 01;
                    this.AlertErr("So Sánh Thất Bại  Với Tháng" + Convert.ToString(fn));
                }
                return;
            }
        }

        private void dtp_start_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_start.Value > dtp_end.Value)
            {
                MessageBox.Show("Mốc Bắt Đầu Không Thể Lớn Hơn Mốc Kết Thúc");
                dtp_start.Value = Convert.ToDateTime("12-01-2017");
                return;
            }
        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_start.Value > dtp_end.Value)
            {
                MessageBox.Show("Mốc Bắt Đầu Không Thể Lớn Hơn Mốc Kết Thúc");
                dtp_start.Value = Convert.ToDateTime("12-01-2017");
                return;
            }

            try
            {
                loaddoanhthudetailforlockhoang(Convert.ToDateTime(dtp_start.Value.ToString("MM-dd-yyyy")), Convert.ToDateTime(dtp_end.Value.ToString("MM-dd-yyyy")));
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }
        }
    }
}
