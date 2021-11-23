using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.ModelViews;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmThongKeDoanhThuNhanVien : Form
    {
        private IServiceViewThongKeDoanhThuNhanVien _idtnvser;
        public FrmThongKeDoanhThuNhanVien()
        {
            InitializeComponent();
            _idtnvser = new DoanhThuNhanVienServices();
            loaddoanhthu();
            loadcbo();
            loadnam();
            loadngay();

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
        void loadngay()
        {
            foreach (var x in Getngay())
            {
                cbo_ngay.Items.Add(x);
            }

        }
        void loadnam()
        {
            foreach (var x in Getnam())
            {
                cbo_nam.Items.Add(x);
            }

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

        void loaddoanhthu()
        {
            dgrid_doanhthu.ColumnCount = 3;
            dgrid_doanhthu.Columns[0].Name = "Mã Nhân Viên";
            dgrid_doanhthu.Columns[1].Name = "Tên Nhân Viên";
            dgrid_doanhthu.Columns[2].Name = "Tổng Doanh Thu";
            dgrid_doanhthu.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().OrderByDescending(c => c.TongSoTien))
            {
                dgrid_doanhthu.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
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
                loaddoanhthuforlocall(cbo_ngay.Text, cbo_loc.Text, cbo_nam.Text);
                return;
            }
           
        }
        private void cbo_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_ngay.Text == "" && cbo_nam.Text == "")
            {
                loaddataforlocthang(cbo_loc.Text);
                return;
            }
            else
            {
                loaddoanhthuforlocall(cbo_ngay.Text, cbo_loc.Text, cbo_nam.Text);
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
                loaddoanhthuforlocall(cbo_ngay.Text, cbo_loc.Text, cbo_nam.Text);
                return;
            }
           
        }
        void loaddoanhthuforlocall( string ngay,string thang, string nam)
        {
            dgrid_doanhthu.ColumnCount = 3;
            dgrid_doanhthu.Columns[0].Name = "Mã Nhân Viên";
            dgrid_doanhthu.Columns[1].Name = "Tên Nhân Viên";
            dgrid_doanhthu.Columns[2].Name = "Tổng Doanh Thu";
            dgrid_doanhthu.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().Where(c => c.NgayLap.Value.Day.ToString() == ngay && c.NgayLap.Value.Month.ToString() == thang && c.NgayLap.Value.Year.ToString() == nam).OrderByDescending(c => c.TongSoTien))
            {
                dgrid_doanhthu.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }
        }
        //ngày
        void loaddataforlocngay(string ngay)
        {
            dgrid_doanhthu.ColumnCount = 3;
            dgrid_doanhthu.Columns[0].Name = "Mã Nhân Viên";
            dgrid_doanhthu.Columns[1].Name = "Tên Nhân Viên";
            dgrid_doanhthu.Columns[2].Name = "Tổng Doanh Thu";
            dgrid_doanhthu.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().Where(c=>c.NgayLap.Value.Day.ToString()==ngay).OrderByDescending(c => c.TongSoTien))
            {
                dgrid_doanhthu.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }
        }
        //tháng
        void loaddataforlocthang(string thang)
        {
            dgrid_doanhthu.ColumnCount = 3;
            dgrid_doanhthu.Columns[0].Name = "Mã Nhân Viên";
            dgrid_doanhthu.Columns[1].Name = "Tên Nhân Viên";
            dgrid_doanhthu.Columns[2].Name = "Tổng Doanh Thu";
            dgrid_doanhthu.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().Where(c => c.NgayLap.Value.Month.ToString() == thang).OrderByDescending(c => c.TongSoTien))
            {
                dgrid_doanhthu.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }
        }
        //năm
        void loaddataforlocnam(string nam)
        {
            dgrid_doanhthu.ColumnCount = 3;
            dgrid_doanhthu.Columns[0].Name = "Mã Nhân Viên";
            dgrid_doanhthu.Columns[1].Name = "Tên Nhân Viên";
            dgrid_doanhthu.Columns[2].Name = "Tổng Doanh Thu";
            dgrid_doanhthu.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().Where(c => c.NgayLap.Value.Year.ToString() == nam).OrderByDescending(c => c.TongSoTien))
            {
                dgrid_doanhthu.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }
        }

    }
}
