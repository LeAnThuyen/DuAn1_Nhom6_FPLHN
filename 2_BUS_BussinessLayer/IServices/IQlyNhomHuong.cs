using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyNhomHuong
    {
        bool addNV(NhomHuong NhomHuong);
        bool removeNV(NhomHuong NhomHuong);
        bool updateNV(NhomHuong NhomHuong);
        List<NhomHuong> GetsList();

    }
}
