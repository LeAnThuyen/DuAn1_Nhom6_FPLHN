using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyDanhMuc
    {
        bool addNV(DanhMuc DanhMuc);
        bool removeNV(DanhMuc DanhMuc);
        bool updateNV(DanhMuc DanhMuc);
        List<DanhMuc> GetsList();
    }
}
