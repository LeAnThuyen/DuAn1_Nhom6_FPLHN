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
    public class QlyHoaDonServices : IQlyHoaDon
    {
        private IServicesHoaDon _iServicesHoaDon;
        private IServicesHoaDonChiTiet _iServicesHoaDonChiTiet;
        private IKhachHangServices _iKhachHangServices;
        //   private IDiemTieuDungServices _iDiemTieuDungServices;
        private IServiceDiemTieuDung idiemser;
        private IServicesNhanVien _iNhanVienServices;
        private IRolesServices _iRolesServices;
        private IServicesChiTietHangHoa _iChiTietHangHoa;
        private IServicesHangHoa _iServicesHangHoa;
        private ILichSuDiemTieuDung _iLichSuDiemTieuDung;
        private IServicesAnh _iServicesAnh;
        private List<ViewHoaDon> _lstViewHoaDons;
        private List<HoaDonBan> _lstHoaDonBans;
        private List<HoaDonChiTiet> _lstHoaDonChiTiets;

        public QlyHoaDonServices()
        {
            _iServicesHoaDon = new HoaDonBanServices();
            _iServicesHoaDonChiTiet = new HoaDonChiTietServices();
            _iKhachHangServices = new KhachHangService();
            idiemser = new DiemTieuDungServices();
            _iNhanVienServices = new NhanVienServices();
            _iRolesServices = new RolesServices();
            _iChiTietHangHoa = new ChiTietHangHoaServices();
            _iServicesHangHoa = new HangHoaServices();
            _iLichSuDiemTieuDung = new LichSuTieuDiemTieuDungService();
            _lstViewHoaDons = new List<ViewHoaDon>();
            _iServicesAnh = new AnhServices();
            GetsList();
            GetsListHD();
            GetsListHDCT();
            GetsListHDNoAs();
        }

        public bool addHD(HoaDonBan HoaDonBan)
        {
            _iServicesHoaDon.addhdb(HoaDonBan);
            _lstHoaDonBans.Add(HoaDonBan);
            return true;
        }

        public bool addHDCT(HoaDonChiTiet HoaDonChiTiet)
        {
            _iServicesHoaDonChiTiet.addhdct(HoaDonChiTiet);
            _lstHoaDonChiTiets.Add(HoaDonChiTiet);
            return true;
        }

        public List<ViewHoaDon> GetsList()
        {
            _lstViewHoaDons = (from a in _iServicesHoaDon.getlsthdbfromDB()
                    join b in _iServicesHoaDonChiTiet.getlsthdctfromDB() on a.IdhoaDon equals b.IdhoaDon
                    join c in _iKhachHangServices.getlstkhachhangformDB() on a.IdkhachHang equals c.IdkhachHang
                    join d in idiemser.getlstdiemfromDB() on c.IddiemTieuDung equals d
                        .IddiemTieuDung
                    join e in _iNhanVienServices.getlstnhanvienfromDB() on a.Iduser equals e.Iduser
                    join f in _iRolesServices.getListRole() on e.Idrole equals f.Idrole
                    join g in _iChiTietHangHoa.getlstchitietthanghoafromDB() on b.IdthongTinHangHoa equals g
                        .IdthongTinHangHoa
                    join h in _iServicesHangHoa.getlsthanghoafromDB() on g.IdhangHoa equals h.IdhangHoa
                    join i in _iLichSuDiemTieuDung.getlstDiemTieuDungfromDB() on c.IddiemTieuDung equals i.IddiemTieuDung
                    join k in _iServicesAnh.getlstanhfromDB() on g.Idanh equals k.Idanh
                               select new ViewHoaDon()
                    {
                        HoaDonBan = a,
                        HoaDonChiTiet = b,
                        KhachHang = c,
                        DiemTieuDung = d,
                        NhanVien = e,
                        Role = f,
                        ChiTietHangHoa = g,
                        HangHoa = h,
                        LichSuTieuDungDiem = i,
                        Anh=k
                    }
                ).ToList();


            return _lstViewHoaDons;
        }

        public List<HoaDonBan> GetsListHD()
        {
            _lstHoaDonBans = _iServicesHoaDon.getlsthdbfromDB();
            return _lstHoaDonBans;
        }

        public List<HoaDonChiTiet> GetsListHDCT()
        {
            _lstHoaDonChiTiets = _iServicesHoaDonChiTiet.getlsthdctfromDB();
            return _lstHoaDonChiTiets;
        }

        public List<HoaDonBan> GetsListHDNoAs()
        {
            _lstHoaDonBans = _iServicesHoaDon.getlsthdbfromDBAsNo();
            return _lstHoaDonBans;
        }

        public bool removeHD(HoaDonBan HoaDonBan)
        {
            _iServicesHoaDon.deletehdb(HoaDonBan);
            _lstHoaDonBans.Add(HoaDonBan);
            return true;
        }

        public bool removeHDCT(HoaDonChiTiet HoaDonChiTiet)
        {
            _iServicesHoaDonChiTiet.deletehdct(HoaDonChiTiet);
            _lstHoaDonChiTiets.Add(HoaDonChiTiet);
            return true;
        }

        public void SaveHD()
        {
            _iServicesHoaDon.save();
        }

        public void SaveHDCT()
        {
            _iServicesHoaDonChiTiet.save(); 
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
            _iServicesHoaDon.updatehdb(HoaDonBan);
            //_lstHoaDonBans.Add(HoaDonBan);
            return true;
        }

        public bool updateHDCTV(HoaDonChiTiet HoaDonChiTiet)
        {
            _iServicesHoaDonChiTiet.updatehdct(HoaDonChiTiet);
            _lstHoaDonChiTiets.Add(HoaDonChiTiet);
            return true;
        }
    }
}
