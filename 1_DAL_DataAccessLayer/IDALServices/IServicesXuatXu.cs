using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IServicesXuatXu
    {
        List<XuatXu> getlstxuatxufromDB();
        bool addxuatxu(XuatXu xx);
        bool deletexuatxu(XuatXu xx);
        bool updatexuatxu(XuatXu xx);
        bool save(XuatXu xx);
    }
}
