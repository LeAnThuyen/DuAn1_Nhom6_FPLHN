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
    public class SanPhamBanChayServices : ISerSanPhamBanChay
    {

        private IServicesHangHoa _hhser;
        private IServicesHoaDon _hdbser;
        private IServicesChiTietHangHoa _cthhser;
        private IServicesHoaDonChiTiet _hdctser;
        private List<SanPhamBanChay> _lstspbanchay;
        private ViewThongKeSanPhamBanChay _viewbestseller;
        private string masp;
        private ChiTietHangHoa cthh;
        private HoaDonChiTiet hdct;
        private int tong;
        private DateTime? day;
        private DateTime? nam;
        private string mon;
        private string year;

        public SanPhamBanChayServices()
        {
            _hhser = new HangHoaServices();
            cthh = new ChiTietHangHoa();
            _hdbser = new HoaDonBanServices();
            hdct = new HoaDonChiTiet();
            _hdctser = new HoaDonChiTietServices();
            _cthhser = new ChiTietHangHoaServices();
            _lstspbanchay = new List<SanPhamBanChay>();

            Getlstsanphambanchaytheongay();
        }
        public List<SanPhamBanChay> Getlstsanphambanchaytheongay()
        {
            var lstcommit = (from a in _hhser.getlsthanghoafromDB()
                             join b in _cthhser.getlstchitietthanghoafromDB() on a.IdhangHoa equals b.IdhangHoa

                             join c in _hdctser.getlsthdctfromDB() on b.IdthongTinHangHoa equals c.IdthongTinHangHoa
                             join d in _hdbser.getlsthdbfromDB() on c.IdhoaDon equals d.IdhoaDon

                             select new { a.MaHangHoa, a.TenHangHoa, c.SoLuong, d.NgayLap }).ToList();

            
            var _lstfinnal = lstcommit.OrderByDescending(c => c.SoLuong).GroupBy(c => c.MaHangHoa).
                Select(g => new SanPhamBanChay(g.Key,
                g.Where(c => c.MaHangHoa== g.Key).Select(c => c.NgayLap.Value.ToString("MM-dd-yyyy")).FirstOrDefault(),
                g.Where(c => c.MaHangHoa == g.Key).Select(c => c.TenHangHoa).FirstOrDefault(),
                g.Sum(c => c.SoLuong))
                ).ToList();
            return _lstfinnal;
        }
       
    }
}
