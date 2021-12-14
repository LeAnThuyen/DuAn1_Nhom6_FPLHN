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
    public class TestServices : Itest
    {
        private List<Temperature> _lstviewstatushd;
        private IServicesNhanVien _invser;
        private IServicesHoaDon _ihdser;
        private IKhachHangServices ikhser;
        private IServicesHoaDonChiTiet _hdctser;
        private ViewTinhTrangHoaDon _viewstatus;
        private double? tong;
        private DateTime? ngay;
        private DateTime? thang;
        private DateTime? nam;
        private string day;
        private string mon;
        private string year;
        private KhachHang _kh;

        public TestServices()
        {
            _lstviewstatushd = new List<Temperature>();
            ikhser = new KhachHangService();//c
            _invser = new NhanVienServices();//b
            _ihdser = new HoaDonBanServices();//a
            _hdctser = new HoaDonChiTietServices();//d
            _kh = new KhachHang();
            Getlistviewdoanhthutheongay();
        }

        public List<Temperature> Getlistviewdoanhthutheongay()
        {
            var listcommit = (from a in _ihdser.getlsthdbfromDB()
                              join b in _invser.getlstnhanvienfromDB() on a.Iduser equals b.Iduser
                              join c in ikhser.getlstkhachhangformDB() on a.IdkhachHang equals c.IdkhachHang
                              //join d in _hdctser.getlsthdctfromDB() on a.IdhoaDon equals d.IdhoaDon

                              select new { a.MaHoaDon, a.TongSoTien, a.TrangThai, a.NgayLap, a.GhiChu, b.MaNhanVien, c.MaKhachHang, c.TenKhachHang, c.Email, c.SoDienThoai, c.IdkhachHang }
                          ).ToList();
           
            var lstfinal = listcommit.OrderByDescending(c => c.TongSoTien).GroupBy(c => c.MaHoaDon).
                   Select(g => new Temperature(g.Key,
                   g.Where(c => c.MaHoaDon == g.Key).Select(c =>c.NgayLap.Value.ToString("MM - dd - yyyy")).FirstOrDefault(),
                   g.Where(c => c.MaHoaDon== g.Key).Select(c => c.MaNhanVien).FirstOrDefault(),
                   g.Where(c => c.MaHoaDon==g.Key).Select(c => c.MaKhachHang).FirstOrDefault(),
                   g.Where(c => c.MaHoaDon == g.Key).Select(c => c.TenKhachHang).FirstOrDefault(),
                   g.Where(c => c.MaHoaDon == g.Key).Select(c => c.SoDienThoai).FirstOrDefault(),
                   g.Where(c => c.MaHoaDon == g.Key).Select(c => c.Email).FirstOrDefault(),
                   g.Sum(c => c.TongSoTien),
                   g.Where(c => c.MaHoaDon == g.Key).Select(c => c.TrangThai).FirstOrDefault(),
                   g.Where(c => c.MaHoaDon == g.Key).Select(c => c.GhiChu).FirstOrDefault(),
                g.Count(c=>c.TrangThai==4),//hủy
                g.Count(c=>c.TrangThai==2),//chưa thanh toán 
                g.Count(c=>c.TrangThai==1)//chưa thanh toán 
                )
                   ).ToList();



            return lstfinal;
        }
    }
}
