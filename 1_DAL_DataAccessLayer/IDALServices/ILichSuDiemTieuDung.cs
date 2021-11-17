using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;

namespace _1_DAL_DataAccessLayer.IDALServices
{
    public interface ILichSuDiemTieuDung
    {
        List<LichSuTieuDungDiem> getlstDiemTieuDungfromDB();
        bool addLichSU(LichSuTieuDungDiem LichSuTieuDungDiem);
        bool deleteLichSu(LichSuTieuDungDiem LichSuTieuDungDiem);
        bool updateLichSU(LichSuTieuDungDiem LichSuTieuDungDiem);
        bool save(LichSuTieuDungDiem LichSuTieuDungDiem);
    }
}
