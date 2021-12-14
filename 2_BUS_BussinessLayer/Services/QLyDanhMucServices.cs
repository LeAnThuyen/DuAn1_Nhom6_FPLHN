using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.Services
{
    public class QLyDanhMucServices : IQlyDanhMuc
    {
        private IServicesDanhMuc _iServicesDanhMuc;
        
        public QLyDanhMucServices()
        {
            _iServicesDanhMuc = new DanhMucServices();
            GetsList();
        }
        public bool addNV(DanhMuc DanhMuc)
        {
            _iServicesDanhMuc.adddanhmuc(DanhMuc);
            _iServicesDanhMuc.save(DanhMuc);
            return true;
        }

        public List<DanhMuc> GetsList()
        {
            return _iServicesDanhMuc.getlstdanhmucfromDB();
        }

        public bool removeNV(DanhMuc DanhMuc)
        {
            _iServicesDanhMuc.deletedanhmuc(DanhMuc);
            _iServicesDanhMuc.save(DanhMuc);
            return true;
        }

        public bool updateNV(DanhMuc DanhMuc)
        {
            _iServicesDanhMuc.updatedanhmuc(DanhMuc);
            _iServicesDanhMuc.save(DanhMuc);
            return true;
        }
    }
}
