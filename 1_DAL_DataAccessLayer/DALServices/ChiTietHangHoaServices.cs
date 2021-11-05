﻿using _1_DAL_DataAccessLayer.Context;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class ChiTietHangHoaServices : IServicesChiTietHangHoa
    {

        private DatabaseContext _DBcontext;
        private List<ChiTietHangHoa> _lstchitiethanghoa;
        public ChiTietHangHoaServices()
        {
            _DBcontext = new DatabaseContext();
            _lstchitiethanghoa = new List<ChiTietHangHoa>();
        }
        public bool addchitiet(ChiTietHangHoa cthh)
        {
            _DBcontext.ChiTietHangHoas.Add(cthh);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletechitiet(ChiTietHangHoa cthh)
        {
            _DBcontext.ChiTietHangHoas.Remove(cthh);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<ChiTietHangHoa> getlstchitietthanghoafromDB()
        {
            _lstchitiethanghoa = _DBcontext.ChiTietHangHoas.AsNoTracking().ToList();
            return _lstchitiethanghoa;
        }

        public bool updatechitiet(ChiTietHangHoa cthh)
        {
            _DBcontext.ChiTietHangHoas.Update(cthh);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
