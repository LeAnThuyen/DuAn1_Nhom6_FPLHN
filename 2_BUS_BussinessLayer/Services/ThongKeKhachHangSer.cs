using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.Services
{
    public class ThongKeKhachHangSer : IThongKeKhachHangSer
    {
        private IKhachHangServices ikhser;
        private IServicesHoaDon _ihdser;
        private List<KhachHangThongKeService> _lsttkkh;
     
     


        public ThongKeKhachHangSer()
        {
            _ihdser = new HoaDonBanServices();
           
            ikhser = new KhachHangService();
            _lsttkkh = new List<KhachHangThongKeService>();
            Getlisttkkhtheongay();
        }


        public List<KhachHangThongKeService> Getlisttkkhtheongay()
        {
            var listcommit = (from a in ikhser.getlstkhachhangformDB() join b in _ihdser.getlsthdbfromDB() on a.IdkhachHang equals b.IdkhachHang select new { a.MaKhachHang, a.TenKhachHang, b.MaHoaDon, b.TongSoTien, b.NgayLap }).ToList();
            //gán giá trị
            
            var lisfinal = listcommit.GroupBy(c => c.MaKhachHang)
                  .Select(g => new KhachHangThongKeService(g.Key,
                  g.Where(c => c.MaKhachHang == g.Key).Select(c => c.NgayLap.Value.ToString("MM-dd-yyyy")).FirstOrDefault(),
                  g.Where(c => c.MaKhachHang == g.Key).Select(c => c.MaHoaDon).FirstOrDefault(),
                  g.Where(c => c.MaKhachHang == g.Key).Select(c => c.TenKhachHang).FirstOrDefault(),
                  g.Sum(c => c.TongSoTien))
                ).ToList();

            return lisfinal;
        }
    }
}
