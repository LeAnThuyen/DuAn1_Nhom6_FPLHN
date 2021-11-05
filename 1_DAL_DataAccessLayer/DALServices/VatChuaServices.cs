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
    public class VatChuaServices : IServicesVatChua
    {
        private DatabaseContext _DBcontext;
        private List<VatChua> _lsvatchua;
        public VatChuaServices()
        {
            _DBcontext = new DatabaseContext();
            _lsvatchua = new List<VatChua>();
        }

        public bool addvatchua(VatChua vt)
        {
            _DBcontext.VatChuas.Add(vt);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletevatchua(VatChua vt)
        {
            _DBcontext.VatChuas.Remove(vt);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<VatChua> getlstvatchuafromDB()
        {
            _lsvatchua = _DBcontext.VatChuas.ToList();
            return _lsvatchua;
        }

        public bool updatevatchua(VatChua vt)
        {
            _DBcontext.VatChuas.Update(vt);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}