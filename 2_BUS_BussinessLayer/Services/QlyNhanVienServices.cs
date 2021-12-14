using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.Services
{
    public class QlyNhanVienServices : IQlyNhanVien
    {
        private IRolesServices _iRolesServices;
        private IServicesNhanVien _iServicesNhanVien;
        private List<NhanVien> _lstNhanViens;
        private List<ViewNhanVien> _lstViewNhanViens;

        public QlyNhanVienServices()
        {
            _iRolesServices = new RolesServices();
            _iServicesNhanVien = new NhanVienServices();
        }
        public bool addNV(NhanVien NhanVien)
        {
            _lstNhanViens.Add(NhanVien);
            _iServicesNhanVien.addnhanvien(NhanVien);
            return true;
        }

        public List<ViewNhanVien> GetsList()
        {
            _lstViewNhanViens = (from a in _iServicesNhanVien.getlstnhanvienfromDB()
                    join b in _iRolesServices.getListRole() on a.Idrole equals b.Idrole
                    select new ViewNhanVien()
                    {
                        NhanVien = a,
                        Role = b
                    }
                ).ToList();
            return _lstViewNhanViens;
        }

        public bool removeNV(NhanVien NhanVien)
        {
           // _lstNhanViens.Remove(NhanVien);
            _iServicesNhanVien.deletenhanvien(NhanVien);
            return true;
        }

        public void Save(NhanVien NhanVien)
        {
            _iServicesNhanVien.save(NhanVien);
        }

        public bool updateNV(NhanVien NhanVien)
        {
            _iServicesNhanVien.updatenhanvien(NhanVien);
            return true;
        }
    }
}
