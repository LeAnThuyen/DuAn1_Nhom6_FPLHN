using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            HangHoas = new HashSet<HangHoa>();
        }

        [Key]
        [Column("IDDanhMuc")]
        public int IddanhMuc { get; set; }
        [StringLength(50)]
        public string MaDanhMuc { get; set; }
        [StringLength(50)]
        public string TenDanhMuc { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(HangHoa.IddanhMucNavigation))]
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
