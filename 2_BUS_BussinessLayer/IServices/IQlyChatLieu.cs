using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.ModelViews;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQLyChatLieu
    {
        bool addCL(ChatLieu ChatLieu);
        bool removeCL(NhanVien ChatLieu);
        bool updateCL(NhanVien ChatLieu);
        List<ViewChatLieu> GetsList();
        void Save(ChatLieu ChatLieu);
    }
}
