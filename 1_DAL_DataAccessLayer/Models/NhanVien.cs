using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{

    [Table("NhanVien")]
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDonBans = new HashSet<HoaDonBan>();
        }

        [Key]
        [Column("IDUser")]
        public int Iduser { get; set; }
        [StringLength(50)]
        public string MaNhanVien { get; set; }
        [StringLength(50)]
        public string TenNhanVien { get; set; }
        public int? GioiTinh { get; set; }
        public int? NamSinh { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string PassWord { get; set; }
        [StringLength(100)]
        public string QueQuan { get; set; }
        [Column("SoCMND")]
        [StringLength(50)]
        public string SoCmnd { get; set; }
        [StringLength(50)]
        public string DienThoai { get; set; }
        public bool? TrangThai { get; set; }
        [StringLength(100)]
        public string Anh { get; set; }
        [Column("IDRole")]
        public int? Idrole { get; set; }
        public bool? Flag { get; set; }

        [ForeignKey(nameof(Idrole))]
        [InverseProperty(nameof(Role.NhanViens))]
        public virtual Role IdroleNavigation { get; set; }
        [InverseProperty(nameof(HoaDonBan.IduserNavigation))]
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
