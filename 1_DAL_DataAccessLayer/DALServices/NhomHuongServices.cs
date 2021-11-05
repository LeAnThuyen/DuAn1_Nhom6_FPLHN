﻿using _1_DAL_DataAccessLayer.Context;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class NhomHuongServices : IServicesNhomHuong
    {
        private DatabaseContext _DBcontext;
        private List<NhomHuong> _lstnhomhuong;
        public NhomHuongServices()
        {
            _DBcontext = new DatabaseContext();
            _lstnhomhuong = new List<NhomHuong>();
        }
        public bool addnhomhuong(NhomHuong nh)
        {
            _DBcontext.NhomHuongs.Add(nh);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletenhomhuong(NhomHuong nh)
        {
            _DBcontext.NhomHuongs.Remove(nh);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<NhomHuong> getlstvatchuafromDB()
        {
            _lstnhomhuong = _DBcontext.NhomHuongs.ToList();
            return _lstnhomhuong;
        }

        public bool updatenhomhuong(NhomHuong nh)
        {
            _DBcontext.NhomHuongs.Update(nh);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}