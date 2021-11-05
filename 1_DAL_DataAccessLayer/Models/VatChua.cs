using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("VatChua")]
    public partial class VatChua
    {
        public VatChua()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }

        [Key]
        [Column("IDVatChua")]
        public int IdvatChua { get; set; }
        [StringLength(50)]
        public string MaVatChua { get; set; }
        [StringLength(50)]
        public string TenVatChua { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietHangHoa.IdvatChuaNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
