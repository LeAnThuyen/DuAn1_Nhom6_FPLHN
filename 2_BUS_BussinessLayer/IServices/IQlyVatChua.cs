using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;

namespace _2_BUS_BussinessLayer.IServices
{
   public  interface IQlyVatChua
    {
        bool addNV(VatChua VatChua);
        bool removeNV(VatChua VatChua);
        bool updateNV(VatChua VatChua);
        List<VatChua> GetsList();
    }
}
