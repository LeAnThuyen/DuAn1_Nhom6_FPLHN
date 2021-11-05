using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("Anh")]
    public partial class Anh
    {
        public Anh()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }

        [Key]
        [Column("IDAnh")]
        public int Idanh { get; set; }
        [StringLength(50)]
        public string MaAnh { get; set; }
        [StringLength(50)]
        public string TenAnh { get; set; }
        [Required]
        [StringLength(100)]
        public string DuongDan { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietHangHoa.IdanhNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
