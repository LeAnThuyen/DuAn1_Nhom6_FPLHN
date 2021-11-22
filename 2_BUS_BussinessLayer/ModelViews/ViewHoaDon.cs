using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;

namespace _2_BUS_BussinessLayer.ModelViews
{
   public  class ViewHoaDon
    {
        public HoaDonBan HoaDonBan { get; set; }
        public HoaDonChiTiet HoaDonChiTiet { get; set; }
        public KhachHang KhachHang { get; set; }
        public DiemTieuDung DiemTieuDung { get; set; }
        public NhanVien NhanVien { get; set; }
        public Role Role { get; set; }
        public ChiTietHangHoa ChiTietHangHoa { get; set; }
        public HangHoa HangHoa { get; set; }
        public LichSuTieuDungDiem LichSuTieuDungDiem { get; set; }
        public Anh Anh { get; set; }
        

    }
}
