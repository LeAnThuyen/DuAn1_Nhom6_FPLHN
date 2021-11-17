using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL_DataAccessLayer.Migrations
{
    public partial class abcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem_IDLichSuDiem",
                table: "DiemTieuDung");

            migrationBuilder.AlterColumn<int>(
                name: "IDLichSuDiem",
                table: "DiemTieuDung",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem_IDLichSuDiem",
                table: "DiemTieuDung",
                column: "IDLichSuDiem",
                principalTable: "LichSuTieuDungDiem",
                principalColumn: "IDLichSuDiem",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem_IDLichSuDiem",
                table: "DiemTieuDung");

            migrationBuilder.AlterColumn<int>(
                name: "IDLichSuDiem",
                table: "DiemTieuDung",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DiemTieuDung_LichSuTieuDungDiem_IDLichSuDiem",
                table: "DiemTieuDung",
                column: "IDLichSuDiem",
                principalTable: "LichSuTieuDungDiem",
                principalColumn: "IDLichSuDiem",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
