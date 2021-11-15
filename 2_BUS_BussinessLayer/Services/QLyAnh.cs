using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.Services
{
    public class QLyAnh : IQlyAnh
    {
        private AnhServices _anh;

        private List<Anh> _lstAnh;
        public QLyAnh()
        {
            _anh = new AnhServices();
            _lstAnh = new List<Anh>();
        }
        public bool addAnh(Anh anh)
        {
            _anh.addanh(anh);

            return true;
        }


        public List<Anh> GetsList()
        {
            _lstAnh = _anh.getlstanhfromDB();
            return _lstAnh;
        }

        public bool removeAnh(Anh anh)
        {
            _anh.deleteanh(anh);

            return true;
        }

        public void Save(Anh anh)
        {
            _anh.save(anh);

        }

        public bool updateAnh(Anh anh)
        {
            _anh.updateanh(anh);
            return true;
        }
    }
}
