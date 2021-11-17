using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("LichSuTieuDungDiem")]
    public partial class LichSuTieuDungDiem
    {
        [Key]
        [Column("IDLichSuDiem")]
        public int IdlichSuDiem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySuDung { get; set; }
        public double? SoDiemTieu { get; set; }
        public int? TrangThai { get; set; }
        [Column("IDHoaDon")]
        public int? IdhoaDon { get; set; }
        [Column("IDDiemTieuDung")]
        public int? IddiemTieuDung { get; set; }

        [ForeignKey(nameof(IddiemTieuDung))]
        [InverseProperty(nameof(DiemTieuDung.LichSuTieuDungDiems))]
        public virtual DiemTieuDung IddiemTieuDungNavigation { get; set; }
        [ForeignKey(nameof(IdhoaDon))]
        [InverseProperty(nameof(HoaDonBan.LichSuTieuDungDiems))]
        public virtual HoaDonBan IdhoaDonNavigation { get; set; }
    }
}
