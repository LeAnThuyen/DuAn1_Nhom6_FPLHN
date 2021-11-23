using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.ModelViews
{
   public class ViewThongKeKhachHang
    {
        public string MaKhachHangs { get; set; }
        public string TenKhachHangs { get; set; }
        public double? TongSoTiens { get; set; }
        public string Months { get; set; }
        public string Years { get; set; }
        public DateTime? NgayLap { get; set; }
        public ViewThongKeKhachHang(string makh, string tenkh, double? tongtien, string Month, string Year, DateTime? ngaylap)
        {
            MaKhachHangs = makh;
            TenKhachHangs = tenkh;
            TongSoTiens = tongtien;
            Months = Month;
            Years = Year;
            NgayLap = ngaylap;
        }

    }
}
