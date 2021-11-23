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
    public class DoanhThuNhanVienServices : IServiceViewThongKeDoanhThuNhanVien
    {
        private IServicesNhanVien _invser;
        private IServicesHoaDon _ihdser;
        private List<ViewDoanhThuNhanVien> _lstdoanhthu;
        private string manv;
        private double tong;
        private NhanVien _nv;
        private ViewDoanhThuNhanVien _viewdoanhthu;
        private DateTime? day;
        private DateTime? nam;
        private string mon;
        private string year;
        public DoanhThuNhanVienServices()
        {
            _ihdser = new HoaDonBanServices();
            _nv = new NhanVien();
               _invser = new NhanVienServices();
            _lstdoanhthu = new List<ViewDoanhThuNhanVien>();
            Getlistviewdoanhthu();
        }
        public List<ViewDoanhThuNhanVien> Getlistviewdoanhthu()
        {//tiến hành gộp list
            var listcommit = (from a in _invser.getlstnhanvienfromDB() join b in _ihdser.getlsthdbfromDB() on a.Iduser equals b.Iduser select new { a.MaNhanVien ,a.TenNhanVien,b.TongSoTien,b.NgayLap}).ToList();
            // gán giá trị
            foreach(var x in listcommit)
            {
                tong = Convert.ToDouble(_ihdser.getlsthdbfromDB().Where(c => c.Iduser == _nv.Iduser).Select(c => c.TongSoTien).Sum());
                day = x.NgayLap;
                nam = x.NgayLap;
                mon = day.Value.Month.ToString();
                year = nam.Value.Year.ToString();
                _viewdoanhthu = new ViewDoanhThuNhanVien(manv,x.TenNhanVien ,tong,mon,year,x.NgayLap);
                _lstdoanhthu.Add(_viewdoanhthu);
            }

            var lisfinal = listcommit.OrderBy(c => c.TongSoTien).GroupBy(c => c.MaNhanVien)
                .Select(g => new ViewDoanhThuNhanVien(g.Key,g.Where(c=>c.MaNhanVien==g.Key).Select(c=>c.TenNhanVien).FirstOrDefault() ,g.Sum(c => c.TongSoTien),mon,year, g.Where(c => c.MaNhanVien == g.Key).Select(c => c.NgayLap).FirstOrDefault())).ToList();






            return lisfinal;
                
        }
    }
}
