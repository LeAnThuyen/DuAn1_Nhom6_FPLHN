using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("XuatXu")]
    public partial class XuatXu
    {
        public XuatXu()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }

        [Key]
        [Column("IDQuocGia")]
        public int IdquocGia { get; set; }
        [StringLength(50)]
        public string MaQuocGia { get; set; }
        [StringLength(50)]
        public string TenQuocGia { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietHangHoa.IdquocGiaNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
