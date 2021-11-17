using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("HangHoa")]
    public partial class HangHoa
    {
        public HangHoa()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }

        [Key]
        [Column("IDHangHoa")]
        public int IdhangHoa { get; set; }
        [StringLength(50)]
        public string TenHangHoa { get; set; }
        [StringLength(50)]
        public string MaHangHoa { get; set; }
        [Column("IDNhaSanXuat")]
        public int? IdnhaSanXuat { get; set; }
        public int? TrangThai { get; set; }
        [Column("IDDanhMuc")]
        public int? IddanhMuc { get; set; }

        [ForeignKey(nameof(IddanhMuc))]
        [InverseProperty(nameof(DanhMuc.HangHoas))]
        public virtual DanhMuc IddanhMucNavigation { get; set; }
        [ForeignKey(nameof(IdnhaSanXuat))]
        [InverseProperty(nameof(NhaSanXuat.HangHoas))]
        public virtual NhaSanXuat IdnhaSanXuatNavigation { get; set; }
        [InverseProperty(nameof(ChiTietHangHoa.IdhangHoaNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
