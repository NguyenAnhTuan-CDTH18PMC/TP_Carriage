using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class add_giave_chitietve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GiaVe",
                table: "ChiTietVes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaVe",
                table: "ChiTietVes");
        }
    }
}
