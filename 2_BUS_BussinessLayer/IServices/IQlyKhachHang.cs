using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyKhachHang
    {
        //Hóa đơn
        bool addKH(KhachHang KhachHang);
        bool removeKH(KhachHang KhachHang);
        bool updateKH(KhachHang KhachHang);
 
        void SenderDataHD();
        //Hóa đơn Chi Tiết
        bool addLichSu(LichSuTieuDungDiem LichSuTieuDungDiem);
        bool removeLichSu(LichSuTieuDungDiem LichSuTieuDungDiem);
        bool updateLichSU(LichSuTieuDungDiem LichSuTieuDungDiem);
        List<LichSuTieuDungDiem> GetsListLSTDD();
        //Điểm tieeu dùng
        bool addDiemTD(DiemTieuDung DiemTieuDung);
        bool removeDiemTD(DiemTieuDung DiemTieuDung);
        bool updateDiemTD(DiemTieuDung DiemTieuDung);
        List<DiemTieuDung> GetsListDiemTD();

        void SaveKH(KhachHang KhachHang);
        void SaveDTD(DiemTieuDung DiemTieuDung);
        void SaveLichSU(LichSuTieuDungDiem LichSuTieuDungDiem);
        //
        List<ViewKhachHang> GetsList();
        List<DiemTieuDung> GetsListDTD();
        List<KhachHang> GetsListKH();
        List<LichSuTieuDungDiem> GetsListLS();
    }
}
