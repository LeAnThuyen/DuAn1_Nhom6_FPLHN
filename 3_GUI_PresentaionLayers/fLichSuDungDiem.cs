using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;

namespace _3_GUI_PresentaionLayers
{
    public partial class fLichSuDungDiem : Form
    {
        private IQlyKhachHang _iQlyKhachHang;
        private string tenKH = "";
        private int id, IdHd, IdHdct;
        private IQlyHoaDon _iQlyHoaDon;

        private void fLichSuDungDiem_Load(object sender, EventArgs e)
        {
            dgridLichSu.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgridLichSu.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgridLichSu.RowHeadersVisible = false;
            //lblTenKH.Text = tenKH;
            //lblBacKH.Text = "Vàng";
            txtMa.Visible = false;
            //label5.Text = _iQlyKhachHang.GetsListKH().Where(x => x.IdkhachHang == id).Select(x => x.MaKhachHang).FirstOrDefault();
            var count = from a in _iQlyKhachHang.GetsList()
                where a.KhachHang.IdkhachHang == id
                group a by a.LichSuTieuDungDiem.SoDiemTieu
                into list
                select new
                {   
                    sum = list.Sum(x => x.LichSuTieuDungDiem.SoDiemTieu)
                };
        }
      
        public fLichSuDungDiem()
        {
            InitializeComponent();
            _iQlyKhachHang = new QLyKhachHangServices();
            _iQlyHoaDon = new QlyHoaDonServices();
            LoadData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgridLichSu.ColumnCount = 3;
            dgridLichSu.Columns[0].Name = "Mã hóa đơn";
            dgridLichSu.Columns[1].Name = "Ngày sử dụng";
            dgridLichSu.Columns[2].Name = "Số điẻm sử dụng";
            dgridLichSu.Rows.Clear();
            double sum = 0;

            foreach (var x in _iQlyKhachHang.GetsListLS().Where(x => x.IddiemTieuDung == Convert.ToInt32(txtMa.Text)))
            {
                dgridLichSu.Rows.Add(_iQlyHoaDon.GetsListHD().Where(c => c.IdhoaDon == x.IdhoaDon).
                        Select(c => c.MaHoaDon).FirstOrDefault(), x.NgaySuDung,x.SoDiemTieu);
            }
        }

        void LoadData()
        {
            dgridLichSu.ColumnCount = 3;
            dgridLichSu.Columns[0].Name = "Mã hóa đơn";
            dgridLichSu.Columns[1].Name = "Ngày sử dụng";
            dgridLichSu.Columns[2].Name = "Số điẻm sử dụng";
        
            dgridLichSu.Rows.Clear();
            double sum = 0;



            //foreach (var x in _iQlyKhachHang.GetsList().Where(x => x.KhachHang.IdkhachHang == id))
            //{
            //    dgridLichSu.Rows.Add(_iQlyHoaDon.GetsListHD().Where(c => c.IdkhachHang == x.KhachHang.IdkhachHang).
            //            Select(c => c.MaHoaDon).FirstOrDefault(), x.LichSuTieuDungDiem.NgaySuDung, x.LichSuTieuDungDiem.SoDiemTieu - x.DiemTieuDung.SoDiem,
            //        x.DiemTieuDung.TrangThai);
            //}
        }
    }
}
