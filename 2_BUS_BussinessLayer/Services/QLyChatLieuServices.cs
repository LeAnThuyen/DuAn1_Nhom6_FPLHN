using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;

namespace _2_BUS_BussinessLayer.Services
{
    public class QLyChatLieuServices : IQlyChatLieu
    {
        private IChatLieuServices _iChatLieuServices;

        public QLyChatLieuServices()
        {
            _iChatLieuServices = new ChatLieuServie();
            GetsList();
        }
        public bool addNV(ChatLieu ChatLieu)
        {
            _iChatLieuServices.addchatlieu(ChatLieu);
            _iChatLieuServices.save(ChatLieu);
            return true;
        }

        public List<ChatLieu> GetsList()
        {
            return _iChatLieuServices.getlstchatlieufromDB();
        }

        public bool removeNV(ChatLieu ChatLieu)
        {
            _iChatLieuServices.deletechatlieu(ChatLieu);
            _iChatLieuServices.save(ChatLieu);
            return true;
        }

        public bool updateNV(ChatLieu ChatLieu)
        {
            _iChatLieuServices.updatechatlieu(ChatLieu);
            _iChatLieuServices.save(ChatLieu);
            return true;
        }
    }
}
