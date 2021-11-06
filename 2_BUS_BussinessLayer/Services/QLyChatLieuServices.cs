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
    public class QlyChatLieuServices : IQlyChatLieu
    {
        
        private IServicesChatLieu _iServicesChatLieu;
        private List<ChatLieu> _lstChatLieus;
        private List<ViewChatLieu> _lstViewChatLieus;

        public QlyChatLieuServices()
        {
           
            _iServicesChatLieu = new ChatLieuServices();
        }
        public bool addCL(ChatLieu ChatLieu)
        {
            _lstChatLieus.Add(ChatLieu);
            _iServicesChatLieu.addchatlieu(ChatLieu);
            return true;
        }

       /* public List<ViewChatLieu> GetsList()
        {
            _lstViewChatLieus = (from a in _iServicesNhanVien.getlstnhanvienfromDB()
                    join b in _iRolesServices.getListRole() on a.Idrole equals b.Idrole
                    select new ViewNhanVien()
                    {
                        NhanVien = a,
                        Role = b
                    }
                ).ToList();
            return _lstViewNhanViens;
        }*/

        public bool removeNV(ChatLieu ChatLieu)
        {
            _lstChatLieus.Remove(ChatLieu);
            _iServicesChatLieu.deletechatlieu(ChatLieu);
            return true;
        }

        public void Save(ChatLieu ChatLieu)
        {
            _iServicesChatLieu.save(ChatLieu);
        }

        public bool updateNV(ChatLieu ChatLieu)
        {
            _iServicesChatLieu.updatenchatlieu(ChatLieu);
            return true;
        }
    }
}
