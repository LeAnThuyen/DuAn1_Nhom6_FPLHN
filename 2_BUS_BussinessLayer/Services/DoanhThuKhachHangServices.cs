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
    public class DoanhThuKhachHangServices : IThongKeKhachHangServices
    {
        private IKhachHangServices ikhser;
        private IServicesHoaDon _ihdser;
        private List<ViewThongKeKhachHang> _lsttkkh;
        private string makh;
        private string tenkh;
       // private string makh;
        private double tong;
        private KhachHang _kh;
        private ViewThongKeKhachHang _viewdoanhthukh;
        private DateTime?[] day;
        private DateTime? nam;
        private string mon;
        private string year;
        public DoanhThuKhachHangServices()
        {
            _ihdser = new HoaDonBanServices();
            _kh = new KhachHang();
            ikhser = new KhachHangService();
            _lsttkkh = new List<ViewThongKeKhachHang>();
        }
        public List<ViewThongKeKhachHang> Getlisttkkh()
        {
          
            var listcommit = (from a in ikhser.getlstkhachhangformDB() join b in _ihdser.getlsthdbfromDB() on a.IdkhachHang equals b.IdkhachHang  select new {  a.MaKhachHang, a.TenKhachHang,b.MaHoaDon,b.TongSoTien,b.NgayLap }).ToList();
            //gán giá trị
            foreach (var x in listcommit)
            {
              
         
            }
            tong = Convert.ToDouble(_ihdser.getlsthdbfromDB().Where(c => c.IdkhachHang == _kh.IdkhachHang).Select(c => c.TongSoTien).Sum());

            var lisfinal = listcommit.OrderBy(c => c.TongSoTien).GroupBy(c => c.NgayLap.Value.ToString("MM-dd-yyyy"))
                  .Select(g => new ViewThongKeKhachHang(g.Key,
                  g.Where(c => c.NgayLap.Value.ToString("MM-dd-yyyy") == g.Key).Select(c => c.TenKhachHang).FirstOrDefault(),
                  g.Where(c => c.NgayLap.Value.ToString("MM-dd-yyyy") == g.Key).Select(c => c.MaKhachHang).FirstOrDefault(),

                  g.Sum(c => c.TongSoTien),
                  g.Count(c => c.MaKhachHang != "..áaahsdjas"))).ToList();
                 
            return lisfinal;
        }
    }
}

