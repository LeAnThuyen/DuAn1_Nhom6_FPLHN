using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesHoaDonChiTiet
    {
        List<HoaDonChiTiet> getlsthdctfromDB();
        bool addhdct(HoaDonChiTiet hdct);
        bool deletehdct(HoaDonChiTiet hdct);
        bool updatehdct(HoaDonChiTiet hdct);
        bool save();
    }
}
