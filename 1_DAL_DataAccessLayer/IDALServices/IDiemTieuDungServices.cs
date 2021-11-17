using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL_DataAccessLayer.Models;

namespace _1_DAL_DataAccessLayer.IDALServices
{
    public interface IDiemTieuDungServices
    {
        List<DiemTieuDung> getlstDiemTieuDungfromDB();
        bool addDiemTieuDung(DiemTieuDung DiemTieuDung);
        bool deleteDiemTieuDungu(DiemTieuDung DiemTieuDung);
        bool updateDiemTieuDung(DiemTieuDung DiemTieuDung);
        bool save(DiemTieuDung DiemTieuDung);
    }
}
