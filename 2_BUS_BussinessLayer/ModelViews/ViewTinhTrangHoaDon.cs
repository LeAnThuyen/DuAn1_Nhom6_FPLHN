using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.ModelViews
{
   public class ViewTinhTrangHoaDon
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
        public DateTime? NgayLap { get; set; }
        public string Days { get; set; }
        public string Months { get; set; }
        public string Years { get; set; }
        public double? Totals { get; set; }


        public ViewTinhTrangHoaDon(string mahd, string manv,string makh,string tenkh,string sdt, string email,double? tongtien, int?  trangthai,string ghichu,DateTime? fulltime,string Day ,string Month, string Year,double? total)
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
            Days = Day;
            Months = Month;
            Years = Year;
            Totals = total;
        }

    }
}
