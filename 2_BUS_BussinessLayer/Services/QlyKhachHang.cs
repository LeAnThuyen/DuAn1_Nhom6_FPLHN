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
    public class QlyKhachHang : IQlyKhachHang
    {
        private KhachHangService _khachHang;

        private List<KhachHang> _lstKhachhang;
        public QlyKhachHang()
        {
            _khachHang = new KhachHangService();
            _lstKhachhang = new List<KhachHang>();
        }

        public bool addDiemTD(DiemTieuDung DiemTieuDung)
        {
            throw new NotImplementedException();
        }

        public bool addKH(KhachHang khachHang)
        {
            _khachHang.addkhachhang(khachHang);

            return true;
        }

        public bool addLichSu(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            throw new NotImplementedException();
        }

        public List<KhachHang> GetsList()
        {
            _lstKhachhang = _khachHang.getlstkhachhangformDB();
            return _lstKhachhang;
        }

        public List<DiemTieuDung> GetsListDiemTD()
        {
            throw new NotImplementedException();
        }

        public List<DiemTieuDung> GetsListDTD()
        {
            throw new NotImplementedException();
        }

        public List<KhachHang> GetsListKH()
        {
            throw new NotImplementedException();
        }

        public List<LichSuTieuDungDiem> GetsListLS()
        {
            throw new NotImplementedException();
        }

        public List<LichSuTieuDungDiem> GetsListLSTDD()
        {
            throw new NotImplementedException();
        }

        public bool removeDiemTD(DiemTieuDung DiemTieuDung)
        {
            throw new NotImplementedException();
        }

        public bool removeKH(KhachHang khachHang)
        {
            _khachHang.deletekhachhang(khachHang);

            return true;
        }

        public bool removeLichSu(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            throw new NotImplementedException();
        }

        public void Save(KhachHang khachHang)
        {
            _khachHang.savekhachhang(khachHang);

        }

        public void SaveDTD(DiemTieuDung DiemTieuDung)
        {
            throw new NotImplementedException();
        }

        public void SaveKH(KhachHang KhachHang)
        {
            throw new NotImplementedException();
        }

        public void SaveLichSU(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            throw new NotImplementedException();
        }

        public void SenderDataHD()
        {
            throw new NotImplementedException();
        }

        public bool updateDiemTD(DiemTieuDung DiemTieuDung)
        {
            throw new NotImplementedException();
        }

        public bool updateKH(KhachHang khachHang)
        {
            _khachHang.updatekhachhang(khachHang);
            return true;
        }

        public bool updateLichSU(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            throw new NotImplementedException();
        }

        List<ViewKhachHang> IQlyKhachHang.GetsList()
        {
            throw new NotImplementedException();
        }
    }
}
