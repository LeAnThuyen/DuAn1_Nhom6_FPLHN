using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;


namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyNSX
    {
        bool addNSX(NhaSanXuat nhaSanXuat);
        bool removeNSX(NhaSanXuat nhaSanXuat);
        bool updateNSX(NhaSanXuat nhaSanXuat);
        List<NhaSanXuat> GetsList();

        void Save(NhaSanXuat nhaSanXuat);
    }
}
