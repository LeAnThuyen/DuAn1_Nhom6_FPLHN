using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL_DataAccessLayer.Migrations
{
    public partial class lat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaDiem",
                table: "DiemTieuDung");

            migrationBuilder.DropColumn(
                name: "TenDiem",
                table: "DiemTieuDung");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayShipHang",
                table: "HoaDonBan",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDLichSuDiem",
                table: "DiemTieuDung",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LichSuTieuDungDiem",
                columns: table => new
                {
                    IDLichSuDiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgaySuDung = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoDiemTieu = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    IDHoaDon = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuTieuDungDiem", x => x.IDLichSuDiem);
                    table.ForeignKey(
                        name: "FK_LichSuTieuDungDiem_HoaDonBan_IDHoaDon",
                        column: x => x.IDHoaDon,
                        principalTable: "HoaDonBan",
                        principalColumn: "IDHoaDon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiemTieuDung_IDLichSuDiem",
                table: "DiemTieuDung",
                column: "IDLichSuDiem");

            migrationBuilder.CreateIndex(
                name: "IX_DiemTieuDung_IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung",
                column: "IdthongTinHangHoaNavigationIdthongTinHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuTieuDungDiem_IDHoaDon",
                table: "LichSuTieuDungDiem",
                column: "IDHoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_DiemTieuDung_ChiTietHangHoa_IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung",
                column: "IdthongTinHangHoaNavigationIdthongTinHangHoa",
                principalTable: "ChiTietHangHoa",
                principalColumn: "IDThongTinHangHoa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem_IDLichSuDiem",
                table: "DiemTieuDung",
                column: "IDLichSuDiem",
                principalTable: "LichSuTieuDungDiem",
                principalColumn: "IDLichSuDiem",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiemTieuDung_ChiTietHangHoa_IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung");

            migrationBuilder.DropForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem_IDLichSuDiem",
                table: "DiemTieuDung");

            migrationBuilder.DropTable(
                name: "LichSuTieuDungDiem");

            migrationBuilder.DropIndex(
                name: "IX_DiemTieuDung_IDLichSuDiem",
                table: "DiemTieuDung");

            migrationBuilder.DropIndex(
                name: "IX_DiemTieuDung_IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung");

            migrationBuilder.DropColumn(
                name: "NgayShipHang",
                table: "HoaDonBan");

            migrationBuilder.DropColumn(
                name: "IDLichSuDiem",
                table: "DiemTieuDung");

            migrationBuilder.DropColumn(
                name: "IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung");

            migrationBuilder.AddColumn<string>(
                name: "MaDiem",
                table: "DiemTieuDung",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenDiem",
                table: "DiemTieuDung",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
