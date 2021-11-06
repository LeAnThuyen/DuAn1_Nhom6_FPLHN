using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesHangHoa
    {

        List<HangHoa> getlsthanghoafromDB();
        bool addhanghoa(HangHoa hh);
        bool deletehanghoa(HangHoa hh);
        bool updatehanghoa(HangHoa hh);
        bool save(HangHoa hh);
    }
}
