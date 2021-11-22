using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;

namespace _2_BUS_BussinessLayer.ModelViews
{
    public class ViewKhachHang
    {
        public KhachHang KhachHang { get; set; }
        public DiemTieuDung DiemTieuDung { get; set; }
        public LichSuTieuDungDiem LichSuTieuDungDiem { get; set; }
    }
}
