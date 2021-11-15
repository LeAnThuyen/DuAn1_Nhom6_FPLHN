using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyXuatXu
    {
        bool addXX(XuatXu xuatXu);
        bool removeXX(XuatXu xuatXu);
        bool updateXX(XuatXu xuatXu);
       List<XuatXu> GetsList();
        void Save(XuatXu xuatXu);
    }
}
