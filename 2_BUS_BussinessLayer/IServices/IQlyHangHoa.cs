using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyHangHoa
    {

        public bool AddSP(HangHoa HangHoa);
        public bool UpdateSP(HangHoa HangHoa);
        public bool RemoveSP(HangHoa HangHoa);
        public bool AddSpChiTiet(ChiTietHangHoa ChiTietHangHoa);
        public bool UpdateSPChiTiet(ChiTietHangHoa ChiTietHangHoa);
        public bool RemoveSPChiTiet(ChiTietHangHoa ChiTietHangHoa);
        public List<ViewHangHoa> GetsList();
        public List<HangHoa> GetsListHH();
        public List<ChiTietHangHoa> GetsListCTHH();
        void SaveChiTietHangHoa(ChiTietHangHoa ChiTietHangHoa);
        void SaveHangHoa(HangHoa HangHoa);
    }
}
