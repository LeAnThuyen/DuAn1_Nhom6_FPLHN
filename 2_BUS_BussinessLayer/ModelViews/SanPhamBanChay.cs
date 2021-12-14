using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.ModelViews
{
   public class SanPhamBanChay
    {
        public string MaHangHoas { get; set; }
        public string TenHangHoas { get; set; }
        public int? tongsos { get; set; }

        public string NgayLap { get; set; }
        public SanPhamBanChay(string MaHangHoa, string ngaylap, string TenHangHoa, int? tongso)
        {
            MaHangHoas = MaHangHoa;
            TenHangHoas = TenHangHoa;
            tongsos = tongso;

            NgayLap = ngaylap;
        }
    }
}
