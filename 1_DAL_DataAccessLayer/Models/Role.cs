using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    public partial class Role
    {
        public Role()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        [Column("IDRole")]
        public int Idrole { get; set; }
        [StringLength(50)]
        public string MaRole { get; set; }
        [StringLength(50)]
        public string RoleName { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(NhanVien.IdroleNavigation))]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
