using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.IServices
{
   public interface Itest
    {
        List<Temperature> Getlistviewdoanhthutheongay();
    }
}
