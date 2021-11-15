using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL_DataAccessLayer.Migrations
{
    public partial class duan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anh",
                columns: table => new
                {
                    IDAnh = table.Column<int>(type: "int", nullable: false),
                    MaAnh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenAnh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DuongDan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anh", x => x.IDAnh);
                });

            migrationBuilder.CreateTable(
                name: "ChatLieu",
                columns: table => new
                {
                    IDChatLieu = table.Column<int>(type: "int", nullable: false),
                    MaChatLieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenChatLieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieu", x => x.IDChatLieu);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    IDDanhMuc = table.Column<int>(type: "int", nullable: false),
                    MaDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.IDDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "DiemTieuDung",
                columns: table => new
                {
                    IDDiemTieuDung = table.Column<int>(type: "int", nullable: false),
                    MaDiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenDiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoDiem = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemTieuDung", x => x.IDDiemTieuDung);
                });

            migrationBuilder.CreateTable(
                name: "DungTich",
                columns: table => new
                {
                    IDDungTich = table.Column<int>(type: "int", nullable: false),
                    MaDungTich = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoDungTich = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DungTich", x => x.IDDungTich);
                });

            migrationBuilder.CreateTable(
                name: "NhaSanXuat",
                columns: table => new
                {
                    IDNhaSanXuat = table.Column<int>(type: "int", nullable: false),
                    MaNhaSanXuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenNhaSanXuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaSanXuat", x => x.IDNhaSanXuat);
                });

            migrationBuilder.CreateTable(
                name: "NhomHuong",
                columns: table => new
                {
                    IDNhomHuong = table.Column<int>(type: "int", nullable: false),
                    MaNhomHuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenNhomHuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomHuong", x => x.IDNhomHuong);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IDRole = table.Column<int>(type: "int", nullable: false),
                    MaRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IDRole);
                });

            migrationBuilder.CreateTable(
                name: "VatChua",
                columns: table => new
                {
                    IDVatChua = table.Column<int>(type: "int", nullable: false),
                    MaVatChua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenVatChua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatChua", x => x.IDVatChua);
                });

            migrationBuilder.CreateTable(
                name: "XuatXu",
                columns: table => new
                {
                    IDQuocGia = table.Column<int>(type: "int", nullable: false),
                    MaQuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenQuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatXu", x => x.IDQuocGia);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    IDKhachHang = table.Column<int>(type: "int", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    NamSinh = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoCMND = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    IDDiemTieuDung = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.IDKhachHang);
                    table.ForeignKey(
                        name: "FK_KhachHang_DiemTieuDung",
                        column: x => x.IDDiemTieuDung,
                        principalTable: "DiemTieuDung",
                        principalColumn: "IDDiemTieuDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    IDHangHoa = table.Column<int>(type: "int", nullable: false),
                    TenHangHoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaHangHoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDNhaSanXuat = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    IDDanhMuc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.IDHangHoa);
                    table.ForeignKey(
                        name: "FK_HangHoa_DanhMuc",
                        column: x => x.IDDanhMuc,
                        principalTable: "DanhMuc",
                        principalColumn: "IDDanhMuc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HangHoa_NhaSanXuat",
                        column: x => x.IDNhaSanXuat,
                        principalTable: "NhaSanXuat",
                        principalColumn: "IDNhaSanXuat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    MaNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    NamSinh = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoCMND = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDRole = table.Column<int>(type: "int", nullable: true),
                    Flag = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles",
                        column: x => x.IDRole,
                        principalTable: "Roles",
                        principalColumn: "IDRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHangHoa",
                columns: table => new
                {
                    IDThongTinHangHoa = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mavach = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DonGiaNhap = table.Column<double>(type: "float", nullable: true),
                    DonGiaBan = table.Column<double>(type: "float", nullable: true),
                    HanSuDung = table.Column<DateTime>(type: "datetime", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayNhapKho = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    IDChatLieu = table.Column<int>(type: "int", nullable: true),
                    IDNhomHuong = table.Column<int>(type: "int", nullable: true),
                    IDHangHoa = table.Column<int>(type: "int", nullable: true),
                    IDQuocGia = table.Column<int>(type: "int", nullable: true),
                    IDDungTich = table.Column<int>(type: "int", nullable: true),
                    IDAnh = table.Column<int>(type: "int", nullable: true),
                    IDVatChua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHangHoa", x => x.IDThongTinHangHoa);
                    table.ForeignKey(
                        name: "FK_ChiTietHangHoa_Anh",
                        column: x => x.IDAnh,
                        principalTable: "Anh",
                        principalColumn: "IDAnh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHangHoa_ChatLieu",
                        column: x => x.IDChatLieu,
                        principalTable: "ChatLieu",
                        principalColumn: "IDChatLieu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHangHoa_DungTich",
                        column: x => x.IDDungTich,
                        principalTable: "DungTich",
                        principalColumn: "IDDungTich",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHangHoa_HangHoa",
                        column: x => x.IDHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "IDHangHoa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHangHoa_NhomHuong",
                        column: x => x.IDNhomHuong,
                        principalTable: "NhomHuong",
                        principalColumn: "IDNhomHuong",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHangHoa_VatChua",
                        column: x => x.IDVatChua,
                        principalTable: "VatChua",
                        principalColumn: "IDVatChua",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHangHoa_XuatXu",
                        column: x => x.IDQuocGia,
                        principalTable: "XuatXu",
                        principalColumn: "IDQuocGia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonBan",
                columns: table => new
                {
                    IDHoaDon = table.Column<int>(type: "int", nullable: false),
                    MaHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayNhanHang = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tien = table.Column<double>(type: "float", nullable: true),
                    Thue = table.Column<double>(type: "float", nullable: true),
                    TongSoTien = table.Column<double>(type: "float", nullable: true),
                    IDKhachHang = table.Column<int>(type: "int", nullable: true),
                    IDUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonBan", x => x.IDHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDonBan_KhachHang",
                        column: x => x.IDKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "IDKhachHang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDonBan_Users",
                        column: x => x.IDUser,
                        principalTable: "NhanVien",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    IDHoaDonChiTiet = table.Column<int>(type: "int", nullable: false),
                    MaHoaDonChiTiet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiamGia = table.Column<double>(type: "float", nullable: true),
                    ThanhTien = table.Column<double>(type: "float", nullable: true),
                    IDHoaDon = table.Column<int>(type: "int", nullable: true),
                    IDHangHoa = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    IDThongTinHangHoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => x.IDHoaDonChiTiet);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_ChiTietHangHoa",
                        column: x => x.IDThongTinHangHoa,
                        principalTable: "ChiTietHangHoa",
                        principalColumn: "IDThongTinHangHoa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDonBan",
                        column: x => x.IDHoaDon,
                        principalTable: "HoaDonBan",
                        principalColumn: "IDHoaDon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangHoa_IDAnh",
                table: "ChiTietHangHoa",
                column: "IDAnh");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangHoa_IDChatLieu",
                table: "ChiTietHangHoa",
                column: "IDChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangHoa_IDDungTich",
                table: "ChiTietHangHoa",
                column: "IDDungTich");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangHoa_IDHangHoa",
                table: "ChiTietHangHoa",
                column: "IDHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangHoa_IDNhomHuong",
                table: "ChiTietHangHoa",
                column: "IDNhomHuong");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangHoa_IDQuocGia",
                table: "ChiTietHangHoa",
                column: "IDQuocGia");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangHoa_IDVatChua",
                table: "ChiTietHangHoa",
                column: "IDVatChua");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_IDDanhMuc",
                table: "HangHoa",
                column: "IDDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_IDNhaSanXuat",
                table: "HangHoa",
                column: "IDNhaSanXuat");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBan_IDKhachHang",
                table: "HoaDonBan",
                column: "IDKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBan_IDUser",
                table: "HoaDonBan",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IDHoaDon",
                table: "HoaDonChiTiet",
                column: "IDHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IDThongTinHangHoa",
                table: "HoaDonChiTiet",
                column: "IDThongTinHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_IDDiemTieuDung",
                table: "KhachHang",
                column: "IDDiemTieuDung");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDRole",
                table: "NhanVien",
                column: "IDRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "ChiTietHangHoa");

            migrationBuilder.DropTable(
                name: "HoaDonBan");

            migrationBuilder.DropTable(
                name: "Anh");

            migrationBuilder.DropTable(
                name: "ChatLieu");

            migrationBuilder.DropTable(
                name: "DungTich");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "NhomHuong");

            migrationBuilder.DropTable(
                name: "VatChua");

            migrationBuilder.DropTable(
                name: "XuatXu");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "NhaSanXuat");

            migrationBuilder.DropTable(
                name: "DiemTieuDung");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
