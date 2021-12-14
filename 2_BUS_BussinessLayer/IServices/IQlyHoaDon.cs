using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyHoaDon
    {
        //Hóa đơn
        bool addHD(HoaDonBan HoaDonBan);
        bool removeHD(HoaDonBan HoaDonBan);
        bool updateHD(HoaDonBan HoaDonBan);
        List<HoaDonBan> GetsListHD();
        List<HoaDonBan> GetsListHDNoAs();
        void SenderDataHD();
        //Hóa đơn Chi Tiết
        bool addHDCT(HoaDonChiTiet HoaDonChiTiet);
        bool removeHDCT(HoaDonChiTiet HoaDonChiTiet);
        bool updateHDCTV(HoaDonChiTiet HoaDonChiTiet);
        List<HoaDonChiTiet> GetsListHDCT();

        void SenderDataHDCT();
        void SaveHD();
        void SaveHDCT();
        //Hóa đơn tổng
        List<ViewHoaDon> GetsList();
    }
}
