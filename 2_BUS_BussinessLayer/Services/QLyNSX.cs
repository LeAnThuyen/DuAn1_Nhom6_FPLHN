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
    public class QLyNSX :IQlyNSX
    {
        private NhaSanXuatServices _nhasanxuat;

        private List<NhaSanXuat> _lstnhasanxuat;
        public QLyNSX()
        {
            _nhasanxuat = new NhaSanXuatServices();
            _lstnhasanxuat = new List<NhaSanXuat>();
        }
        public bool addNSX(NhaSanXuat nhaSanXuat)
        {
            _nhasanxuat.addnhasanxuat(nhaSanXuat);

            return true;
        }


        public List<NhaSanXuat> GetsList()
        {
            _lstnhasanxuat = _nhasanxuat.getlstnxsfromDB();
            return _lstnhasanxuat;

        }
        public bool removeNSX(NhaSanXuat nhaSanXuat)
        {
            _nhasanxuat.deletenhasanxuat(nhaSanXuat);

            return true;
        }

        public void Save(NhaSanXuat nhaSanXuat)
        {
            _nhasanxuat.save(nhaSanXuat);


        }

        public bool updateNSX(NhaSanXuat nhaSanXuat)
        {
            _nhasanxuat.updatenhasanxuat(nhaSanXuat);
            return true;
        }

    }
}
