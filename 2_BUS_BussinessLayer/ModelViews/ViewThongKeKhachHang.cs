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
        public string MaHoaDons { get; set; }
        public double? TongSoTiens { get; set; }
        public int? SoKhachs { get; set; }
       
        public string NgayLap { get; set; }
        public ViewThongKeKhachHang(string ngaylap, string tenkh,string makh, double? tongtien, int? sokhach)
        {
            SoKhachs = sokhach;
            MaKhachHangs = makh;
            TenKhachHangs = tenkh;
            TongSoTiens = tongtien;
          
            NgayLap = ngaylap;
        }
       

    }
}
