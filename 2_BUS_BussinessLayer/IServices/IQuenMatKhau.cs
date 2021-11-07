using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface IQuenMatKhau
    {
        string RandomString(int size, bool lowerCase);
        int RamdomNumber(int min, int max);
        void Update(string email, string pass);
        string encryption(string pass);
        string SendMail(string email, string pass);
    }
}
