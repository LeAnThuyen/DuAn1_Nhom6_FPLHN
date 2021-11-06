using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesVatChua
    {

        List<VatChua> getlstvatchuafromDB();
        bool addvatchua(VatChua vt);
        bool deletevatchua(VatChua vt);
        bool updatevatchua(VatChua vt);
        bool save(VatChua vt);
    }
}
