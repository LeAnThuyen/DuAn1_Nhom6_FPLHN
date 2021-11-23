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
    public class ServiceTinhTrangHoaDon : IServicesTinhTrangHoaDon
    {
        private List<ViewTinhTrangHoaDon> _lstviewstatushd;
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

        public ServiceTinhTrangHoaDon()
        {
            _lstviewstatushd = new List<ViewTinhTrangHoaDon>();
            ikhser = new KhachHangService();//c
            _invser = new NhanVienServices();//b
            _ihdser = new HoaDonBanServices();//a
            _hdctser = new HoaDonChiTietServices();//d
            _kh = new KhachHang();
        }
        public List<ViewTinhTrangHoaDon> GetlistViewStatushd()
        {
            var listcommit = (from a in _ihdser.getlsthdbfromDB() join b in _invser.getlstnhanvienfromDB() on a.Iduser equals b.Iduser
                              join c in ikhser.getlstkhachhangformDB() on a.IdkhachHang equals c.IdkhachHang
                              join d in _hdctser.getlsthdctfromDB() on a.IdhoaDon equals d.IdhoaDon
                              select new {a.MaHoaDon,a.NgayLap,a.GhiChu,b.MaNhanVien,c.MaKhachHang,c.TenKhachHang,c.Email,c.SoDienThoai,d.ThanhTien,d.TrangThai}
                            ).ToList();

            foreach(var x in listcommit)
            {
                ngay = x.NgayLap;
                thang = x.NgayLap;
                nam = x.NgayLap;
                //
                //var fistcheck =Convert.ToInt32( _ihdser.getlsthdbfromDB().Where(c => c.IdkhachHang == _kh.IdkhachHang).Select(c => c.IdkhachHang).FirstOrDefault());
                //tong =Convert.ToDouble( _hdctser.getlsthdctfromDB().Where(c => c.IdhoaDon == fistcheck).Select(c => c.ThanhTien).Sum());
                day = ngay.Value.Day.ToString();
                mon = thang.Value.Month.ToString();
                year = nam.Value.Year.ToString();
                _viewstatus= new ViewTinhTrangHoaDon(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai, x.Email, x.ThanhTien, x.TrangThai, x.GhiChu, x.NgayLap,day,mon,year,tong);
                _lstviewstatushd.Add(_viewstatus);
            }

            var lstfinal = listcommit.OrderByDescending(c=>c.ThanhTien).GroupBy(c=>c.MaHoaDon).
                Select(g => new ViewTinhTrangHoaDon(g.Key,g.Where(c=>c.MaHoaDon==g.Key).Select(c=>c.MaNhanVien).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.MaKhachHang).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.TenKhachHang).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.SoDienThoai).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.Email).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.ThanhTien).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.TrangThai).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.GhiChu).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.NgayLap).FirstOrDefault(),day,mon,year,tong)
                ).ToList();



            return lstfinal;
        }
    }
}
