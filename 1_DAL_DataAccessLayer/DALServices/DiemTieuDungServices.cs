using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Context;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class DiemTieuDungServices : IDiemTieuDungServices
    {
        private DatabaseContext _DBcontext;
        private List<DiemTieuDung> _lstDiemTieuDungs;

        public DiemTieuDungServices()
        {
            _DBcontext = new DatabaseContext();
            _lstDiemTieuDungs = new List<DiemTieuDung>();
            getlstDiemTieuDungfromDB();
        }
        public bool addDiemTieuDung(DiemTieuDung DiemTieuDung)
        {
            _DBcontext.DiemTieuDungs.Add(DiemTieuDung);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deleteDiemTieuDungu(DiemTieuDung DiemTieuDung)
        {
            _DBcontext.DiemTieuDungs.Remove(DiemTieuDung);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<DiemTieuDung> getlstDiemTieuDungfromDB()
        {
            _lstDiemTieuDungs = _DBcontext.DiemTieuDungs.ToList();
            return _lstDiemTieuDungs;
        }

        public bool save(DiemTieuDung DiemTieuDung)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updateDiemTieuDung(DiemTieuDung DiemTieuDung)
        {
            _DBcontext.DiemTieuDungs.Update(DiemTieuDung);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
