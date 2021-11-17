using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQLyBanHang
    {

        public bool AddHoaDon(HoaDonBan hdb);
        public bool UpdateHoaDon(HoaDonBan hdb);
        public bool RemoveHoaDon(HoaDonBan hdb);
        void SaveHoaDon(HoaDonBan hdb);
        //
        public bool AddHoaDonChiTiet(HoaDonChiTiet hdct);
        public bool UpdateHoaDonChiTiet(HoaDonChiTiet hdct);
        public bool RemoveHoaDonChiTiet(HoaDonChiTiet hdct);
        public List<ViewBanHang> GetsList();
        void SaveHoaDonChiTiet(HoaDonChiTiet hdct);
        //
        public bool AddKhachHang(KhachHang kh);
        public bool UpdateKhachHang(KhachHang kh);
        public bool RemoveKhachHang(KhachHang kh);
        //
        public bool AddDiem(DiemTieuDung diem);
        public bool UpdateDiem(DiemTieuDung diem);
        public bool RemoveDiem(DiemTieuDung diem);



    }
}
