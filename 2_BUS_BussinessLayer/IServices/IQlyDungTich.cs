using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyDungTich
    {
        bool addDT(DungTich dungTich);
        bool removeDT(DungTich dungTich);
        bool updateDT(DungTich dungTich);
        List<DungTich> GetsList();
        void Save(DungTich dungTich);
    }
}
