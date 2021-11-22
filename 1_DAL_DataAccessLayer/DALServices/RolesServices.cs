using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class RolesServices : IRolesServices
    {
        private DatabaseContext _DBcontext;
        private List<Role> _lstRoles;

        public RolesServices()
        {
            _DBcontext = new DatabaseContext();
            _lstRoles = new List<Role>();
        }
        public List<Role> getListRole()
        {
            _lstRoles = _DBcontext.Roles.ToList();
            return _lstRoles;
        }
    }
}
