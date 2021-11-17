
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class KhachHangService : IKhachHangServices
    {
        private DatabaseContext _DBcontext;
        private List<KhachHang> _lstkhachhang;
        public KhachHangService()
        {
            _DBcontext = new DatabaseContext();
            _lstkhachhang = new List<KhachHang>();
            getlstkhachhangformDB();
        }
        public bool addkhachhang(KhachHang kh)
        {
            _DBcontext.KhachHangs.Add(kh);
          
            return true;
        }

        public bool deletekhachhang(KhachHang kh)
        {
            _DBcontext.KhachHangs.Remove(kh);
            
            return true;
        }

        public List<KhachHang> getlstkhachhangformDB()
        {
            _lstkhachhang = _DBcontext.KhachHangs.AsNoTracking().ToList();
            return _lstkhachhang;
        }

        public bool savekhachhang(KhachHang kh)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updatekhachhang(KhachHang kh)
        {
            _DBcontext.KhachHangs.Update(kh);
      
            return true;
        }
    }
}
