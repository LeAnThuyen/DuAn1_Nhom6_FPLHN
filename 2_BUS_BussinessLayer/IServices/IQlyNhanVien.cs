using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyNhanVien
    {
        bool addNV(NhanVien NhanVien);
        bool removeNV(NhanVien NhanVien);
        bool updateNV(NhanVien NhanVien);
        List<ViewNhanVien> GetsList();
        void Save(NhanVien NhanVien);
    }
}
