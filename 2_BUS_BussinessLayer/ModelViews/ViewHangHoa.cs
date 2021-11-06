using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;

namespace _2_BUS_BussinessLayer.ModelViews
{
    public class ViewHangHoa
    {
        public HangHoa HangHoa { get; set; }
        public ChiTietHangHoa ChiTietHangHoa { get; set; }
        public Anh Anh { get; set; }
        public XuatXu XuatXu { get; set; }
        public DungTich DungTich { get; set; }
        public ChatLieu ChatLieu { get; set; }
        public VatChua VatChua { get; set; }
        public NhomHuong NhomHuong { get; set; }
        public DanhMuc DanhMuc { get; set; }
        public NhaSanXuat NhaSanXuat { get; set; }

    }
}
