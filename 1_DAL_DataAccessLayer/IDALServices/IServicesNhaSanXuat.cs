using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesNhaSanXuat
    {
        List<NhaSanXuat> getlstnxsfromDB();
        bool addnhasanxuat(NhaSanXuat nsx);
        bool deletenhasanxuat(NhaSanXuat nsx);
        bool updatenhasanxuat(NhaSanXuat nsx);
        bool save(NhaSanXuat xx);
    }
}
