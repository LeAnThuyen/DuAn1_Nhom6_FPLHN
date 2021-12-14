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
    public partial class FormBestseller : Form
    {
        private IServiceViewThongKeSanPham _ispbest;
        private ISerSanPhamBanChay _isersp;
        public FormBestseller()
        {
            InitializeComponent();
            _ispbest = new ServiceSanPhamBanChay();
             
            _isersp = new SanPhamBanChayServices();
            loaddoanhthudefaut();
            grb_ctsp.Visible = false;
            grb_hide.Visible = false;
            lbl_end.Visible = false;
            lbl_start.Visible = false;
            dtp_end.Visible = false;
            dtp_start.Visible = false;
            grb_ctsp.Visible = false;
           // grb_ctsp.Visible = false;
            btn_reload.Visible = false;
            lab_closedetail.Visible = false;
            lbl_ss.Visible = false;
            button1.Visible = false;
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
            dgrid_bestseller.ColumnCount = 4;
            dgrid_bestseller.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_bestseller.Columns[1].Name = "Mã Nước Hoa";
             dgrid_bestseller.Columns[1].Visible = false;
            dgrid_bestseller.Columns[2].Name = "Tên Nước Hoa";
             dgrid_bestseller.Columns[2].Visible = false;
            dgrid_bestseller.Columns[3].Name = "Tổng Số Chai Bán Được Trong Ngày";
            dgrid_bestseller.Rows.Clear();
            foreach (var x in _ispbest.Getlstsanphambanchay().OrderByDescending(c => c.tongsos))
            {
                dgrid_bestseller.Rows.Add(x.NgayLap, x.MaHangHoas, x.TenHangHoas, x.tongsos);
            }
            DataGridViewTextBoxColumn tongsochaicuahang = new DataGridViewTextBoxColumn();
            tongsochaicuahang.HeaderText = "Tổng Cộng Số Chai Cửa Hàng Đã Bán Được";
            tongsochaicuahang.Name = "txt_total";
            dgrid_bestseller.Columns.Add(tongsochaicuahang);
            int sumchai = 0;
            for (int i = 0; i < dgrid_bestseller.RowCount; i++)
            {
                sumchai += Convert.ToInt32(dgrid_bestseller.Rows[i].Cells["Tổng Số Chai Bán Được Trong Ngày"].Value);
            }
            for (int i = 0; i < 1; i++)
            {
                dgrid_bestseller.Rows[i].Cells["txt_total"].Value = sumchai;
            }
        }
       
        
        void loaddoanhthu()
        {
            dgrid_cthh.ColumnCount = 4;
            dgrid_cthh.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_cthh.Columns[1].Name = "Mã Nước Hoa";
           // dgrid_cthh.Columns[1].Visible = false;
            dgrid_cthh.Columns[2].Name = "Tên Nước Hoa";
         //   dgrid_cthh.Columns[2].Visible = false;
            dgrid_cthh.Columns[3].Name = "Tổng Số Chai Bán Được Trong Ngày";
            dgrid_cthh.Rows.Clear();
            foreach (var x in _isersp.Getlstsanphambanchaytheongay().OrderByDescending(c => c.tongsos))
            {
                dgrid_cthh.Rows.Add(x.NgayLap,x.MaHangHoas, x.TenHangHoas, x.tongsos);
            }
            DataGridViewTextBoxColumn tongsochaicuahang = new DataGridViewTextBoxColumn();
            tongsochaicuahang.HeaderText = "Tổng Cộng Số Chai Cửa Hàng Đã Bán Được";
            tongsochaicuahang.Name = "txt_total";
            dgrid_cthh.Columns.Add(tongsochaicuahang);
            int sumchai = 0;
            for(int i =0;i< dgrid_cthh.RowCount; i++)
            {
                sumchai += Convert.ToInt32(dgrid_cthh.Rows[i].Cells["Tổng Số Chai Bán Được Trong Ngày"].Value);
            }
            for(int i=0;i<1; i++)
            {
                dgrid_cthh.Rows[i].Cells["txt_total"].Value = sumchai;
            }
        }
        void loaddoanhthufordtploc(DateTime? ngay)
        {
            dgrid_cthh.ColumnCount = 4;
            dgrid_cthh.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_cthh.Columns[1].Name = "Mã Nước Hoa";
            // dgrid_cthh.Columns[1].Visible = false;
            dgrid_cthh.Columns[2].Name = "Tên Nước Hoa";
            //   dgrid_cthh.Columns[2].Visible = false;
            dgrid_cthh.Columns[3].Name = "Tổng Số Chai Bán Được Trong Ngày";
            dgrid_cthh.Rows.Clear();
            foreach (var x in _isersp.Getlstsanphambanchaytheongay().Where(c=>Convert.ToDateTime(c.NgayLap)==ngay).OrderByDescending(c => c.tongsos))
            {
                dgrid_cthh.Rows.Add(x.NgayLap, x.MaHangHoas, x.TenHangHoas, x.tongsos);
            }
            DataGridViewTextBoxColumn tongsochaicuahang = new DataGridViewTextBoxColumn();
            tongsochaicuahang.HeaderText = "Tổng Cộng Số Chai Cửa Hàng Đã Bán Được";
            tongsochaicuahang.Name = "txt_total";
            dgrid_cthh.Columns.Add(tongsochaicuahang);
            int sumchai = 0;
            for (int i = 0; i < dgrid_cthh.RowCount; i++)
            {
                sumchai += Convert.ToInt32(dgrid_cthh.Rows[i].Cells["Tổng Số Chai Bán Được Trong Ngày"].Value);
            }
            for (int i = 0; i < 1; i++)
            {
                dgrid_cthh.Rows[i].Cells["txt_total"].Value = sumchai;
            }
        }
        //
        void ss(String mon, string year)
        {
            dgrid_ss.ColumnCount = 4;
            dgrid_ss.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_ss.Columns[1].Name = "Mã Nước Hoa";
            // dgrid_ss.Columns[1].Visible = false;
            dgrid_ss.Columns[2].Name = "Tên Nước Hoa";
            //   dgrid_ss.Columns[2].Visible = false;
            dgrid_ss.Columns[3].Name = "Tổng Số Chai Bán Được Trong Ngày";
            dgrid_ss.Rows.Clear();
            foreach (var x in _isersp.Getlstsanphambanchaytheongay().Where(c =>c.NgayLap.Substring(0,2) == mon && c.NgayLap.Substring(6, 4)==year).OrderByDescending(c => c.tongsos))
            {
                dgrid_ss.Rows.Add(x.NgayLap, x.MaHangHoas, x.TenHangHoas, x.tongsos);
            }
            DataGridViewTextBoxColumn tongsochaicuahang = new DataGridViewTextBoxColumn();
            tongsochaicuahang.HeaderText = "Tổng Cộng Số Chai Cửa Hàng Đã Bán Được";
            tongsochaicuahang.Name = "txt_total";
            dgrid_ss.Columns.Add(tongsochaicuahang);
            int sumchai = 0;
            for (int i = 0; i < dgrid_ss.RowCount; i++)
            {
                sumchai += Convert.ToInt32(dgrid_ss.Rows[i].Cells["Tổng Số Chai Bán Được Trong Ngày"].Value);
            }
            for (int i = 0; i < 1; i++)
            {
                dgrid_ss.Rows[i].Cells["txt_total"].Value = sumchai;
            }
        }
        void loaddoanhthuforloc(DateTime? date)
        {
            dgrid_bestseller.ColumnCount = 4;
            dgrid_bestseller.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_bestseller.Columns[1].Name = "Mã Nước Hoa";
            dgrid_bestseller.Columns[1].Visible = false;
            dgrid_bestseller.Columns[2].Name = "Tên Nước Hoa";
            dgrid_bestseller.Columns[2].Visible = false;
            dgrid_bestseller.Columns[3].Name = "Tổng Số Chai Bán Được";
            dgrid_bestseller.Rows.Clear();
            foreach (var x in _ispbest.Getlstsanphambanchay().OrderByDescending(c => c.tongsos).Where(c=>Convert.ToDateTime(c.NgayLap)==date))
            {
                dgrid_bestseller.Rows.Add(x.NgayLap, x.MaHangHoas, x.TenHangHoas, x.tongsos);
            }
            DataGridViewTextBoxColumn tongsochaicuahang = new DataGridViewTextBoxColumn();
            tongsochaicuahang.HeaderText = "Tổng Cộng Số Chai Cửa Hàng Đã Bán Được";
            tongsochaicuahang.Name = "txt_total";
            dgrid_bestseller.Columns.Add(tongsochaicuahang);
            int sumchai = 0;
            for (int i = 0; i < dgrid_bestseller.RowCount; i++)
            {
                sumchai += Convert.ToInt32(dgrid_bestseller.Rows[i].Cells["Tổng Số Chai Bán Được"].Value);
            }
            for (int i = 0; i < 1; i++)
            {
                dgrid_bestseller.Rows[i].Cells["txt_total"].Value = sumchai;
            }
        }
        //khoảng nagyf
        void loaddoanhthufordtplockhoang(DateTime? firstdate, DateTime? lastdate)
        {
            dgrid_cthh.ColumnCount = 4;
            dgrid_cthh.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_cthh.Columns[1].Name = "Mã Nước Hoa";
            // dgrid_cthh.Columns[1].Visible = false;
            dgrid_cthh.Columns[2].Name = "Tên Nước Hoa";
            //   dgrid_cthh.Columns[2].Visible = false;
            dgrid_cthh.Columns[3].Name = "Tổng Số Chai Bán Được Trong Ngày";
            dgrid_cthh.Rows.Clear();
            foreach (var x in _isersp.Getlstsanphambanchaytheongay().Where(c => Convert.ToDateTime(c.NgayLap) >=firstdate && Convert.ToDateTime(c.NgayLap)<=lastdate).OrderByDescending(c => c.tongsos))
            {
                dgrid_cthh.Rows.Add(x.NgayLap, x.MaHangHoas, x.TenHangHoas, x.tongsos);
            }
            DataGridViewTextBoxColumn tongsochaicuahang = new DataGridViewTextBoxColumn();
            tongsochaicuahang.HeaderText = "Tổng Cộng Số Chai Cửa Hàng Đã Bán Được";
            tongsochaicuahang.Name = "txt_total";
            dgrid_cthh.Columns.Add(tongsochaicuahang);
            int sumchai = 0;
            for (int i = 0; i < dgrid_cthh.RowCount; i++)
            {
                sumchai += Convert.ToInt32(dgrid_cthh.Rows[i].Cells["Tổng Số Chai Bán Được Trong Ngày"].Value);
            }
            for (int i = 0; i < 1; i++)
            {
                dgrid_cthh.Rows[i].Cells["txt_total"].Value = sumchai;
            }
        }
        void loaddoanhthusosanh(string thang)
        {

            dgrid_bestseller.ColumnCount = 3;
            dgrid_bestseller.Columns[0].Name = "Mã Nước Hoa";
            dgrid_bestseller.Columns[1].Name = "Tên Nước Hoa";
            dgrid_bestseller.Columns[2].Name = "Tổng Số Chai Bán Được";
            dgrid_bestseller.Rows.Clear();
            //foreach (var x in _ispbest.Getlstsanphambanchay().Where(c => c.NgayLap.Value.Month.ToString() == "12").OrderByDescending(c => c.tongsos))
            //{
            //    dgrid_bestseller.Rows.Add(x.MaHangHoas, x.TenHangHoas, x.tongsos);
            //    //System.InvalidOperationException: 'Nullable object must have a value.'

            //}
        }
       
       

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            grb_hide.Visible = false;
            DateTime diffmon = DateTime.Now;
            string ss = Convert.ToString(Convert.ToInt32( diffmon.Month.ToString()) - 1);
            loaddoanhthusosanh(ss);
        }

        private void dtp_loc_ValueChanged(object sender, EventArgs e)
        {
            if (grb_ctsp.Visible == true)
            {
                loaddoanhthufordtploc(Convert.ToDateTime(dtp_loc.Value.ToString("MM-dd-yyyy")));
            }
            else
            {
                loaddoanhthuforloc(Convert.ToDateTime(dtp_loc.Value.ToString("MM-dd-yyyy")));

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
                loaddoanhthufordtplockhoang(Convert.ToDateTime(dtp_start.Value.ToString("MM-dd-yyyy")), Convert.ToDateTime(dtp_end.Value.ToString("MM-dd-yyyy")));
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
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

        private void btn_lockhoangtg_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xem Chi Tiết Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
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
                    loaddoanhthu();
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
    }
}
