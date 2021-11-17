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
    public class DiemTieuDungServices : IServiceDiemTieuDung
    {
        private DatabaseContext _DBcontext;
        private List<DiemTieuDung> _lstdiemtieudung;
        public DiemTieuDungServices()
        {
            _DBcontext = new DatabaseContext();
            _lstdiemtieudung = new List<DiemTieuDung>();
            getlstdiemfromDB();
        }
        public bool adddiem(DiemTieuDung diem)
        {
            _DBcontext.DiemTieuDungs.Add(diem);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletediem(DiemTieuDung diem)
        {
            _DBcontext.DiemTieuDungs.Remove(diem);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<DiemTieuDung> getlstdiemfromDB()
        {
            _lstdiemtieudung = _DBcontext.DiemTieuDungs.AsNoTracking().ToList();
            return _lstdiemtieudung;
        }

        public bool updatediem(DiemTieuDung diem)
        {
            _DBcontext.DiemTieuDungs.Update(diem);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
