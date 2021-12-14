
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL_DataAccessLayer.DALServices
{
    public class ChatLieuServie : IChatLieuServices
    {
        private DatabaseContext _DBcontext;
        private List<ChatLieu> _lstchatlieu;
        public ChatLieuServie()
        {
            _DBcontext = new DatabaseContext();
            _lstchatlieu = new List<ChatLieu>();
            getlstchatlieufromDB();
        }
        public List<ChatLieu> getlstchatlieufromDB()
        {
            _lstchatlieu = _DBcontext.ChatLieus.AsNoTracking().ToList();
            return _lstchatlieu;
        }
        public bool addchatlieu(ChatLieu cl)
        {
            _DBcontext.ChatLieus.Add(cl);
        
            return true;
        }

        public bool deletechatlieu(ChatLieu cl)
        {
            _DBcontext.ChatLieus.Remove(cl);
            
            return true;
        }

       

        public bool save(ChatLieu cl)
        {
            _DBcontext.SaveChanges();
            return true;
        }

        public bool updatechatlieu(ChatLieu cl)
        {

            _DBcontext.ChatLieus.Remove(cl);
        
            return true;
        }
    }
}
