using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class addkhuyenmai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChuyenXes_KhuyenMais_KhuyenMaiId",
                table: "ChuyenXes");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropIndex(
                name: "IX_ChuyenXes_KhuyenMaiId",
                table: "ChuyenXes");

            migrationBuilder.DropColumn(
                name: "KhuyenMaiId",
                table: "ChuyenXes");

            migrationBuilder.DropColumn(
                name: "GiamGia",
                table: "ChiTietVes");

            migrationBuilder.AddColumn<int>(
                name: "GiamGia",
                table: "ChuyenXes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiamGia",
                table: "ChuyenXes");

            migrationBuilder.AddColumn<int>(
                name: "KhuyenMaiId",
                table: "ChuyenXes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "GiamGia",
                table: "ChiTietVes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanTramKhuyenMai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXes_KhuyenMaiId",
                table: "ChuyenXes",
                column: "KhuyenMaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuyenXes_KhuyenMais_KhuyenMaiId",
                table: "ChuyenXes",
                column: "KhuyenMaiId",
                principalTable: "KhuyenMais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
