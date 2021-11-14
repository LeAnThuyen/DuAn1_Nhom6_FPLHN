using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;

namespace _2_BUS_BussinessLayer.Services
{
    public class QLyVatChuaServices : IQlyVatChua
    {
        private IServicesVatChua _iServicesVatChua;

        public QLyVatChuaServices()
        {
            _iServicesVatChua = new VatChuaServices();
            GetsList();
        }
        public bool addNV(VatChua VatChua)
        {
            _iServicesVatChua.addvatchua(VatChua);
            _iServicesVatChua.save(VatChua);
            return true;
        }

        public List<VatChua> GetsList()
        {
            return _iServicesVatChua.getlstvatchuafromDB();
        }

        public bool removeNV(VatChua VatChua)
        {
            _iServicesVatChua.deletevatchua(VatChua);
            _iServicesVatChua.save(VatChua);
            return true;
        }

        public bool updateNV(VatChua VatChua)
        {
            _iServicesVatChua.updatevatchua(VatChua);
            _iServicesVatChua.save(VatChua);
            return true;
        }
    }
}
