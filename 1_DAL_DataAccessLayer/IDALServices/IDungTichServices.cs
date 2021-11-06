using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.IDALServices
{
   public interface IDungTichServices
    {
        List<DungTich> getlstdungtichfromDB();
        bool adddungtich(DungTich dt);
        bool deletedungtich(DungTich dt);
        bool updatedungtich(DungTich dt);
        bool save(DungTich dt);
    }
}
