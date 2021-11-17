using _1_DAL_DataAccessLayer.Context;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Context;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;

namespace _1_DAL_DataAccessLayer.DALServices
{
    {
        private DatabaseContext _DBcontext;
        public DiemTieuDungServices()
        {
            _DBcontext = new DatabaseContext();
        }
        {
            _DBcontext.SaveChanges();
            return true;
        }

        {
            _DBcontext.SaveChanges();
            return true;
        }

        {
        }

        {
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
