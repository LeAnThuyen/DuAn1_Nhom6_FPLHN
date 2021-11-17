
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class NhaSanXuatServices : IServicesNhaSanXuat
    {
        private DatabaseContext _DBcontext;
        private List<NhaSanXuat> _lstnsx;
        public NhaSanXuatServices()
        {
            _DBcontext = new DatabaseContext();
            _lstnsx = new List<NhaSanXuat>();
            getlstnxsfromDB();
        }
        public bool addnhasanxuat(NhaSanXuat nsx)
        {
            _DBcontext.NhaSanXuats.Add(nsx);
        
            return true;
        }

        public bool deletenhasanxuat(NhaSanXuat nsx)
        {
            _DBcontext.NhaSanXuats.Remove(nsx);
         
            return true;
        }

        public List<NhaSanXuat> getlstnxsfromDB()
        {
            _lstnsx = _DBcontext.NhaSanXuats.ToList();
            return _lstnsx;
        }

        public bool save(NhaSanXuat xx)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updatenhasanxuat(NhaSanXuat nsx)
        {
            _DBcontext.NhaSanXuats.Update(nsx);
          
            return true;
        }
    }
}
