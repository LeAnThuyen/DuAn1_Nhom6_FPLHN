using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyAnh
    {
        bool addAnh(Anh anh);
        bool removeAnh(Anh anh);

        bool updateAnh(Anh anh);
        List<Anh> GetsList();
        void Save(Anh anh);


    }
}
