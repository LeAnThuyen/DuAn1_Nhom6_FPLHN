using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _2_BUS_BussinessLayer.IServices;

namespace _2_BUS_BussinessLayer.Services
{
    public class QuenMatKhauServices : IQuenMatKhau
    {
        private IServicesNhanVien _iServicesNhanVien;
        public QuenMatKhauServices()
        {
            _iServicesNhanVien = new NhanVienServices();
        }
        public string encryption(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(pass));
            StringBuilder encryptData = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptData.Append(encrypt[i].ToString());
            }

            return encryptData.ToString();
        }

        public int RamdomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder _builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                _builder.Append(ch);
            }

            if (lowerCase)
                return _builder.ToString().ToLower();

            return _builder.ToString();
        }

        public string SendMail(string email, string pass)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("Clone9291@gmail.com");
                mail.Subject = "Bạn đã sử dụng chức năng quên mật khẩu";

                mail.Body = "Chào anh/chị. Mật khẩu mới truy cạp phần mềm là " + pass;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("Clone9291@gmail.com", "PlaywithDevil9291@"); // ***use valid credentials***
                smtp.Port = 587;


                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Send(mail);
                return "Một Email phục hồi mật khẩu đã được gửi tới bạn";
            }
            catch (Exception e)
            {
                return (e.Message);
            }
        }

        public void Update(string email, string pass)
        {
            var acc = _iServicesNhanVien.getlstnhanvienfromDB().FirstOrDefault(x => x.Email == email);
            acc.Email = email;
            acc.PassWord = pass;
            _iServicesNhanVien.updatenhanvien(acc);
            _iServicesNhanVien.save(acc);
        }
    }
}
