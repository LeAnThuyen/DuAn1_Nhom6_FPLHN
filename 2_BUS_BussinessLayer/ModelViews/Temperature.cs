using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.ModelViews
{
   public class Temperature
    {
        public string MaHoaDon { get; set; }
        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public double? TongTien { get; set; }
        public int? TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string NgayLap { get; set; }
        public string Days { get; set; }
        public string Months { get; set; }
        public string Years { get; set; }
        public double? Totals { get; set; }
        public int? tongdon { get; set; }
        public int? donhuy { get; set; }
        public int? donthanhcong { get; set; }
        public int? chuathanhtoan { get; set; }


        public Temperature( string mahd,string fulltime, string manv, string makh, string tenkh, string sdt, string email, double? tongtien, int? trangthai, string ghichu,int? coundonhuy, int? countdonchuathanhtoan,int? countdontc)
        {
            MaHoaDon = mahd;
            MaNhanVien = manv;
            MaKhachHang = makh;
            TenKhachHang = tenkh;
            SoDienThoai = sdt;
            Email = email;
            TongTien = tongtien;
            TrangThai = trangthai;
            GhiChu = ghichu;
            NgayLap = fulltime;
            donhuy = coundonhuy;
            chuathanhtoan = countdonchuathanhtoan;
            donthanhcong = countdontc;
        }
    }
}
