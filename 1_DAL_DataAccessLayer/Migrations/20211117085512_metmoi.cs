using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL_DataAccessLayer.Migrations
{
    public partial class metmoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiemTieuDung_ChiTietHangHoa_IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung");

            migrationBuilder.DropIndex(
                name: "IX_DiemTieuDung_IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung");

            migrationBuilder.DropColumn(
                name: "IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiemTieuDung_IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung",
                column: "IdthongTinHangHoaNavigationIdthongTinHangHoa");

            migrationBuilder.AddForeignKey(
                name: "FK_DiemTieuDung_ChiTietHangHoa_IdthongTinHangHoaNavigationIdthongTinHangHoa",
                table: "DiemTieuDung",
                column: "IdthongTinHangHoaNavigationIdthongTinHangHoa",
                principalTable: "ChiTietHangHoa",
                principalColumn: "IDThongTinHangHoa",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
