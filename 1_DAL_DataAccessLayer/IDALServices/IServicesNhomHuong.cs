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

        List<NhomHuong> getlstvatchuafromDB();
        bool addnhomhuong(NhomHuong nh);
        bool deletenhomhuong(NhomHuong nh);
        bool updatenhomhuong(NhomHuong nh);
    }
}
