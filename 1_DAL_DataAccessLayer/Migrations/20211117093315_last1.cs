using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL_DataAccessLayer.Migrations
{
    public partial class last1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "NamSinh",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "KhachHang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GioiTinh",
                table: "KhachHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NamSinh",
                table: "KhachHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "KhachHang",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
