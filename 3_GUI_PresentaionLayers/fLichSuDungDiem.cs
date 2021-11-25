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
        public fLichSuDungDiem()
        {
            InitializeComponent();
            _iQlyKhachHang = new QLyKhachHangServices();
            LoadData();
        }

        void LoadData()
        {
            dgridLichSu.ColumnCount = 4;
            dgridLichSu.Columns[0].Name = "Mã hóa đơn";
            dgridLichSu.Columns[1].Name = "Ngày mua";
            dgridLichSu.Columns[2].Name = "Số điẻm sử dụng";
            dgridLichSu.Columns[3].Name = "Số điểm còn lại";
            dgridLichSu.Rows.Clear();
            foreach (var x in _iQlyKhachHang.GetsList())
            {
                dgridLichSu.Rows.Add(x.KhachHang.HoaDonBans, x.KhachHang.TenKhachHang, x.KhachHang.DiaChi,
                    x.DiemTieuDung.SoDiem);
            }
        }
    }
}
