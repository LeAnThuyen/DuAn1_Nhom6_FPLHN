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
    public class QLyKhachHangServices:IQlyKhachHang
    {
        private IKhachHangServices _iKhachHangServices;
        private IServiceDiemTieuDung idiemser;
        private ILichSuDiemTieuDung _iLichSuDiemTieuDung;
        private List<KhachHang> _lsKhachHangs;
        private List<DiemTieuDung> _lsDiemTieuDungs;
        private List<LichSuTieuDungDiem> _lichSuTieuDungDiems;
        private List<ViewKhachHang> _lsViewKhachHangs;

        public QLyKhachHangServices()
        {
            _iKhachHangServices = new KhachHangService();
            idiemser = new DiemTieuDungServices();
            _iLichSuDiemTieuDung = new LichSuTieuDiemTieuDungService();
            _lsViewKhachHangs = new List<ViewKhachHang>();
            _lichSuTieuDungDiems = new List<LichSuTieuDungDiem>();
            _lsKhachHangs = new List<KhachHang>();
            _lsDiemTieuDungs = new List<DiemTieuDung>();
            GetsList();
            GetsListDiemTD();
            GetsListLS();
            GetsListKH();
        }
        public bool addKH(KhachHang KhachHang)
        {
            _iKhachHangServices.addkhachhang(KhachHang);
            _lsKhachHangs.Add(KhachHang);
            return true;
        }

        public bool removeKH(KhachHang KhachHang)
        {
            _iKhachHangServices.deletekhachhang(KhachHang);
            _lsKhachHangs.Remove(KhachHang);
            return true;
        }

        public bool updateKH(KhachHang KhachHang)
        {
            _iKhachHangServices.updatekhachhang(KhachHang);
            return true;
        }

        public void SenderDataHD()
        {
            throw new NotImplementedException();
        }

        public bool addLichSu(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            _iLichSuDiemTieuDung.addLichSU(LichSuTieuDungDiem);
            _lichSuTieuDungDiems.Add(LichSuTieuDungDiem);
            return true;
        }

        public bool removeLichSu(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            _iLichSuDiemTieuDung.deleteLichSu(LichSuTieuDungDiem);
            _lichSuTieuDungDiems.Remove(LichSuTieuDungDiem);
            return true;
        }

        public bool updateLichSU(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            _iLichSuDiemTieuDung.updateLichSU(LichSuTieuDungDiem);
            return true;
        }

        public List<LichSuTieuDungDiem> GetsListLSTDD()
        {
            _lichSuTieuDungDiems = _iLichSuDiemTieuDung.getlstDiemTieuDungfromDB();
            return _lichSuTieuDungDiems;
        }

        public bool addDiemTD(DiemTieuDung DiemTieuDung)
        {
            idiemser.adddiem(DiemTieuDung);
            _lsDiemTieuDungs.Add(DiemTieuDung);
            return true;
        }

        public bool removeDiemTD(DiemTieuDung DiemTieuDung)
        {
            idiemser.deletediem(DiemTieuDung);
            _lsDiemTieuDungs.Remove(DiemTieuDung);
            return true;
        }

        public bool updateDiemTD(DiemTieuDung DiemTieuDung)
        {
            idiemser.updatediem(DiemTieuDung);
            return true;
        }

        public List<DiemTieuDung> GetsListDiemTD()
        {
            _lsDiemTieuDungs = new List<DiemTieuDung>();
            return _lsDiemTieuDungs;
        }

        public void SaveKH(KhachHang KhachHang)
        {
            _iKhachHangServices.savekhachhang(KhachHang);
        }

        public void SaveDTD(DiemTieuDung DiemTieuDung)
        {
            
        }

        public void SaveLichSU(LichSuTieuDungDiem LichSuTieuDungDiem)
        {
            _iLichSuDiemTieuDung.save(LichSuTieuDungDiem);
        }

        public List<ViewKhachHang> GetsList()
        {
            _lsViewKhachHangs=(from a in _iKhachHangServices.getlstkhachhangformDB() 
                    join b in idiemser.getlstdiemfromDB() on a.IddiemTieuDung equals b.IddiemTieuDung
                    join c in _iLichSuDiemTieuDung.getlstDiemTieuDungfromDB() on b.IddiemTieuDung equals c.IddiemTieuDung
                    select new ViewKhachHang()
                    {
                        KhachHang = a,
                        DiemTieuDung = b,
                        LichSuTieuDungDiem = c
                    }).ToList();

            return _lsViewKhachHangs;
        }

        public List<DiemTieuDung> GetsListDTD()
        {
            _lsDiemTieuDungs = idiemser.getlstdiemfromDB();
            return _lsDiemTieuDungs;
        }

        public List<KhachHang> GetsListKH()
        {
            _lsKhachHangs = _iKhachHangServices.getlstkhachhangformDB();
            return _lsKhachHangs;
        }

        public List<LichSuTieuDungDiem> GetsListLS()
        {
            _lichSuTieuDungDiems = _iLichSuDiemTieuDung.getlstDiemTieuDungfromDB();
            return _lichSuTieuDungDiems;
        }
    }
}
