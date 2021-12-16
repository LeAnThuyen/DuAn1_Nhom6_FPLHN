
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
    public class HoaDonBanServices : IServicesHoaDon
    {

        private DatabaseContext _DBcontext;
        private List<HoaDonBan> _lsthoadonban;
        public HoaDonBanServices()
        {
            _DBcontext = new DatabaseContext();
            _lsthoadonban = new List<HoaDonBan>();
            getlsthdbfromDB();
            getlsthdbfromDBAsNo();
        }
        public bool addhdb(HoaDonBan hdb)
        {
            _DBcontext.HoaDonBans.Add(hdb);
         
            return true;
        }

        public bool deletehdb(HoaDonBan hdb)
        {
            _DBcontext.HoaDonBans.Remove(hdb);
     
            return true;
        }

        public List<HoaDonBan> getlsthdbfromDB()
        {
            _lsthoadonban = _DBcontext.HoaDonBans.ToList();
            return _lsthoadonban;
        }

        public List<HoaDonBan> getlsthdbfromDBAsNo()
        {
            _lsthoadonban = _DBcontext.HoaDonBans.AsNoTracking().ToList();
            return _lsthoadonban;
        }

        public bool save()
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updatehdb(HoaDonBan hdb)
        {
            _DBcontext.HoaDonBans.Update(hdb);
        
            return true;
        }
    }
}
