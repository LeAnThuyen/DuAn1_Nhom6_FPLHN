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
    public class HoaDonBanServices : IServicesHoaDon
    {

        private DatabaseContext _DBcontext;
        private List<HoaDonBan> _lsthoadonban;
        public HoaDonBanServices()
        {
            _DBcontext = new DatabaseContext();
            _lsthoadonban = new List<HoaDonBan>();
        }
        public bool addhdb(HoaDonBan hdb)
        {
            _DBcontext.HoaDonBans.Add(hdb);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletehdb(HoaDonBan hdb)
        {
            _DBcontext.HoaDonBans.Remove(hdb);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<HoaDonBan> getlsthdbfromDB()
        {
            _lsthoadonban = _DBcontext.HoaDonBans.AsNoTracking().ToList();
            return _lsthoadonban;
        }

        public bool updatehdb(HoaDonBan hdb)
        {
            _DBcontext.HoaDonBans.Update(hdb);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
