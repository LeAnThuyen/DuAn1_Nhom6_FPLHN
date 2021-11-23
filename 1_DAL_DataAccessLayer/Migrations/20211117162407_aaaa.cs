using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL_DataAccessLayer.Migrations
{
    public partial class aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonBan_Users",
                table: "HoaDonBan");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonChiTiet_HoaDonBan",
                table: "HoaDonChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuTieuDungDiem_HoaDonBan_IDHoaDon",
                table: "LichSuTieuDungDiem");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles",
                table: "NhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonChiTiet_IDHoaDon",
                table: "HoaDonChiTiet");

            migrationBuilder.RenameColumn(
                name: "SoCMND",
                table: "KhachHang",
                newName: "SoDienThoai");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "HoaDonBan",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TenChatLieu",
                table: "ChatLieu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanVien",
                table: "NhanVien",
                column: "IDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonBan_NhanVien",
                table: "HoaDonBan",
                column: "IDUser",
                principalTable: "NhanVien",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuTieuDungDiem_HoaDonBan",
                table: "LichSuTieuDungDiem",
                column: "IDHoaDon",
                principalTable: "HoaDonBan",
                principalColumn: "IDHoaDon",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_Roles",
                table: "NhanVien",
                column: "IDRole",
                principalTable: "Roles",
                principalColumn: "IDRole",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonBan_NhanVien",
                table: "HoaDonBan");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuTieuDungDiem_HoaDonBan",
                table: "LichSuTieuDungDiem");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_Roles",
                table: "NhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanVien",
                table: "NhanVien");

            migrationBuilder.RenameColumn(
                name: "SoDienThoai",
                table: "KhachHang",
                newName: "SoCMND");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "HoaDonBan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<string>(
                name: "TenChatLieu",
                table: "ChatLieu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "NhanVien",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IDHoaDon",
                table: "HoaDonChiTiet",
                column: "IDHoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonBan_Users",
                table: "HoaDonBan",
                column: "IDUser",
                principalTable: "NhanVien",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonChiTiet_HoaDonBan",
                table: "HoaDonChiTiet",
                column: "IDHoaDon",
                principalTable: "HoaDonBan",
                principalColumn: "IDHoaDon",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuTieuDungDiem_HoaDonBan_IDHoaDon",
                table: "LichSuTieuDungDiem",
                column: "IDHoaDon",
                principalTable: "HoaDonBan",
                principalColumn: "IDHoaDon",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles",
                table: "NhanVien",
                column: "IDRole",
                principalTable: "Roles",
                principalColumn: "IDRole",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
