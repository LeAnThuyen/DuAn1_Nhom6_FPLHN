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
        [Key]
        [Column("IDDiemTieuDung")]
        public int IddiemTieuDung { get; set; }
        public double? SoDiem { get; set; }
        public int? TrangThai { get; set; }
        [Column("IDLichSuDiem")]
        public int? IdlichSuDiem { get; set; }

        [ForeignKey(nameof(IdlichSuDiem))]
        [InverseProperty(nameof(LichSuTieuDungDiem.DiemTieuDungs))]
        public virtual LichSuTieuDungDiem IdlichSuDiemNavigation { get; set; }
        [InverseProperty(nameof(KhachHang.IddiemTieuDungNavigation))]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

    }




}

