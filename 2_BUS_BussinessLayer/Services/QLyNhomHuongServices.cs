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
    public class QLyNhomHuongServices : IQlyNhomHuong
    {
        private IServicesNhomHuong _iServicesNhomHuong;

        public QLyNhomHuongServices()
        {
            _iServicesNhomHuong = new NhomHuongServices();
            GetsList();
        }
        public bool addNV(NhomHuong NhomHuong)
        {
            _iServicesNhomHuong.addnhomhuong(NhomHuong);
            _iServicesNhomHuong.save(NhomHuong);
            return true;
        }

        public List<NhomHuong> GetsList()
        {
            return _iServicesNhomHuong.getlstnhomhuongfromDB();
        }

        public bool removeNV(NhomHuong NhomHuong)
        {
            _iServicesNhomHuong.deletenhomhuong(NhomHuong);
            _iServicesNhomHuong.save(NhomHuong);
            return true;
        }

        public bool updateNV(NhomHuong NhomHuong)
        {
            _iServicesNhomHuong.updatenhomhuong(NhomHuong);
            _iServicesNhomHuong.save(NhomHuong);
            return true;
        }
    }
}
