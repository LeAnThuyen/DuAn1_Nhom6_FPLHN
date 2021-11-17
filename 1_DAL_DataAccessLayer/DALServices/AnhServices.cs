
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class AnhServices : IServicesAnh
    {

        private DatabaseContext _DBcontext;
        private List<Anh> _lstanh;
        public AnhServices()
        {
            _DBcontext = new DatabaseContext();
            _lstanh = new List<Anh>();
            getlstanhfromDB();
        }
        public bool addanh(Anh img)
        {
            _DBcontext.Anhs.Add(img);
           
            return true;
        }

        public bool deleteanh(Anh img)
        {
            _DBcontext.Anhs.Remove(img);
         
            return true;
        }

        public List<Anh> getlstanhfromDB()
        {
            _lstanh = _DBcontext.Anhs.ToList();
            return _lstanh;
        }

        public bool save(Anh img)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updateanh(Anh img)
        {
            _DBcontext.Anhs.Update(img);
          
            return true;
        }
    }
}
