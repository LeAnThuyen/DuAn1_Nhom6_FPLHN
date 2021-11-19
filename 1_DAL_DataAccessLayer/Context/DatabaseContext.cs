using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _1_DAL_DataAccessLayer.Models;

#nullable disable

namespace _1_DAL_DataAccessLayer.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
         
        public virtual DbSet<Anh> Anhs { get; set; }
        public virtual DbSet<ChatLieu> ChatLieus { get; set; }
        public virtual DbSet<ChiTietHangHoa> ChiTietHangHoas { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DiemTieuDung> DiemTieuDungs { get; set; }
        public virtual DbSet<DungTich> DungTiches { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichSuTieuDungDiem> LichSuTieuDungDiems { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomHuong> NhomHuongs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<VatChua> VatChuas { get; set; }
        public virtual DbSet<XuatXu> XuatXus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=TANA\\SQLEXPRESS;Initial Catalog=dcmmm;Persist Security Info=True;User ID=thuyen;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anh>(entity =>
            {
                entity.Property(e => e.Idanh).ValueGeneratedNever();
            });

            modelBuilder.Entity<ChatLieu>(entity =>
            {
                entity.Property(e => e.IdchatLieu).ValueGeneratedNever();
            });

            modelBuilder.Entity<ChiTietHangHoa>(entity =>
            {
                entity.Property(e => e.IdthongTinHangHoa).ValueGeneratedNever();

                entity.HasOne(d => d.IdanhNavigation)
                    .WithMany(p => p.ChiTietHangHoas)
                    .HasForeignKey(d => d.Idanh)
                    .HasConstraintName("FK_ChiTietHangHoa_Anh");

                entity.HasOne(d => d.IdchatLieuNavigation)
                    .WithMany(p => p.ChiTietHangHoas)
                    .HasForeignKey(d => d.IdchatLieu)
                    .HasConstraintName("FK_ChiTietHangHoa_ChatLieu");

                entity.HasOne(d => d.IddungTichNavigation)
                    .WithMany(p => p.ChiTietHangHoas)
                    .HasForeignKey(d => d.IddungTich)
                    .HasConstraintName("FK_ChiTietHangHoa_DungTich");

                entity.HasOne(d => d.IdhangHoaNavigation)
                    .WithMany(p => p.ChiTietHangHoas)
                    .HasForeignKey(d => d.IdhangHoa)
                    .HasConstraintName("FK_ChiTietHangHoa_HangHoa");

                entity.HasOne(d => d.IdnhomHuongNavigation)
                    .WithMany(p => p.ChiTietHangHoas)
                    .HasForeignKey(d => d.IdnhomHuong)
                    .HasConstraintName("FK_ChiTietHangHoa_NhomHuong");

                entity.HasOne(d => d.IdquocGiaNavigation)
                    .WithMany(p => p.ChiTietHangHoas)
                    .HasForeignKey(d => d.IdquocGia)
                    .HasConstraintName("FK_ChiTietHangHoa_XuatXu");

                entity.HasOne(d => d.IdvatChuaNavigation)
                    .WithMany(p => p.ChiTietHangHoas)
                    .HasForeignKey(d => d.IdvatChua)
                    .HasConstraintName("FK_ChiTietHangHoa_VatChua");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.Property(e => e.IddanhMuc).ValueGeneratedNever();
            });

            modelBuilder.Entity<DiemTieuDung>(entity =>
            {
                entity.Property(e => e.IddiemTieuDung).ValueGeneratedNever();
            });

            modelBuilder.Entity<DungTich>(entity =>
            {
                entity.Property(e => e.IddungTich).ValueGeneratedNever();
            });

            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.Property(e => e.IdhangHoa).ValueGeneratedNever();

                entity.HasOne(d => d.IddanhMucNavigation)
                    .WithMany(p => p.HangHoas)
                    .HasForeignKey(d => d.IddanhMuc)
                    .HasConstraintName("FK_HangHoa_DanhMuc");

                entity.HasOne(d => d.IdnhaSanXuatNavigation)
                    .WithMany(p => p.HangHoas)
                    .HasForeignKey(d => d.IdnhaSanXuat)
                    .HasConstraintName("FK_HangHoa_NhaSanXuat");
            });

            modelBuilder.Entity<HoaDonBan>(entity =>
            {
                entity.Property(e => e.IdhoaDon).ValueGeneratedNever();

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdkhachHangNavigation)
                    .WithMany(p => p.HoaDonBans)
                    .HasForeignKey(d => d.IdkhachHang)
                    .HasConstraintName("FK_HoaDonBan_KhachHang");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.HoaDonBans)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("FK_HoaDonBan_NhanVien");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.Property(e => e.IdhoaDonChiTiet).ValueGeneratedNever();

                entity.HasOne(d => d.IdhoaDonNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdhoaDon)
                    .HasConstraintName("FK_HoaDonChiTiet_HoaDonBan");

                entity.HasOne(d => d.IdthongTinHangHoaNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdthongTinHangHoa)
                    .HasConstraintName("FK_HoaDonChiTiet_ChiTietHangHoa");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.IdkhachHang).ValueGeneratedNever();

                entity.HasOne(d => d.IddiemTieuDungNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.IddiemTieuDung)
                    .HasConstraintName("FK_KhachHang_DiemTieuDung");
            });

            modelBuilder.Entity<LichSuTieuDungDiem>(entity =>
            {
                entity.Property(e => e.IdlichSuDiem).ValueGeneratedNever();

                entity.HasOne(d => d.IddiemTieuDungNavigation)
                    .WithMany(p => p.LichSuTieuDungDiems)
                    .HasForeignKey(d => d.IddiemTieuDung)
                    .HasConstraintName("FK_LichSuTieuDungDiem_DiemTieuDung");

                entity.HasOne(d => d.IdhoaDonNavigation)
                    .WithMany(p => p.LichSuTieuDungDiems)
                    .HasForeignKey(d => d.IdhoaDon)
                    .HasConstraintName("FK_LichSuTieuDungDiem_HoaDonBan");
            });

            modelBuilder.Entity<NhaSanXuat>(entity =>
            {
                entity.Property(e => e.IdnhaSanXuat).ValueGeneratedNever();
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.Property(e => e.Iduser).ValueGeneratedNever();

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.Idrole)
                    .HasConstraintName("FK_NhanVien_Roles");
            });

            modelBuilder.Entity<NhomHuong>(entity =>
            {
                entity.Property(e => e.IdnhomHuong).ValueGeneratedNever();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Idrole).ValueGeneratedNever();
            });

            modelBuilder.Entity<VatChua>(entity =>
            {
                entity.Property(e => e.IdvatChua).ValueGeneratedNever();
            });

            modelBuilder.Entity<XuatXu>(entity =>
            {
                entity.Property(e => e.IdquocGia).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
