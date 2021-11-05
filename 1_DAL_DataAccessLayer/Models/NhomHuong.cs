using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("NhomHuong")]
    public partial class NhomHuong
    {
        public NhomHuong()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }

        [Key]
        [Column("IDNhomHuong")]
        public int IdnhomHuong { get; set; }
        [StringLength(50)]
        public string MaNhomHuong { get; set; }
        [StringLength(50)]
        public string TenNhomHuong { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietHangHoa.IdnhomHuongNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
