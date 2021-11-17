using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL_DataAccessLayer.Migrations
{
    public partial class thuyentienti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDHangHoa",
                table: "HoaDonChiTiet",
                newName: "TrangThai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "HoaDonChiTiet",
                newName: "IDHangHoa");
        }
    }
}
