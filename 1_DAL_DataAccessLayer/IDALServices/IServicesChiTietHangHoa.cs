using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesChiTietHangHoa
    {
        List<ChiTietHangHoa> getlstchitietthanghoafromDB();
        bool addchitiet(ChiTietHangHoa cthh);
        bool deletechitiet(ChiTietHangHoa cthh);
        bool updatechitiet(ChiTietHangHoa cthh);
        bool save(ChiTietHangHoa cthh);
    }
}
