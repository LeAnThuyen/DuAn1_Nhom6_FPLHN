using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.Services
{
   public class QLyBanHangServices: IQLyBanHang
    {
        private IServicesHoaDonChiTiet ihdctser;
        private IServicesHoaDon ihdbser;
        private IServicesNhanVien invser;
        private IKhachHangServices ikhser;
        private IServicesHangHoa ihhser;
        private IServicesChiTietHangHoa  icthhser;
        private IServiceDiemTieuDung idiemser;
        private IServicesAnh ianhser;
        private IDungTichServices idtser;
        private List<ViewBanHang> _lstbanhang;
    
        public QLyBanHangServices()
        {
            ihdctser = new HoaDonChiTietServices();
            ihdbser = new HoaDonBanServices();
            invser = new NhanVienServices();
            ihhser = new HangHoaServices();
            icthhser = new ChiTietHangHoaServices();
            ianhser = new AnhServices();
            idtser = new DungTichServices();
            ikhser = new KhachHangService();
            //idiemser = new DiemTieuDungServices();
            idiemser = new DiemTieuDungServices();
             _lstbanhang = new List<ViewBanHang>();
            GetsList();
        }

        public bool AddDiem(DiemTieuDung diem)
        {
            idiemser.adddiem(diem);
            return true;

        }

        public bool AddHoaDon(HoaDonBan hdb)
        {
            ihdbser.addhdb(hdb);
            return true;
        }

        public bool AddHoaDonChiTiet(HoaDonChiTiet hdct)
        {

            ihdctser.addhdct(hdct);
            return true;
        }

        public bool AddKhachHang(KhachHang kh)
        {
            ikhser.addkhachhang(kh);
            return true;
        }

        public List<ViewBanHang> GetsList()
        {
            _lstbanhang = (from a in ihdbser.getlsthdbfromDB()
                               join b in ihdctser.getlsthdctfromDB() on a.IdhoaDon equals b.IdhoaDon
                               join c in ikhser.getlstkhachhangformDB() on a.IdkhachHang equals c.IdkhachHang
                               join d in invser.getlstnhanvienfromDB() on a.Iduser equals d.Iduser
                               join e in idiemser.getlstdiemfromDB() on c.IddiemTieuDung equals e.IddiemTieuDung
                               join f in icthhser.getlstchitietthanghoafromDB() on b.IdthongTinHangHoa equals f.IdthongTinHangHoa
                               join g in ihhser.getlsthanghoafromDB() on f.IdhangHoa equals g.IdhangHoa
                               join k in ianhser.getlstanhfromDB() on f.Idanh equals k.Idanh
                               join l in idtser.getlstdungtichfromDB() on f.IddungTich equals l.IddungTich

                           select new ViewBanHang()
                           {
                               HoaDonBan = a,
                               HoaDonChiTiet = b,
                               KhachHang = c,
                               NhanVien = d,
                               DiemTieuDung = e,
                               HangHoa=g,
                               ChiTietHangHoa=f,
                               Anh=k,
                               DungTich=l

               }
               ).ToList();
            return _lstbanhang;
        }

        public bool RemoveDiem(DiemTieuDung diem)
        {
            idiemser.deletediem(diem);
            return true;

        }

        public bool RemoveHoaDon(HoaDonBan hdb)
        {
            ihdbser.deletehdb(hdb);
            return true;
        }

        public bool RemoveHoaDonChiTiet(HoaDonChiTiet hdct)
        {
            ihdctser.deletehdct(hdct);
            return true;
        }

        public bool RemoveKhachHang(KhachHang kh)
        {
            ikhser.deletekhachhang(kh);
            return true;
        }

        public void SaveHoaDon(HoaDonBan hdb)
        {
            ihdbser.save();
          
        }

        public void SaveHoaDonChiTiet(HoaDonChiTiet hdct)
        {
            ihdctser.save();
          
        }

        public bool UpdateDiem(DiemTieuDung diem)
        {
            idiemser.updatediem(diem);
            return true;

        }

        public bool UpdateHoaDon(HoaDonBan hdb)
        {
            ihdbser.updatehdb(hdb);
            return true;
        }

        public bool UpdateHoaDonChiTiet(HoaDonChiTiet hdct)
        {
            ihdctser.updatehdct(hdct);
            return true;
        }

        public bool UpdateKhachHang(KhachHang kh)
        {
            ikhser.updatekhachhang(kh);
            return true;
        }
    }
}
