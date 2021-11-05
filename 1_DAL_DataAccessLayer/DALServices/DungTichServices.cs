using _1_DAL_DataAccessLayer.Context;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class DungTichServices : IDungTichServices
    {
        private DatabaseContext _DBcontext;
        private List<DungTich> _lstdungtich;
        public DungTichServices()
        {
            _DBcontext = new DatabaseContext();
            _lstdungtich = new List<DungTich>();
            
        }
        public bool adddungtich(DungTich dt)
        {
            _DBcontext.DungTiches.Add(dt);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deletedungtich(DungTich dt)
        {
            _DBcontext.DungTiches.Remove(dt);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<DungTich> getlstdungtichfromDB()
        {
            _lstdungtich = _DBcontext.DungTiches.ToList();
            return _lstdungtich;
        }

        public bool updatedungtich(DungTich dt)
        {
            _DBcontext.DungTiches.Update(dt);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
