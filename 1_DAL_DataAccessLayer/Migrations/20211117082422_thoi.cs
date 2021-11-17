using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL_DataAccessLayer.Migrations
{
    public partial class thoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem_IDLichSuDiem",
                table: "DiemTieuDung");

            migrationBuilder.AlterColumn<int>(
                name: "IDLichSuDiem",
                table: "LichSuTieuDungDiem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem",
                table: "DiemTieuDung",
                column: "IDLichSuDiem",
                principalTable: "LichSuTieuDungDiem",
                principalColumn: "IDLichSuDiem",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem",
                table: "DiemTieuDung");

            migrationBuilder.AlterColumn<int>(
                name: "IDLichSuDiem",
                table: "LichSuTieuDungDiem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem_IDLichSuDiem",
                table: "DiemTieuDung",
                column: "IDLichSuDiem",
                principalTable: "LichSuTieuDungDiem",
                principalColumn: "IDLichSuDiem",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
