﻿using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.ModelViews
{
   public class ViewBanHang
    {
        public HangHoa HangHoa { get; set; }
        public ChiTietHangHoa ChiTietHangHoa { get; set; }
        public HoaDonBan HoaDonBan { get; set; }
        public Anh Anh { get; set; }
        public DungTich DungTich { get; set; }
        public HoaDonChiTiet HoaDonChiTiet { get; set; }
        public KhachHang KhachHang { get; set; }
        public NhanVien NhanVien { get; set; }
        public DiemTieuDung DiemTieuDung { get; set; }
       
    }
}
