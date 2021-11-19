using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("HoaDonChiTiet")]
    public partial class HoaDonChiTiet
    {
        [Key]
        [Column("IDHoaDonChiTiet")]
        public int IdhoaDonChiTiet { get; set; }
        [StringLength(50)]
        public string MaHoaDonChiTiet { get; set; }
        public double? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public double? GiamGia { get; set; }
        public double? ThanhTien { get; set; }
        [Column("IDHoaDon")]
        public int? IdhoaDon { get; set; }
        public int? TrangThai { get; set; }
        [Column("IDThongTinHangHoa")]
        public int? IdthongTinHangHoa { get; set; }
        [StringLength(100)]
        public string GhiChu { get; set; }

        [ForeignKey(nameof(IdhoaDon))]
        [InverseProperty(nameof(HoaDonBan.HoaDonChiTiets))]
        public virtual HoaDonBan IdhoaDonNavigation { get; set; }
        [ForeignKey(nameof(IdthongTinHangHoa))]
        [InverseProperty(nameof(ChiTietHangHoa.HoaDonChiTiets))]
        public virtual ChiTietHangHoa IdthongTinHangHoaNavigation { get; set; }
    }
}
