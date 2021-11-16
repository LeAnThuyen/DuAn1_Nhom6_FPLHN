using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
  public interface INhanVienServices
    {
        List<NhanVien> getlstnhanvien();
        bool addnhanvien(NhanVien nv);
        bool updatenhanvien(NhanVien nv);
        bool deletenhanvien(NhanVien nv);
        bool savenhanvien(NhanVien nv);
        
    }
}
