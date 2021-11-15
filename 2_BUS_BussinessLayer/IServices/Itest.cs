using _1_DAL_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.IServices
{
   public interface Itest
    {
        bool add(int id, string marole, string rolename, int trangthai);
    }
}
