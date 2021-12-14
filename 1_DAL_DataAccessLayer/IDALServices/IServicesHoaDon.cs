using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesHoaDon
    {
        List<HoaDonBan> getlsthdbfromDBAsNo();
        List<HoaDonBan> getlsthdbfromDB();
        bool addhdb(HoaDonBan hdb);
        bool deletehdb(HoaDonBan hdb);
        bool updatehdb(HoaDonBan hdb);
        bool save();
    }
}
