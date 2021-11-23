using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.ModelViews
{
   public class ViewThongKeSanPhamBanChay
    {
        public string MaHangHoas { get; set; }
        public string TenHangHoas { get; set; }
        public int? tongsos{ get; set; }
        public string Months{ get; set; }
        public string Years{ get; set; }
        public DateTime? NgayLap{ get; set; }
        public ViewThongKeSanPhamBanChay(string MaHangHoa, string TenHangHoa, int? tongso,string Month ,string Year,DateTime? ngaylap)
        {
            MaHangHoas = MaHangHoa;
            TenHangHoas = TenHangHoa;
            tongsos = tongso;
            Months = Month;
            Years = Year;
            NgayLap = ngaylap;
        }

    }
}
