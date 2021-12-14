using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS_BussinessLayer.Services
{
    public class ChangeServices : IServicesChangePass
    {
        private IServicesNhanVien _iServicesNhanVien;
        private List<NhanVien> _lstNhanVien;

        public ChangeServices()
        {
            _iServicesNhanVien = new NhanVienServices();
            _lstNhanVien = new List<NhanVien>();
            getlstnhanvienfromDB();
        }

        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public List<NhanVien> getlstnhanvienfromDB()
        {
            _lstNhanVien = _iServicesNhanVien.getlstnhanvienfromDB();
            return _lstNhanVien;
        }

        public bool uppdateppassnv(NhanVien pass)
        {
            _iServicesNhanVien.updatenhanvien(pass);

            return true;

        }
    }
}
