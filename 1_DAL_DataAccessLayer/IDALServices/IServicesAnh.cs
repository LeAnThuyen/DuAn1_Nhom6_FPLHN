using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
    public interface IServicesAnh
    {
        List<Anh> getlstanhfromDB();
        bool addanh(Anh img);
        bool deleteanh(Anh img);
        bool updateanh(Anh img);
        bool save(Anh img);
    }
}
