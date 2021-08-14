using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class updatedatabase14082021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "LoaiXes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "BangGias",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LoaiXes");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "BangGias");
        }
    }
}
