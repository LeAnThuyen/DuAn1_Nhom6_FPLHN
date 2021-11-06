using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesNhomHuong
    {

        List<NhomHuong> getlstnhomhuongfromDB();
        bool addnhomhuong(NhomHuong nh);
        bool deletenhomhuong(NhomHuong nh);
        bool updatenhomhuong(NhomHuong nh);
        bool save(NhomHuong nh);
    }
}
