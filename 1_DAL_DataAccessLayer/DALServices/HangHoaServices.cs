
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
    public class HangHoaServices : IServicesHangHoa
    {

        private DatabaseContext _DBcontext;
        private List<HangHoa> _lsthanghoa;

        public HangHoaServices()
        {
            _DBcontext = new DatabaseContext();
            _lsthanghoa = new List<HangHoa>();
            getlsthanghoafromDB();
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
         
            return true;
        }

        public List<HangHoa> getlsthanghoafromDB()
        {
            _lsthanghoa = _DBcontext.HangHoas.AsNoTracking().ToList();
            return _lsthanghoa;
        }

        public bool save(HangHoa hh)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updatehanghoa(HangHoa hh)
        {
            _DBcontext.HangHoas.Update(hh);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
