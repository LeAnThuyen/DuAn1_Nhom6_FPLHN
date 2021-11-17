using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("KhachHang")]
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDonBans = new HashSet<HoaDonBan>();
        }

        [Key]
        [Column("IDKhachHang")]
        public int IdkhachHang { get; set; }
        [StringLength(50)]
        public string MaKhachHang { get; set; }
        [StringLength(50)]
        public string TenKhachHang { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(100)]
        public string DiaChi { get; set; }
        [StringLength(50)]
        public string SoDienThoai { get; set; }
        public bool? TrangThai { get; set; }
        [Column("IDDiemTieuDung")]
        public int? IddiemTieuDung { get; set; }

        [ForeignKey(nameof(IddiemTieuDung))]
        [InverseProperty(nameof(DiemTieuDung.KhachHangs))]
        public virtual DiemTieuDung IddiemTieuDungNavigation { get; set; }
        [InverseProperty(nameof(HoaDonBan.IdkhachHangNavigation))]
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
