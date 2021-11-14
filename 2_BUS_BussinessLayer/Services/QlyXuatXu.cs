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

    public class QlyXuatXu : IQlyXuatXu
    {
        private XuatXuService _xx;
        
        private List<XuatXu> _lstxuatXu;
        public QlyXuatXu()
        {
            _xx = new XuatXuService();
      
            _lstxuatXu = new List<XuatXu>();

        
            
           // GetsList();
        }
        public bool addXX(XuatXu xuatXu)
        {
            _xx.addxuatxu(xuatXu);
            
            return true;
        }

        public List<XuatXu> GetsList()
        {
            _lstxuatXu= _xx.getlstxuatxufromDB();
            return _lstxuatXu;

        }

        public bool removeXX(XuatXu xuatXu)
        {
            _xx.deletexuatxu(xuatXu);

            return true;
        }

        public void Save(XuatXu xuatXu)
        {
            _xx.save(xuatXu);

            
        }

        public bool updateXX(XuatXu xuatXu)
        {
            _xx.updatexuatxu(xuatXu);
            return true;
        }
    }
}
