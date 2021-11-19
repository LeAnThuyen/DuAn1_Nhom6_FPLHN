using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("HoaDonBan")]
    public partial class HoaDonBan
    {
        public HoaDonBan()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
            LichSuTieuDungDiems = new HashSet<LichSuTieuDungDiem>();
        }

        [Key]
        [Column("IDHoaDon")]
        public int IdhoaDon { get; set; }
        [StringLength(50)]
        public string MaHoaDon { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayLap { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayNhanHang { get; set; }
        public double? Tien { get; set; }
        public double? Thue { get; set; }
        public double? TongSoTien { get; set; }
        [Column("IDKhachHang")]
        public int? IdkhachHang { get; set; }
        [Column("IDUser")]
        public int? Iduser { get; set; }
        public int? TrangThai { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayShipHang { get; set; }
        public double? TienCoc { get; set; }
        [StringLength(100)]
        public string GhiChu { get; set; }

        [ForeignKey(nameof(IdkhachHang))]
        [InverseProperty(nameof(KhachHang.HoaDonBans))]
        public virtual KhachHang IdkhachHangNavigation { get; set; }
        [ForeignKey(nameof(Iduser))]
        [InverseProperty(nameof(NhanVien.HoaDonBans))]
        public virtual NhanVien IduserNavigation { get; set; }
        [InverseProperty(nameof(HoaDonChiTiet.IdhoaDonNavigation))]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        [InverseProperty(nameof(LichSuTieuDungDiem.IdhoaDonNavigation))]
        public virtual ICollection<LichSuTieuDungDiem> LichSuTieuDungDiems { get; set; }
    }

}
