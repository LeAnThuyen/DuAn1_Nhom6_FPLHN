
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
            getlstnhomhuongfromDB();
        }
        public bool addnhomhuong(NhomHuong nh)
        {
            _DBcontext.NhomHuongs.Add(nh);
          
            return true;
        }

        public bool deletenhomhuong(NhomHuong nh)
        {
            _DBcontext.NhomHuongs.Remove(nh);
           
            return true;
        }

        public List<NhomHuong> getlstnhomhuongfromDB()
        {
            _lstnhomhuong = _DBcontext.NhomHuongs.ToList();
            return _lstnhomhuong;
        }

        public bool save(NhomHuong nh)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updatenhomhuong(NhomHuong nh)
        {
            _DBcontext.NhomHuongs.Update(nh);
        
            return true;
        }
    }
}
