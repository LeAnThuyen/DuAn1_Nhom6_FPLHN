using _1_DAL_DataAccessLayer.Context;
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
    public class NhanVienServices : IServicesNhanVien
    {
        private DatabaseContext _DBcontext;
        private List<NhanVien> _lstnhanvien;
        public NhanVienServices()
        {
            _DBcontext = new DatabaseContext();
            _lstnhanvien = new List<NhanVien>();
        }
        public bool addnhanvien(NhanVien nv)
        {
            _DBcontext.NhanViens.Add(nv);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletenhanvien(NhanVien nv)
        {
            _DBcontext.NhanViens.Add(nv);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<NhanVien> getlstnhanvienfromDB()
        {
            _lstnhanvien = _DBcontext.NhanViens.AsNoTracking().ToList();
            return _lstnhanvien;
        }

        public bool updatenhanvien(NhanVien nv)
        {
            _DBcontext.NhanViens.Update(nv);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
