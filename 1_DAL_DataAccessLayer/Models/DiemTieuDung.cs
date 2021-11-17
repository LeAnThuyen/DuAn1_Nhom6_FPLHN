using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("DiemTieuDung")]
    public partial class DiemTieuDung
    {
        public DiemTieuDung()
        {
            KhachHangs = new HashSet<KhachHang>();
            LichSuTieuDungDiems = new HashSet<LichSuTieuDungDiem>();
        }

        [Key]
        [Column("IDDiemTieuDung")]
        public int IddiemTieuDung { get; set; }
        public double? SoDiem { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(KhachHang.IddiemTieuDungNavigation))]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        [InverseProperty(nameof(LichSuTieuDungDiem.IddiemTieuDungNavigation))]
        public virtual ICollection<LichSuTieuDungDiem> LichSuTieuDungDiems { get; set; }
    }
}
