using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    [Table("ChatLieu")]
    public partial class ChatLieu
    {
        public ChatLieu()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }

        [Key]
        [Column("IDChatLieu")]
        public int IdchatLieu { get; set; }
        [StringLength(50)]
        public string MaChatLieu { get; set; }
        [StringLength(50)]
        public string TenChatLieu { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietHangHoa.IdchatLieuNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
