using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private Itest itest;
        Attachment attach = null;
        private string em;
        private IServicesHoaDon _ihdser;
        private IServicesHoaDonChiTiet _hdctser;
        private IServicesChiTietHangHoa _ihhser;
        public FrmTinhTrangHoaDon()
        {
            InitializeComponent();
            _istatus = new ServiceTinhTrangHoaDon();
            _ihhser = new ChiTietHangHoaServices();
            itest = new TestServices();
            loadloc();
            loaddata();

          //  test();
            _ihdser = new HoaDonBanServices();//a
            _hdctser = new HoaDonChiTietServices();//d
            //pn_sendemail.Visible = false;
            txt_dataemail.Visible = false;
            grb_loc.Visible = false;
           // ooo("10-12-2021");
            lbl_end.Visible = false;
            lbl_start.Visible = false;
            dtp_end.Visible = false;
            dtp_start.Visible = false;
            lab_closedetail.Visible = false;
            btn_reload.Visible = false;
            lbl_ss.Visible = false;
            button1.Visible = false;
            grb_ss.Visible = false;
            pn_sendemail.Visible = false;
            rightpanel.Visible = false;
        }
        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }
        void testchuathanhtoan(int status)
        {
            dgrid_loc.ColumnCount = 13;
            dgrid_loc.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_loc.Columns[1].Name = "Mã Nhân Viên";
            dgrid_loc.Columns[2].Name = "Mã Khách Hàng";
            dgrid_loc.Columns[3].Name = "Tên Khách Hàng";
            dgrid_loc.Columns[3].Visible = false;
            dgrid_loc.Columns[4].Name = "Số Điện Thoại";
            dgrid_loc.Columns[5].Name = "Email";
            dgrid_loc.Columns[6].Name = "Tổng Doanh Thu";
            dgrid_loc.Columns[7].Name = "Trạng Thái";
            dgrid_loc.Columns[8].Name = "Ghi Chú";
            dgrid_loc.Columns[9].Name = "Ngày Lập(Tháng-Ngày-Năm)";
            dgrid_loc.Columns[10].Name = "Đơn Hủy";
            dgrid_loc.Columns[10].Visible = false;
            dgrid_loc.Columns[11].Name = "Đơn Chưa Thanh Toán";
            dgrid_loc.Columns[11].Visible = false;
            dgrid_loc.Columns[12].Name = "Đơn Thành Công";
            dgrid_loc.Columns[12].Visible = false;


            dgrid_loc.Rows.Clear();
            foreach (var x in itest.Getlistviewdoanhthutheongay().Where(c=>c.TrangThai== status))
            {
                dgrid_loc.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap, x.donhuy, x.chuathanhtoan, x.donthanhcong);
            }
            int sum = 0;
            for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Tổng Doanh Thu"].Value);
            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double tt = Convert.ToDouble(sum);
            lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
            //số đơn

            lbl_counthd.Text = Convert.ToString(Convert.ToInt32(dgrid_loc.Rows.Count) - 1);
            //
            DataGridViewTextBoxColumn tongtien = new DataGridViewTextBoxColumn();
            tongtien.HeaderText = "Tổng Doanh Thu";
            tongtien.Name = "txt_total";


            dgrid_loc.Columns.Add(tongtien);

            //
            DataGridViewTextBoxColumn totalbill = new DataGridViewTextBoxColumn();
            totalbill.HeaderText = "Tổng Số Hóa Đơn Của Cửa Hàng";
            totalbill.Name = "txt_totalbill";
            dgrid_loc.Columns.Add(totalbill);
            //
            DataGridViewTextBoxColumn cancelbill = new DataGridViewTextBoxColumn();
            cancelbill.HeaderText = " Tổng Số Đơn Hủy";
            cancelbill.Name = "txt_cancelbill";
            dgrid_loc.Columns.Add(cancelbill);
            //
            DataGridViewTextBoxColumn chuthanhtoan = new DataGridViewTextBoxColumn();
            chuthanhtoan.HeaderText = "Tổng Số Đơn Chưa Thanh Toán";
            chuthanhtoan.Name = "txt_chuathanhtoan";
            dgrid_loc.Columns.Add(chuthanhtoan);
            //
            DataGridViewTextBoxColumn donthanhcong = new DataGridViewTextBoxColumn();
            donthanhcong.HeaderText = "Tổng Số Đơn Thành Công";
            donthanhcong.Name = "txt_donthanhcong";
            dgrid_loc.Columns.Add(donthanhcong);


            // tổng doanh thu cửa hàng
            for (int i = 0; i < 1; ++i)
            {
                dgrid_loc.Rows[i].Cells["txt_total"].Value = Convert.ToString(sum);//done
            }
            // tổng số đơn của cửa hàng

            for (int i = 0; i < 1; ++i)
            {
                dgrid_loc.Rows[i].Cells["txt_totalbill"].Value = Convert.ToString(
                    lbl_counthd.Text);
            }
            //số đơn hủy
            int sumdonhuy = 0;
            for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
            {
                sumdonhuy += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Hủy"].Value);

            }
            for (int i = 0; i < 1; ++i)
            {
                dgrid_loc.Rows[i].Cells["txt_cancelbill"].Value = Convert.ToInt32(sumdonhuy);//done
                lbl_huydon.Text = Convert.ToString(sumdonhuy);

            }

            //
            // số đơn chưa thanh toán
            int sumdonchuathanhtoan = 0;
            for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
            {
                sumdonchuathanhtoan += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Chưa Thanh Toán"].Value);



            }
            for (int i = 0; i < 1; ++i)
            {
                dgrid_loc.Rows[i].Cells["txt_chuathanhtoan"].Value = Convert.ToInt32(sumdonchuathanhtoan);//done
                lbl_chuathanhtoan.Text = Convert.ToString(sumdonchuathanhtoan);
            }

            // số đơn thành công
            int sumdonthanhcong = 0;
            for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
            {
                sumdonthanhcong += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Thành Công"].Value);



            }
            for (int i = 0; i < 1; ++i)
            {
                dgrid_loc.Rows[i].Cells["txt_donthanhcong"].Value = Convert.ToInt32(sumdonthanhcong);//done
                labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
            }







            //

        }
        //

        //
        public void AlertErr(string mess)
        {
            FrmThatBaiAlert frmThatBaiAlert = new FrmThatBaiAlert();
            frmThatBaiAlert.showAlert(mess);
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
        void ss(string vl, string nam)
        {
            try
            {
                dgrid_ss.ColumnCount = 13;
                dgrid_ss.Columns[0].Name = "Mã Hóa Đơn";
                dgrid_ss.Columns[1].Name = "Mã Nhân Viên";
                dgrid_ss.Columns[2].Name = "Mã Khách Hàng";
                dgrid_ss.Columns[3].Name = "Tên Khách Hàng";
                dgrid_ss.Columns[3].Visible = false;
                dgrid_ss.Columns[4].Name = "Số Điện Thoại";
                dgrid_ss.Columns[5].Name = "Email";
                dgrid_ss.Columns[6].Name = "Tổng Doanh Thu";
                dgrid_ss.Columns[7].Name = "Trạng Thái";
                dgrid_ss.Columns[8].Name = "Ghi Chú";
                dgrid_ss.Columns[9].Name = "Ngày Lập(Tháng-Ngày-Năm)";
                dgrid_ss.Columns[10].Name = "Đơn Hủy";
                dgrid_ss.Columns[10].Visible = false;
                dgrid_ss.Columns[11].Name = "Đơn Chưa Thanh Toán";
                dgrid_ss.Columns[11].Visible = false;
                dgrid_ss.Columns[12].Name = "Đơn Thành Công";
                dgrid_ss.Columns[12].Visible = false;

                dgrid_ss.Rows.Clear();////
                foreach (var x in itest.Getlistviewdoanhthutheongay().Where(c =>c.NgayLap.Substring(0, 2)==vl && c.NgayLap.Substring(6, 4)==nam))
                {
                    dgrid_ss.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                        x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap, x.donhuy, x.chuathanhtoan, x.donthanhcong);
                }
                int sum = 0;
                for (int i = 0; i < dgrid_ss.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_ss.Rows[i].Cells["Tổng Doanh Thu"].Value);
                }
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                double tt = Convert.ToDouble(sum);
               // lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
                //số đơn

//lbl_counthd.Text = Convert.ToString(Convert.ToInt32(dgrid_ss.Rows.Count) - 1);
                //
                DataGridViewTextBoxColumn tongtien = new DataGridViewTextBoxColumn();
                tongtien.HeaderText = "Tổng Doanh Thu";
                tongtien.Name = "txt_total";


                dgrid_ss.Columns.Add(tongtien);

                //
                DataGridViewTextBoxColumn totalbill = new DataGridViewTextBoxColumn();
                totalbill.HeaderText = "Tổng Số Hóa Đơn Của Cửa Hàng";
                totalbill.Name = "txt_totalbill";
                dgrid_ss.Columns.Add(totalbill);
                //
                DataGridViewTextBoxColumn cancelbill = new DataGridViewTextBoxColumn();
                cancelbill.HeaderText = " Tổng Số Đơn Hủy";
                cancelbill.Name = "txt_cancelbill";
                dgrid_ss.Columns.Add(cancelbill);
                //
                DataGridViewTextBoxColumn chuthanhtoan = new DataGridViewTextBoxColumn();
                chuthanhtoan.HeaderText = "Tổng Số Đơn Chưa Thanh Toán";
                chuthanhtoan.Name = "txt_chuathanhtoan";
                dgrid_ss.Columns.Add(chuthanhtoan);
                //
                DataGridViewTextBoxColumn donthanhcong = new DataGridViewTextBoxColumn();
                donthanhcong.HeaderText = "Tổng Số Đơn Thành Công";
                donthanhcong.Name = "txt_donthanhcong";
                dgrid_ss.Columns.Add(donthanhcong);


                // tổng doanh thu cửa hàng
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_ss.Rows[i].Cells["txt_total"].Value = Convert.ToString(sum);//done
                }
                // tổng số đơn của cửa hàng

                for (int i = 0; i < 1; ++i)
                {
                    dgrid_ss.Rows[i].Cells["txt_totalbill"].Value = Convert.ToString(
                        itest.Getlistviewdoanhthutheongay().Count(c=>c.MaHoaDon=="00jakskasllaslas")
                      );
                }
                //số đơn hủy
                int sumdonhuy = 0;
                for (int i = 0; i < dgrid_ss.Rows.Count; ++i)
                {
                    sumdonhuy += Convert.ToInt32(dgrid_ss.Rows[i].Cells["Đơn Hủy"].Value);

                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_ss.Rows[i].Cells["txt_cancelbill"].Value = Convert.ToInt32(sumdonhuy);//done
                   // lbl_huydon.Text = Convert.ToString(sumdonhuy);

                }

                //
                // số đơn chưa thanh toán
                int sumdonchuathanhtoan = 0;
                for (int i = 0; i < dgrid_ss.Rows.Count; ++i)
                {
                    sumdonchuathanhtoan += Convert.ToInt32(dgrid_ss.Rows[i].Cells["Đơn Chưa Thanh Toán"].Value);



                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_ss.Rows[i].Cells["txt_chuathanhtoan"].Value = Convert.ToInt32(sumdonchuathanhtoan);//done
                   // lbl_chuathanhtoan.Text = Convert.ToString(sumdonchuathanhtoan);
                }

                // số đơn thành công
                int sumdonthanhcong = 0;
                for (int i = 0; i < dgrid_ss.Rows.Count; ++i)
                {
                    sumdonthanhcong += Convert.ToInt32(dgrid_ss.Rows[i].Cells["Đơn Thành Công"].Value);



                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_ss.Rows[i].Cells["txt_donthanhcong"].Value = Convert.ToInt32(sumdonthanhcong);//done
                    labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên ");
            }


        }
        void ooo(DateTime? vl)
        {
            try
            {
                dgrid_loc.ColumnCount = 13;
                dgrid_loc.Columns[0].Name = "Mã Hóa Đơn";
                dgrid_loc.Columns[1].Name = "Mã Nhân Viên";
                dgrid_loc.Columns[2].Name = "Mã Khách Hàng";
                dgrid_loc.Columns[3].Name = "Tên Khách Hàng";
                dgrid_loc.Columns[3].Visible = false;
                dgrid_loc.Columns[4].Name = "Số Điện Thoại";
                dgrid_loc.Columns[5].Name = "Email";
                dgrid_loc.Columns[6].Name = "Tổng Doanh Thu";
                dgrid_loc.Columns[7].Name = "Trạng Thái";
                dgrid_loc.Columns[8].Name = "Ghi Chú";
                dgrid_loc.Columns[9].Name = "Ngày Lập(Tháng-Ngày-Năm)";
                dgrid_loc.Columns[10].Name = "Đơn Hủy";
                dgrid_loc.Columns[10].Visible = false;
                dgrid_loc.Columns[11].Name = "Đơn Chưa Thanh Toán";
                dgrid_loc.Columns[11].Visible = false;
                dgrid_loc.Columns[12].Name = "Đơn Thành Công";
                dgrid_loc.Columns[12].Visible = false;

                dgrid_loc.Rows.Clear();
                foreach (var x in itest.Getlistviewdoanhthutheongay().Where(c => Convert.ToDateTime(c.NgayLap) == vl))
                {
                    dgrid_loc.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                        x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap, x.donhuy, x.chuathanhtoan, x.donthanhcong);
                }
                int sum = 0;
                for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Tổng Doanh Thu"].Value);
                }
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                double tt = Convert.ToDouble(sum);
                lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
                //số đơn

                lbl_counthd.Text = Convert.ToString(Convert.ToInt32(dgrid_loc.Rows.Count) - 1);
                //
                DataGridViewTextBoxColumn tongtien = new DataGridViewTextBoxColumn();
                tongtien.HeaderText = "Tổng Doanh Thu";
                tongtien.Name = "txt_total";


                dgrid_loc.Columns.Add(tongtien);

                //
                DataGridViewTextBoxColumn totalbill = new DataGridViewTextBoxColumn();
                totalbill.HeaderText = "Tổng Số Hóa Đơn Của Cửa Hàng";
                totalbill.Name = "txt_totalbill";
                dgrid_loc.Columns.Add(totalbill);
                //
                DataGridViewTextBoxColumn cancelbill = new DataGridViewTextBoxColumn();
                cancelbill.HeaderText = " Tổng Số Đơn Hủy";
                cancelbill.Name = "txt_cancelbill";
                dgrid_loc.Columns.Add(cancelbill);
                //
                DataGridViewTextBoxColumn chuthanhtoan = new DataGridViewTextBoxColumn();
                chuthanhtoan.HeaderText = "Tổng Số Đơn Chưa Thanh Toán";
                chuthanhtoan.Name = "txt_chuathanhtoan";
                dgrid_loc.Columns.Add(chuthanhtoan);
                //
                DataGridViewTextBoxColumn donthanhcong = new DataGridViewTextBoxColumn();
                donthanhcong.HeaderText = "Tổng Số Đơn Thành Công";
                donthanhcong.Name = "txt_donthanhcong";
                dgrid_loc.Columns.Add(donthanhcong);


                // tổng doanh thu cửa hàng
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_total"].Value = Convert.ToString(sum);//done
                }
                // tổng số đơn của cửa hàng

                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_totalbill"].Value = Convert.ToString(
                        lbl_counthd.Text);
                }
                //số đơn hủy
                int sumdonhuy = 0;
                for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
                {
                    sumdonhuy += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Hủy"].Value);
                   
                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_cancelbill"].Value = Convert.ToInt32(sumdonhuy);//done
                    lbl_huydon.Text = Convert.ToString(sumdonhuy);

                }

                //
                // số đơn chưa thanh toán
                int sumdonchuathanhtoan = 0;
                for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
                {
                    sumdonchuathanhtoan += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Chưa Thanh Toán"].Value);
                   


                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_chuathanhtoan"].Value = Convert.ToInt32(sumdonchuathanhtoan);//done
                    lbl_chuathanhtoan.Text = Convert.ToString(sumdonchuathanhtoan);
                }

                // số đơn thành công
                int sumdonthanhcong = 0;
                for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
                {
                    sumdonthanhcong += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Thành Công"].Value);
               


                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_donthanhcong"].Value = Convert.ToInt32(sumdonthanhcong);//done
                    labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên ");
            }


        }
        //

        void theokhoang(DateTime vl, DateTime natoc)
        {
            try
            {
                dgrid_loc.ColumnCount = 13;
                dgrid_loc.Columns[0].Name = "Mã Hóa Đơn";
                dgrid_loc.Columns[1].Name = "Mã Nhân Viên";
                dgrid_loc.Columns[2].Name = "Mã Khách Hàng";
                dgrid_loc.Columns[3].Name = "Tên Khách Hàng";
                //dgrid_loc.Columns[3].Visible = false;
                dgrid_loc.Columns[4].Name = "Số Điện Thoại";
                dgrid_loc.Columns[5].Name = "Email";
                dgrid_loc.Columns[6].Name = "Tổng Doanh Thu";
                dgrid_loc.Columns[7].Name = "Trạng Thái";
                dgrid_loc.Columns[8].Name = "Ghi Chú";
                dgrid_loc.Columns[9].Name = "Ngày Lập(Tháng-Ngày-Năm)";
                dgrid_loc.Columns[10].Name = "Đơn Hủy";
            //    dgrid_loc.Columns[10].Visible = false;
                dgrid_loc.Columns[11].Name = "Đơn Chưa Thanh Toán";
             //   dgrid_loc.Columns[11].Visible = false;
                dgrid_loc.Columns[12].Name = "Đơn Thành Công";
             //   dgrid_loc.Columns[12].Visible = false;

                dgrid_loc.Rows.Clear();
                foreach (var x in itest.Getlistviewdoanhthutheongay().Where(c =>Convert.ToDateTime(c.NgayLap) >=vl && Convert.ToDateTime(c.NgayLap) <= natoc))
                {
                    dgrid_loc.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                        x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap, x.donhuy, x.chuathanhtoan, x.donthanhcong);
                }
                int sum = 0;
                for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Tổng Doanh Thu"].Value);
                }
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                double tt = Convert.ToDouble(sum);
                lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
                //số đơn

                lbl_counthd.Text = Convert.ToString(Convert.ToInt32(dgrid_loc.Rows.Count) - 1);
                //
                DataGridViewTextBoxColumn tongtien = new DataGridViewTextBoxColumn();
                tongtien.HeaderText = "Tổng Doanh Thu";
                tongtien.Name = "txt_total";


                dgrid_loc.Columns.Add(tongtien);

                //
                DataGridViewTextBoxColumn totalbill = new DataGridViewTextBoxColumn();
                totalbill.HeaderText = "Tổng Số Hóa Đơn Của Cửa Hàng";
                totalbill.Name = "txt_totalbill";
                dgrid_loc.Columns.Add(totalbill);
                //
                DataGridViewTextBoxColumn cancelbill = new DataGridViewTextBoxColumn();
                cancelbill.HeaderText = " Tổng Số Đơn Hủy";
                cancelbill.Name = "txt_cancelbill";
                dgrid_loc.Columns.Add(cancelbill);
                //
                DataGridViewTextBoxColumn chuthanhtoan = new DataGridViewTextBoxColumn();
                chuthanhtoan.HeaderText = "Tổng Số Đơn Chưa Thanh Toán";
                chuthanhtoan.Name = "txt_chuathanhtoan";
                dgrid_loc.Columns.Add(chuthanhtoan);
                //
                DataGridViewTextBoxColumn donthanhcong = new DataGridViewTextBoxColumn();
                donthanhcong.HeaderText = "Tổng Số Đơn Thành Công";
                donthanhcong.Name = "txt_donthanhcong";
                dgrid_loc.Columns.Add(donthanhcong);


                // tổng doanh thu cửa hàng
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_total"].Value = Convert.ToString(sum);//done
                }
                // tổng số đơn của cửa hàng

                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_totalbill"].Value = Convert.ToString(
                        lbl_counthd.Text);
                }
                //số đơn hủy
                int sumdonhuy = 0;
                for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
                {
                    sumdonhuy += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Hủy"].Value);

                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_cancelbill"].Value = Convert.ToInt32(sumdonhuy);//done
                    lbl_huydon.Text = Convert.ToString(sumdonhuy);

                }

                //
                // số đơn chưa thanh toán
                int sumdonchuathanhtoan = 0;
                for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
                {
                    sumdonchuathanhtoan += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Chưa Thanh Toán"].Value);



                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_chuathanhtoan"].Value = Convert.ToInt32(sumdonchuathanhtoan);//done
                    lbl_chuathanhtoan.Text = Convert.ToString(sumdonchuathanhtoan);
                }

                // số đơn thành công
                int sumdonthanhcong = 0;
                for (int i = 0; i < dgrid_loc.Rows.Count; ++i)
                {
                    sumdonthanhcong += Convert.ToInt32(dgrid_loc.Rows[i].Cells["Đơn Thành Công"].Value);



                }
                for (int i = 0; i < 1; ++i)
                {
                    dgrid_loc.Rows[i].Cells["txt_donthanhcong"].Value = Convert.ToInt32(sumdonthanhcong);//done
                    labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên ");
            }

         
        }
        void loaddata()
        {
            try
            {
                dgrid_tinhtrang.ColumnCount = 14;
                dgrid_tinhtrang.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";

                dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
                dgrid_tinhtrang.Columns[1].Visible = false;
                dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
                dgrid_tinhtrang.Columns[2].Visible = false;
                dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
                dgrid_tinhtrang.Columns[3].Visible = false;
                dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
                dgrid_tinhtrang.Columns[4].Visible = false;
                dgrid_tinhtrang.Columns[5].Name = "Email";
                dgrid_tinhtrang.Columns[5].Visible = false;
                dgrid_tinhtrang.Columns[6].Name = "Tổng Doanh Thu";
                dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
                dgrid_tinhtrang.Columns[7].Visible = false;
                dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
                dgrid_tinhtrang.Columns[8].Visible = false;
                dgrid_tinhtrang.Columns[9].Name = "Mã Hóa Đơn";
                dgrid_tinhtrang.Columns[9].Visible = false;
                dgrid_tinhtrang.Columns[10].Name = "Số Đơn Đã Lập";
                dgrid_tinhtrang.Columns[11].Name = "Số Đơn Hủy";
                dgrid_tinhtrang.Columns[12].Name = "Số Đơn Thành Công";
                dgrid_tinhtrang.Columns[13].Name = "Số Đơn Chưa Thanh Toán";

                dgrid_tinhtrang.Rows.Clear();
                foreach (var x in _istatus.GetlistViewStatushd())
                {

                    dgrid_tinhtrang.Rows.Add(x.NgayLap, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                        x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.MaHoaDon, x.tongdon, x.donhuy, x.donthanhcong, x.chuathanhtoan);
                    int sum = 0;//tổng tiền
                    for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Doanh Thu"].Value);
                    }
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    double tt = Convert.ToDouble(sum);
                    lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
                    //tổng số đơn hàng của cửa hàng
                    int sumdon = 0;
                    for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                    {
                        sumdon += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Số Đơn Đã Lập"].Value);
                    }
                    lbl_counthd.Text = Convert.ToString(sumdon);
                }
                ////số đơn hủy
                int sumdonhuy = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sumdonhuy += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Số Đơn Hủy"].Value);

                }
                for (int i = 0; i < 1; ++i)
                {
                   // dgrid_tinhtrang.Rows[i].Cells["txt_cancelbill"].Value = Convert.ToInt32(sumdonhuy);//done
                    lbl_huydon.Text = Convert.ToString(sumdonhuy);

                }

                //
                // số đơn chưa thanh toán
                int sumdonchuathanhtoan = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sumdonchuathanhtoan += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Số Đơn Chưa Thanh Toán"].Value);



                }
                for (int i = 0; i < 1; ++i)
                {
                    //dgrid_tinhtrang.Rows[i].Cells["txt_chuathanhtoan"].Value = Convert.ToInt32(sumdonchuathanhtoan);//done
                    lbl_chuathanhtoan.Text = Convert.ToString(sumdonchuathanhtoan);
                }

                // số đơn thành công
                int sumdonthanhcong = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sumdonthanhcong += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Số Đơn Thành Công"].Value);



                }
                for (int i = 0; i < 1; ++i)
                {
                  //  dgrid_tinhtrang.Rows[i].Cells["txt_donthanhcong"].Value = Convert.ToInt32(sumdonthanhcong);//done
                    labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
                }
                if (dgrid_tinhtrang.RowCount == 1)
                {
                    lbl_tongtien.Text = Convert.ToString("0");
                    lbl_counthd.Text = Convert.ToString("0");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }

        }
        void loaddataforloc(DateTime? datevalues)
        {
            try
            {
                dgrid_tinhtrang.ColumnCount = 14;
                dgrid_tinhtrang.Columns[0].Name = "Ngày Lập(Tháng-Ngày-Năm)";

                dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
                dgrid_tinhtrang.Columns[1].Visible = false;
                dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
                dgrid_tinhtrang.Columns[2].Visible = false;
                dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
                dgrid_tinhtrang.Columns[3].Visible = false;
                dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
                dgrid_tinhtrang.Columns[4].Visible = false;
                dgrid_tinhtrang.Columns[5].Name = "Email";
                dgrid_tinhtrang.Columns[5].Visible = false;
                dgrid_tinhtrang.Columns[6].Name = "Tổng Doanh Thu";
                dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
                dgrid_tinhtrang.Columns[7].Visible = false;
                dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
                dgrid_tinhtrang.Columns[8].Visible = false;
                dgrid_tinhtrang.Columns[9].Name = "Mã Hóa Đơn";
                dgrid_tinhtrang.Columns[9].Visible = false;
                dgrid_tinhtrang.Columns[10].Name = "Số Đơn Đã Lập";
                dgrid_tinhtrang.Columns[11].Name = "Số Đơn Hủy";
                dgrid_tinhtrang.Columns[12].Name = "Số Đơn Thành Công";
                dgrid_tinhtrang.Columns[13].Name = "Số Đơn Chưa Thanh Toán";

                dgrid_tinhtrang.Rows.Clear();
                foreach (var x in _istatus.GetlistViewStatushd().Where(c=>Convert.ToDateTime( c.NgayLap)==datevalues))
                {

                    dgrid_tinhtrang.Rows.Add(x.NgayLap, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                        x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.MaHoaDon, x.tongdon, x.donhuy, x.donthanhcong, x.chuathanhtoan);
                    int sum = 0;
                    for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Doanh Thu"].Value);
                    }
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    double tt = Convert.ToDouble(sum);
                    lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
                    //
                    int sumdon = 0;
                    for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                    {
                        sumdon += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Số Đơn Đã Lập"].Value);
                    }
                    lbl_counthd.Text = Convert.ToString(sumdon);
                }
                //
                ////số đơn hủy
                int sumdonhuy = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sumdonhuy += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Số Đơn Hủy"].Value);

                }
                for (int i = 0; i < 1; ++i)
                {
                    // dgrid_tinhtrang.Rows[i].Cells["txt_cancelbill"].Value = Convert.ToInt32(sumdonhuy);//done
                    lbl_huydon.Text = Convert.ToString(sumdonhuy);

                }

                //
                // số đơn chưa thanh toán
                int sumdonchuathanhtoan = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sumdonchuathanhtoan += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Số Đơn Chưa Thanh Toán"].Value);



                }
                for (int i = 0; i < 1; ++i)
                {
                    //dgrid_tinhtrang.Rows[i].Cells["txt_chuathanhtoan"].Value = Convert.ToInt32(sumdonchuathanhtoan);//done
                    lbl_chuathanhtoan.Text = Convert.ToString(sumdonchuathanhtoan);
                }

                // số đơn thành công
                int sumdonthanhcong = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sumdonthanhcong += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Số Đơn Thành Công"].Value);



                }
                for (int i = 0; i < 1; ++i)
                {
                    //  dgrid_tinhtrang.Rows[i].Cells["txt_donthanhcong"].Value = Convert.ToInt32(sumdonthanhcong);//done
                    labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
                }
                if (dgrid_tinhtrang.RowCount == 1)
                {
                    lbl_tongtien.Text = Convert.ToString("0");
                    lbl_counthd.Text = Convert.ToString("0");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }

        }





        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tiến Hành Gửi Mail Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    pn_sendemail.Show();
                    rightpanel.BackColor = Color.RosyBrown;
                    grb_ss.Visible = false;
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("Tiến Hành Gửi Email Thôi Nào");
                    }

                }
                if (dialogResult == DialogResult.No)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        this.AlertErr("Tiến Hành Gửi Email Thất Bại");
                    }
                    return;
                }

            }
            catch (Exception ex )
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }

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

            try
            {

                MailMessage mailMessage = new MailMessage("leanthuyen08122002.work@gmail.com", to, subject, mess);
                if (attach != null)
                {
                    mailMessage.Attachments.Add(attach);
                }
                mailMessage.IsBodyHtml = true;
                string newLine = Environment.NewLine;
                String body = "<br /> Follow Us : <a href='https://www.facebook.com/Persofts-Perfume-108722191649437'>This Is My Fanpage PerSoft Perfumes</a>";
                mailMessage.Body = mess + body;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("leanthuyen08122002.work@gmail.com", "anthuyenle08");
                smtpClient.Send(mailMessage);





            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }


        }



        private void cbo_loadloc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbo_loadloc.Text == "Đã Thanh Toán")
                {
                    testchuathanhtoan(1);
                    return;
                }
                if (cbo_loadloc.Text == "Đã Cọc")
                {
                    testchuathanhtoan(0);
                    return;
                }
                if (cbo_loadloc.Text == "Chưa Thanh Toán")
                {
                    testchuathanhtoan(2);
                    return;
                }
                if (cbo_loadloc.Text == "Đang Chờ Giao Hàng")
                {
                    testchuathanhtoan(3);
                    return;
                }
                if (cbo_loadloc.Text == "Đã Hủy")
                {
                    testchuathanhtoan(4);
                    return;
                }
                if (cbo_loadloc.Text == "")
                {
                    loaddata();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Lấy Ra List Email Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
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
                            for (int i = 0; i < 2; i++)
                            {
                                this.Alert("In Danh Sách Email Thành Công");
                            }
                        }
                    }

                }
                if (dialogResult == DialogResult.No)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        this.AlertErr("In Danh Sách Email Thất Bại");
                    }
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_fileattach.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_emailname.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
                return;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (chk_chucuahang.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Gửi Mail Cho Chủ Cửa Hàng Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {

                        FileInfo file = new FileInfo(txt_fileattach.Text);
                        attach = new Attachment(txt_fileattach.Text);


                        //đọc file số lượng lớn email
                        SendEmail("thuyenlaph16978@fpt.edu.vn", txt_sub.Text, rtx_content.Text, attach);
                        for (int i = 0; i < 2; i++)
                        {
                            this.Alert("Gửi Mail Cho Chủ Cửa Hàng Thành Công");
                        }

                    }
                    catch (Exception)
                    {

                        for (int i = 0; i < 2; i++)
                        {
                            this.AlertErr("Đính Kèm File Bị Lỗi Rồi Khắc Phục Thôi Nào");
                        }
                    }

                }


                if (dialogResult == DialogResult.No)
                {

                }
            }

            //
            if (chk_hangloat.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Gửi Mail Hàng Loạt Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
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
                        this.AlertErr("Gửi Mail Thất Bại");
                    }
                    return;
                }


            }


            
        }
           


        






        private void button1_Click_1(object sender, EventArgs e)
        {
            //var lst = (from a in _ihdser.getlsthdbfromDB()
            //           join b in _hdctser.getlsthdctfromDB() on a.IdhoaDon equals b.IdhoaDon
            //           join c in _ihhser.getlstchitietthanghoafromDB() on b.IdthongTinHangHoa equals c.IdthongTinHangHoa
            //           select new {b.IdhoaDonChiTiet, a.IdhoaDon, a.NgayLap, a.TongSoTien, b.SoLuong, b.ThanhTien, c.DonGiaNhap }).ToList();



        }

      

        private void dgrid_tinhtrang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex == 2 && e.Value != null)
            //{
            //    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");


            //    e.Value = new string('.', e.Value.ToString().Length);
            //}
        }

        private void dtp_loc_ValueChanged(object sender, EventArgs e)
        {
            if (grb_loc.Visible == true)
            {
                ooo(Convert.ToDateTime(dtp_loc.Value.ToString("MM-dd-yyyy")));
                return;

            }
            else
            {
                
                loaddataforloc(Convert.ToDateTime(dtp_loc.Value.ToString("MM-dd-yyyy")));
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
                theokhoang(Convert.ToDateTime(dtp_start.Value.ToString("MM-dd-yyyy")), Convert.ToDateTime(dtp_end.Value.ToString("MM-dd-yyyy")));
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên Hệ Với Thuyên");
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
                    grb_loc.Visible = true;
                    lbl_end.Visible = true;
                    lbl_start.Visible = true;
                    dtp_end.Visible = true;
                    dtp_start.Visible = true;
                    //mở reload

                    lab_closedetail.Visible = true;
                    btn_reload.Visible = true;
                    lbl_counthd.Text = "0";
                    lbl_tongtien.Text = "0";
                    lbl_chuathanhtoan.Text = "0";
                    labl_sodonthanhcong.Text = "0";
                    lbl_huydon.Text = "0";
                    //
                    lbl_ss.Visible = true;
                    button1.Visible = true;

                    rightpanel.Visible = true;
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
       
        

      

        private void dgrid_loc_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    MessageBox.Show("left");
            //}
            //else
            //{
            //    ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();
            //    int  xyrow = dgrid_tinhtrang.HitTest(e.X, e.Y).RowIndex;
            //    MessageBox.Show("Click right");
            //    MessageBox.Show(xyrow.ToString());
            //    if (xyrow >= 0)
                    
                    
            //        {



            //        my_menu. Items.Add("Del").Name = "Del";
            //    }
            //}
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn ReLoad Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    lab_closedetail.Visible = false;
                    lbl_start.Visible = false;
                    lbl_end.Visible = false;
                    dtp_end.Visible = false;
                    dtp_start.Visible = false;
                    btn_reload.Visible = false;
                    grb_loc.Visible = false;
                    //
                    lbl_ss.Visible = false;
                    button1.Visible = false;
                    grb_ss.Visible = false;
                    if (grb_ss.Visible == true)
                    {
                        ss("01","2021");
                    }
                    pn_sendemail.Visible = false;
                    rightpanel.Visible = false;
                    loaddata();
                    // lbl_chuathanhtoan.Text = "0";
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


        
           // ooo("01-12-1999");
        
        void senderexcel()
        {
            System.Data.OleDb.OleDbConnection MyConnection;//"C:\Thuyên.xlsx"//"C:\persoftdaily.xlsx"//
            System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();//,,, ,  , ,, , , ,,
            string sql = null;
            MyConnection = new System.Data.OleDb.OleDbConnection((@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\persoftdaily.xlsx';Extended Properties=Excel 12.0 Xml;"));
            MyConnection.Open();
            myCommand.Connection = MyConnection;
            //for(int i =0; i< dgrid_tinhtrang.RowCount; ++i)//([Mã Hóa Đơn],[Mã Nhân Viên],[Mã Khách Hàng],[Tên Khách Hàng],[Số Điện Thoại],[Email],[Tổng Tiền],[Trạng Thái],[GhiChú],[Ngày Lập],[Tổng Doanh Thu],[Số Đơn Hủy]) 
            //{

            //    sql = "INSERT INTO [sheet1$] values('" + dgrid_tinhtrang.Rows[i].Cells["Mã Hóa Đơn"].Value + "','"+dgrid_tinhtrang.Rows[i].Cells["Mã Nhân Viên"].Value + "'  ,'"+ dgrid_tinhtrang.Rows[i].Cells["Mã Khách Hàng"].Value + "'    ,'" + dgrid_tinhtrang.Rows[i].Cells["Tên Khách Hàng"].Value + "','" + dgrid_tinhtrang.Rows[i].Cells["Số Điện Thoại"].Value + "' ,'" + dgrid_tinhtrang.Rows[i].Cells["Email"].Value + "' ,  '" + dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value + "' ,'" + dgrid_tinhtrang.Rows[i].Cells["Ghi Chú"].Value + "' ,'" + dgrid_tinhtrang.Rows[i].Cells["Trạng Thái"].Value + "' ,'" +dgrid_tinhtrang.Rows[i].Cells["Ngày Lập"].Value + "' ,'" + dgrid_tinhtrang.Rows[i].Cells["txt_total"].Value + "' ,'" +dgrid_tinhtrang.Rows[i].Cells["txt_total"].Value + "' )";
            //    myCommand.CommandText = sql;
            //}

            sql = "INSERT INTO [sheet1$] values(@mahd,@manv,@makh,@tenkh,@sdt,@eamil,@tongtien,@status,@note,@ngaylap,@tongdoanhthu,@totalbill,@sodonhuy,@sodonchuathnahtoan,@sodonthanhcong)";
            for (int i = 0; i < dgrid_loc.Rows.Count; i++)
            {
              
                myCommand.Parameters.AddWithValue("@mahd", Convert.ToString(dgrid_loc.Rows[i].Cells["Mã Hóa Đơn"].Value));
                //myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@manv", Convert.ToString(dgrid_loc.Rows[i].Cells["Mã Nhân Viên"].Value));
                //  myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@makh", Convert.ToString(dgrid_loc.Rows[i].Cells["Mã Khách Hàng"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@tenkh", Convert.ToString(dgrid_loc.Rows[i].Cells["Tên Khách Hàng"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@sdt", Convert.ToString(dgrid_loc.Rows[i].Cells["Số Điện Thoại"].Value));
                //  myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@eamil", Convert.ToString(dgrid_loc.Rows[i].Cells["Email"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@tongtien", Convert.ToString(dgrid_loc.Rows[i].Cells["Tổng Doanh Thu"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@status", Convert.ToString(dgrid_loc.Rows[i].Cells["Trạng Thái"].Value));
                //  myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@note", Convert.ToString(dgrid_loc.Rows[i].Cells["Ghi Chú"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@ngaylap", Convert.ToString(dgrid_loc.Rows[i].Cells["Ngày Lập(Tháng-Ngày-Năm)"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@tongdoanhthu", Convert.ToString(dgrid_loc.Rows[i].Cells["txt_total"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@totalbill", Convert.ToString(dgrid_loc.Rows[i].Cells["txt_totalbill"].Value));
                //  myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@sodonhuy", Convert.ToString(dgrid_loc.Rows[i].Cells["txt_cancelbill"].Value));

                myCommand.Parameters.AddWithValue("@sodonchuathnahtoan", Convert.ToString(dgrid_loc.Rows[i].Cells["txt_chuathanhtoan"].Value));

                myCommand.Parameters.AddWithValue("@sodonthanhcong", Convert.ToString(dgrid_loc.Rows[i].Cells["txt_donthanhcong"].Value));
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
                myCommand.Parameters.Clear();



            }






            MyConnection.Close();





        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Gửi Mail Hàng Loạt Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    senderexcel();
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("Thống Kê Ra File Excel Thành Công !");
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
                    this.AlertErr("Thống Kê Ra File Excel Thất Bại !");
                }
                return;
            }
           
        }

        private void dtp_leftloc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn So Sánh Với Tháng Trước Hay Không ", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    grb_ss.Visible = true;
                    DateTime dtpmon = DateTime.Now;
                    string forngay = dtpmon.Month.ToString();
                    string foryear = dtpmon.Year.ToString();
                    int fn = Convert.ToInt32(forngay) - 1;
                    ss(Convert.ToString(fn),foryear);
                    // lbl_chuathanhtoan.Text = "0";
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("So Sánh Thành Công Với Tháng"+Convert.ToString(fn));
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

        private void chk_chucuahang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_chucuahang.Checked == true)
            {
                chk_hangloat.Checked = false;
                pictureBox2.Visible = false;
                txt_fileattach.Text = "C:\\persoftdaily.xlsx";
                pictureBox3.Visible = false;
                txt_emailname.Text = "thuyenlaph16978@fpt.edu.vn";
            }
        }

        private void chk_hangloat_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_hangloat.Checked == true)
            {
                pictureBox2.Visible = true;
                chk_chucuahang.Checked = false;
                //
                txt_fileattach.Text ="";
                pictureBox3.Visible = true;
                txt_emailname.Text = "";
            }
        }
    }
}



