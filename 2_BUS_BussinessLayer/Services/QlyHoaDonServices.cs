using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.Services
{
    public class QlyHoaDonServices : IQlyHoaDon
    {
        private IServicesHoaDon _iServicesHoaDon;
        private IServicesHoaDonChiTiet _iServicesHoaDonChiTiet;
       
        public QlyHoaDonServices()
        {
            
        }
        public bool addHD(HoaDonBan HoaDonBan)
        {
            throw new NotImplementedException();
        }

        public bool addHDCT(HoaDonChiTiet HoaDonChiTiet)
        {
            throw new NotImplementedException();
        }

        public List<ViewHoaDon> GetsList()
        {
            throw new NotImplementedException();
        }

        public List<HoaDonBan> GetsListHD()
        {
            throw new NotImplementedException();
        }

        public List<HoaDonChiTiet> GetsListHDCT()
        {
            throw new NotImplementedException();
        }

        public bool removeHD(HoaDonBan HoaDonBan)
        {
            throw new NotImplementedException();
        }

        public bool removeHDCT(HoaDonChiTiet HoaDonChiTiet)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SenderDataHD()
        {
            throw new NotImplementedException();
        }

        public void SenderDataHDCT()
        {
            throw new NotImplementedException();
        }

        public bool updateHD(HoaDonBan HoaDonBan)
        {
            throw new NotImplementedException();
        }

        public bool updateHDCTV(HoaDonChiTiet HoaDonChiTiet)
        {
            throw new NotImplementedException();
        }
    }
}
