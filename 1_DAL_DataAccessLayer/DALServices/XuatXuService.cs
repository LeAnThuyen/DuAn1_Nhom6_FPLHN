
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class XuatXuService : IServicesXuatXu
    {
        private DatabaseContext _DBcontext;
        private List<XuatXu> _lstxuatxu;
        public XuatXuService()
        {
            _DBcontext = new DatabaseContext();
            _lstxuatxu = new List<XuatXu>();
            getlstxuatxufromDB();
        }
        public bool addxuatxu(XuatXu xx)
        {
            _DBcontext.XuatXus.Add(xx);
           
            return true;
        }

        public bool deletexuatxu(XuatXu xx)
        {
            _DBcontext.XuatXus.Remove(xx);
       
            return true;
        }
            public List<XuatXu> getlstxuatxufromDB()
        {
            _lstxuatxu = _DBcontext.XuatXus.ToList();
            return _lstxuatxu;
        }

        public bool save(XuatXu xx)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updatexuatxu(XuatXu xx)
        {
                _DBcontext.XuatXus.Update(xx);
              
                return true;
            }
    }
}
