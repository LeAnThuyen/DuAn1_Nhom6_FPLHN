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
    public class DanhMucServices : IServicesDanhMuc
    {
        private DatabaseContext _DBcontext;
        private List<DanhMuc> _lstdanhmuc;
        public DanhMucServices()
        {
            _DBcontext = new DatabaseContext();
            _lstdanhmuc = new List<DanhMuc>();
        }
        public bool adddanhmuc(DanhMuc dm)
        {
            _DBcontext.DanhMucs.Add(dm);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletedanhmuc(DanhMuc dm)
        {
            _DBcontext.DanhMucs.Add(dm);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<DanhMuc> getlstdanhmucfromDB()
        {
           _lstdanhmuc=_DBcontext.DanhMucs.ToList();
            return _lstdanhmuc;
        }

        public bool updatedanhmuc(DanhMuc dm)
        {
            _DBcontext.DanhMucs.Update(dm);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
