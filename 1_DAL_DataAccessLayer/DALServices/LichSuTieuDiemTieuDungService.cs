using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class LichSuTieuDiemTieuDungService : ILichSuDiemTieuDung
    {
        private DatabaseContext _DBcontext;
        private List<LichSuTieuDungDiem> _lstLichSuTieuDungDiems;

        public LichSuTieuDiemTieuDungService()
        {
            _DBcontext = new DatabaseContext();
            _lstLichSuTieuDungDiems = new List<LichSuTieuDungDiem>();
            getlstDiemTieuDungfromDB();
        }
        public bool addLichSU(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            _DBcontext.LichSuTieuDungDiems.Add(LichSuTieuDungDiem);

            return true;
        }

        public bool deleteLichSu(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            _DBcontext.LichSuTieuDungDiems.Remove(LichSuTieuDungDiem);

            return true;
        }

        public List<LichSuTieuDungDiem> getlstDiemTieuDungfromDB()
        {
            _lstLichSuTieuDungDiems = _DBcontext.LichSuTieuDungDiems.ToList();
            return _lstLichSuTieuDungDiems;
        }

        public bool save(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updateLichSU(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            _DBcontext.LichSuTieuDungDiems.Update(LichSuTieuDungDiem);

            return true;
        }
    }
}
