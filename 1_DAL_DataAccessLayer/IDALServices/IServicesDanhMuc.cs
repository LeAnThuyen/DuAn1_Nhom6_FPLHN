using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesDanhMuc
    {
        List<DanhMuc> getlstdanhmucfromDB();
        bool adddanhmuc(DanhMuc dm);
        bool deletedanhmuc(DanhMuc dm);
        bool updatedanhmuc(DanhMuc dm);
        bool save(DanhMuc dm);
    }
}
