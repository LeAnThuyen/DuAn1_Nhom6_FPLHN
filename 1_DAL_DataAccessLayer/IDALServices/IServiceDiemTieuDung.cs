using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServiceDiemTieuDung
    {

        List<DiemTieuDung> getlstdiemfromDB();
        bool adddiem(DiemTieuDung diem);
        bool deletediem(DiemTieuDung diem);
        bool updatediem(DiemTieuDung diem);
       
    }
}

