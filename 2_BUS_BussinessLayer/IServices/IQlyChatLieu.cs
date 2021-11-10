using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQlyChatLieu
    {
        bool addNV(ChatLieu ChatLieu);
        bool removeNV(ChatLieu ChatLieu);
        bool updateNV(ChatLieu ChatLieu);
        List<ChatLieu> GetsList();
    }
}
