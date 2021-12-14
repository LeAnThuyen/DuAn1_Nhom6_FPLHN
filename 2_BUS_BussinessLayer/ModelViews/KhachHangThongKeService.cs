using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.ModelViews
{
   public class KhachHangThongKeService
    {

        public string MaKhachHangs { get; set; }
        public string TenKhachHangs { get; set; }
        public string MaHoaDons { get; set; }
        public double? TongSoTiens { get; set; }
        public int? SoKhachs { get; set; }

        public string NgayLap { get; set; }
        public KhachHangThongKeService( string makh,string ngaylap,string mahd ,string tenkh, double? tongtien)
        {
           
            MaKhachHangs = makh;
            TenKhachHangs = tenkh;
            TongSoTiens = tongtien;
            MaHoaDons = mahd;
              NgayLap = ngaylap;
        }

    }
}
