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
    public class HangHoaServices : IServicesHangHoa
    {

        private DatabaseContext _DBcontext;
        private List<HangHoa> _lsthanghoa;

        public HangHoaServices()
        {
            _DBcontext = new DatabaseContext();
            _lsthanghoa = new List<HangHoa>();
        }
        public bool addhanghoa(HangHoa hh)
        {
            _DBcontext.HangHoas.Add(hh);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletehanghoa(HangHoa hh)
        {
            _DBcontext.HangHoas.Remove(hh);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<HangHoa> getlsthanghoafromDB()
        {
            _lsthanghoa = _DBcontext.HangHoas.ToList();
            return _lsthanghoa;
        }

        public bool updatehanghoa(HangHoa hh)
        {
            _DBcontext.HangHoas.Remove(hh);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}