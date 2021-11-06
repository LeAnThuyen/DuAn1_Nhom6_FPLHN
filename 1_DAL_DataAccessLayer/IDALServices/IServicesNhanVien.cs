using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
  public interface IServicesNhanVien
    {
        List<NhanVien> getlstnhanvienfromDB();
        bool addnhanvien(NhanVien nv);
        bool deletenhanvien(NhanVien nv);
        bool updatenhanvien(NhanVien nv);
        bool save(NhanVien nv);
    }
}
