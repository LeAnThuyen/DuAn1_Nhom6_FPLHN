using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.Services
{
    public class QLyDungTich : IQlyDungTich
    {
        private DungTichServices _dungTich;

        private List<DungTich> _lstdungTich;
        public QLyDungTich()
        {
            _dungTich = new DungTichServices();
            _lstdungTich = new List<DungTich>();
        }
        public bool addDT(DungTich dungTich)
        {
            _dungTich.adddungtich(dungTich);

            return true;
        }

        public List<DungTich> GetsList()
        {
            _lstdungTich = _dungTich.getlstdungtichfromDB();
            return _lstdungTich;

        }
        public bool removeDT(DungTich dungTich)
        {
            _dungTich.deletedungtich(dungTich);

            return true;
        }

        public void Save(DungTich dungTich)
        {
            _dungTich.save(dungTich);

            
        }

        public bool updateDT(DungTich dungTich)
        {
            _dungTich.updatedungtich(dungTich);
            return true;
        }
    }
}
