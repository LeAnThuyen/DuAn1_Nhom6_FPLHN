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
    public class HoaDonChiTietServices : IServicesHoaDonChiTiet
    {
        private DatabaseContext _DBcontext;
        private List<HoaDonChiTiet> _lsthoadonchitiet;
        public HoaDonChiTietServices()
        {
            _DBcontext = new DatabaseContext();
            _lsthoadonchitiet = new List<HoaDonChiTiet>();
        }
        public bool addhdct(HoaDonChiTiet hdct)
        {
            _DBcontext.HoaDonChiTiets.Add(hdct);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletehdct(HoaDonChiTiet hdct)
        {
            _DBcontext.HoaDonChiTiets.Remove(hdct);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<HoaDonChiTiet> getlsthdctfromDB()
        {
            _lsthoadonchitiet = _DBcontext.HoaDonChiTiets.AsNoTracking().ToList();
            return _lsthoadonchitiet;
        }

        public bool updatehdct(HoaDonChiTiet hdct)
        {
            _DBcontext.HoaDonChiTiets.Update(hdct);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}