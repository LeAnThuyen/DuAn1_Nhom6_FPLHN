using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{

    [Table("ChiTietHangHoa")]
    public partial class ChiTietHangHoa
    {
        public ChiTietHangHoa()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        [Key]
        [Column("IDThongTinHangHoa")]
        public int IdthongTinHangHoa { get; set; }
        [StringLength(50)]
        public string SoLuong { get; set; }
        [StringLength(50)]
        public string Mavach { get; set; }
        public double? DonGiaNhap { get; set; }
        public double? DonGiaBan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HanSuDung { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayNhapKho { get; set; }
        public int? TrangThai { get; set; }
        [Column("IDChatLieu")]
        public int? IdchatLieu { get; set; }
        [Column("IDNhomHuong")]
        public int? IdnhomHuong { get; set; }
        [Column("IDHangHoa")]
        public int? IdhangHoa { get; set; }
        [Column("IDQuocGia")]
        public int? IdquocGia { get; set; }
        [Column("IDDungTich")]
        public int? IddungTich { get; set; }
        [Column("IDAnh")]
        public int? Idanh { get; set; }
        [Column("IDVatChua")]
        public int? IdvatChua { get; set; }

        [ForeignKey(nameof(Idanh))]
        [InverseProperty(nameof(Anh.ChiTietHangHoas))]
        public virtual Anh IdanhNavigation { get; set; }
        [ForeignKey(nameof(IdchatLieu))]
        [InverseProperty(nameof(ChatLieu.ChiTietHangHoas))]
        public virtual ChatLieu IdchatLieuNavigation { get; set; }
        [ForeignKey(nameof(IddungTich))]
        [InverseProperty(nameof(DungTich.ChiTietHangHoas))]
        public virtual DungTich IddungTichNavigation { get; set; }
        [ForeignKey(nameof(IdhangHoa))]
        [InverseProperty(nameof(HangHoa.ChiTietHangHoas))]
        public virtual HangHoa IdhangHoaNavigation { get; set; }
        [ForeignKey(nameof(IdnhomHuong))]
        [InverseProperty(nameof(NhomHuong.ChiTietHangHoas))]
        public virtual NhomHuong IdnhomHuongNavigation { get; set; }
        [ForeignKey(nameof(IdquocGia))]
        [InverseProperty(nameof(XuatXu.ChiTietHangHoas))]
        public virtual XuatXu IdquocGiaNavigation { get; set; }
        [ForeignKey(nameof(IdvatChua))]
        [InverseProperty(nameof(VatChua.ChiTietHangHoas))]
        public virtual VatChua IdvatChuaNavigation { get; set; }
        [InverseProperty(nameof(HoaDonChiTiet.IdthongTinHangHoaNavigation))]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
