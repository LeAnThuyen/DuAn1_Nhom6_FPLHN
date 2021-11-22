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
    public class QlyHangHoaServices : IQlyHangHoa
    {
        private IServicesAnh _iServicesAnh;
        private IServicesChiTietHangHoa _iChiTietHangHoa;
        private IServicesDanhMuc _iServicesDanhMuc;
        private IServicesNhaSanXuat _iServicesNhaSanXuat;
        private IServicesNhomHuong _iServicesNhomHuong;
        private IServicesVatChua _iServicesVatChua;
        private IServicesXuatXu _iServicesXuatXu;
        private IDungTichServices _iDungTichServices;
        private IChatLieuServices _iChatLieuServices;
        private IServicesHangHoa _iServicesHangHoa;
        private List<HangHoa> _lsHangHoas;
        private List<ChiTietHangHoa> _lsChiTietHangHoas;
        private List<ViewHangHoa> _lsViewHangHoas;

        public QlyHangHoaServices()
        {
            _iServicesAnh = new AnhServices();
            _iChiTietHangHoa = new ChiTietHangHoaServices();
            _iServicesDanhMuc = new DanhMucServices();
            _iServicesNhaSanXuat = new NhaSanXuatServices();
            _iServicesNhomHuong = new NhomHuongServices();
            _iServicesVatChua = new VatChuaServices();
            _iServicesXuatXu = new XuatXuService();
            _iDungTichServices = new DungTichServices();
            _iChatLieuServices = new ChatLieuServie();
            _iServicesHangHoa = new HangHoaServices();
            _lsViewHangHoas = new List<ViewHangHoa>();
            _lsHangHoas = new List<HangHoa>();
            _lsChiTietHangHoas = new List<ChiTietHangHoa>();
            GetsList();

        }
        public bool AddSP(HangHoa HangHoa)
        {
          
            _iServicesHangHoa.addhanghoa(HangHoa);
            return true;
        }

        public bool AddSpChiTiet(ChiTietHangHoa ChiTietHangHoa)
        {
           
            _iChiTietHangHoa.addchitiet(ChiTietHangHoa);
            
            return true;
        }

        public List<ViewHangHoa> GetsList()
        {
            _lsViewHangHoas = (from a in _iServicesHangHoa.getlsthanghoafromDB()
                    join b in _iServicesNhaSanXuat.getlstnxsfromDB() on a.IdnhaSanXuat equals b.IdnhaSanXuat
                    join c in _iChiTietHangHoa.getlstchitietthanghoafromDB() on a.IdhangHoa equals c.IdthongTinHangHoa
                    join d in _iServicesAnh.getlstanhfromDB() on c.Idanh equals d.Idanh
                    join e in _iServicesNhomHuong.getlstnhomhuongfromDB() on c.IdnhomHuong equals e.IdnhomHuong
                    join f in _iServicesXuatXu.getlstxuatxufromDB() on c.IdquocGia equals f.IdquocGia
                    join g in _iServicesDanhMuc.getlstdanhmucfromDB() on a.IddanhMuc equals g.IddanhMuc
                    join h in _iChatLieuServices.getlstchatlieufromDB() on c.IdchatLieu equals h.IdchatLieu
                    join i in _iDungTichServices.getlstdungtichfromDB() on c.IddungTich equals i.IddungTich
                    join k in _iServicesVatChua.getlstvatchuafromDB() on c.IdvatChua equals k.IdvatChua
                    select new ViewHangHoa()
                    {
                        HangHoa = a,
                        NhaSanXuat = b,
                        ChiTietHangHoa = c,
                        Anh = d,
                        NhomHuong = e,
                        XuatXu = f,
                        DanhMuc = g,
                        ChatLieu = h,
                        DungTich = i,
                        VatChua=k
                    }
                ).ToList();
            return _lsViewHangHoas;
        }

        public List<ChiTietHangHoa> GetsListCTHH()
        {
            _lsChiTietHangHoas = _iChiTietHangHoa.getlstchitietthanghoafromDB();
            return _lsChiTietHangHoas;
        }

        public List<HangHoa> GetsListHH()
        {
            _lsHangHoas = _iServicesHangHoa.getlsthanghoafromDB();
            return _lsHangHoas;
        }

        public bool RemoveSP(HangHoa HangHoa)
        {
            _lsHangHoas.Remove(HangHoa);
            _iServicesHangHoa.deletehanghoa(HangHoa);
            return true;
        }

        public bool RemoveSPChiTiet(ChiTietHangHoa ChiTietHangHoa)
        {
            _lsChiTietHangHoas.Remove(ChiTietHangHoa);
            _iChiTietHangHoa.deletechitiet(ChiTietHangHoa);
            return true;
        }

        public void SaveChiTietHangHoa(ChiTietHangHoa ChiTietHangHoa)
        {
            _iChiTietHangHoa.save(ChiTietHangHoa);
        }

        public void SaveHangHoa(HangHoa HangHoa)
        {
            _iServicesHangHoa.save(HangHoa);
        }

        public bool UpdateSP(HangHoa HangHoa)
        {
            _iServicesHangHoa.updatehanghoa(HangHoa);
            return true;
        }

        public bool UpdateSPChiTiet(ChiTietHangHoa ChiTietHangHoa)
        {
            _iChiTietHangHoa.updatechitiet(ChiTietHangHoa);
            return true;
        }
    }
}
