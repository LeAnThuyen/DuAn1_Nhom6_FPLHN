using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using _2_BUS_BussinessLayer.IServices;

namespace _2_BUS_BussinessLayer.Services
{
    public class SendPointServices : ISendPoint
    {
        public string SendMail(string email, double point, double pointUse, double pointOld)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("Clone9291@gmail.com");
                mail.Subject = "Bạn đã sử dụng chức năng quên mật khẩu";

                mail.Body = "Chào anh/chị. Số điểm thưởng quý khách vừa được cộng thêm là : " + point +"\n"
                            + "Quý khách vừa sử dụng: " +pointUse +" "+ "điểm" 
                            + "Tổng số điểm thưởng hiện tại của quý khách là: " +Convert.ToInt32(pointOld) ;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("Clone9291@gmail.com", "PlaywithDevil9291@"); // ***use valid credentials***
                smtp.Port = 587;


                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Send(mail);
                return "Gửi Email tới khách hàng thành công";
            }
            catch (Exception e)
            {
                return (e.Message);
            }
        }

        public string SendMail2(string email, double point, double pointOld)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("Clone9291@gmail.com");
                mail.Subject = "Bạn đã sử dụng chức năng quên mật khẩu";

                mail.Body = "Chào anh/chị. Số điểm thưởng quý khách vừa được cộng thêm là : " + point + "\n"
                            + "Tổng số điểm thưởng hiện tại của quý khách là: " +  pointOld;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("Clone9291@gmail.com", "PlaywithDevil9291@"); // ***use valid credentials***
                smtp.Port = 587;


                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Send(mail);
                return "Gửi Email tới khách hàng thành công";
            }
            catch (Exception e)
            {
                return (e.Message);
            }
        }
    }
}
