using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.IServices
{
    public interface ISendPoint
    {
        public string SendMail(string email, double point,double pointUse, double pointOld);
        public string SendMail2(string email, double point, double pointOld);
    }
}
