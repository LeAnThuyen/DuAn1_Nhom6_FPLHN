using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            HangHoas = new HashSet<HangHoa>();
        }

        [Key]
        [Column("IDNhaSanXuat")]
        public int IdnhaSanXuat { get; set; }
        [StringLength(50)]
        public string MaNhaSanXuat { get; set; }
        [StringLength(50)]
        public string TenNhaSanXuat { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(HangHoa.IdnhaSanXuatNavigation))]
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
