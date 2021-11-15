using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.Services
{
    public class TestServices : Itest
    {
        private VatChuaServices vtser;
        public TestServices()
        {
            vtser = new VatChuaServices();
        }
        public bool add(int id, string marole, string rolename, int trangthai)
        {
            vtser.addvatchua(new VatChua() { 
            IdvatChua=id,
            MaVatChua=marole,
            TenVatChua=rolename,
            TrangThai=trangthai
            
            });
            return true;
        }
    }
}
