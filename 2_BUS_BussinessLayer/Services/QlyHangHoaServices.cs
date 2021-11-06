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

        }
        public bool AddSP(HangHoa HangHoa)
        {
            _lsHangHoas.Add(HangHoa);
            _iServicesHangHoa.addhanghoa(HangHoa);
            return true;
        }

        public bool AddSpChiTiet(ChiTietHangHoa ChiTietHangHoa)
        {
            throw new NotImplementedException();
        }

        public List<ViewHangHoa> GetsList()
        {
            _lsViewHangHoas = ( from a in _iServicesHangHoa.getlsthanghoafromDB() 
                                        join b in _iServicesNhaSanXuat.getlstnxsfromDB() on a.IdnhaSanXuat equals b.IdnhaSanXuat
                                        join c in _iChiTietHangHoa.getlstchitietthanghoafromDB() on a.IdhangHoa equals c.IdthongTinHangHoa
                                        join d in _iServicesAnh.getlstanhfromDB() on c.Idanh equals d.Idanh
                                        join e in _iServicesNhomHuong.getlstnhomhuongfromDB() on c.IdnhomHuong equals e.IdnhomHuong
                                        
                )
            return _lsViewHangHoas;
        }

        public bool RemoveSP(HangHoa HangHoa)
        {
            throw new NotImplementedException();
        }

        public bool RemoveSPChiTiet(ChiTietHangHoa ChiTietHangHoa)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSP(HangHoa HangHoa)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSPChiTiet(ChiTietHangHoa ChiTietHangHoa)
        {
            throw new NotImplementedException();
        }
    }
}
