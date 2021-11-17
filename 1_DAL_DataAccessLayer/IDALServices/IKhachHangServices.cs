using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
  public interface IKhachHangServices
    {

        List<KhachHang> getlstkhachhangformDB();
        bool addkhachhang(KhachHang kh);
        bool updatekhachhang(KhachHang kh);
        bool deletekhachhang(KhachHang kh);
        bool savekhachhang(KhachHang kh);
    }
}
