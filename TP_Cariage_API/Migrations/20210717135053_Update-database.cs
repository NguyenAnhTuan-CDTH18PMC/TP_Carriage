using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class Updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiemDensId",
                table: "LichTrinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiemDisId",
                table: "LichTrinhs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiemDens",
                table: "DiemDens");

            migrationBuilder.DropColumn(
                name: "GiaGhe",
                table: "Xes");

            migrationBuilder.DropColumn(
                name: "GiaChuyenDi",
                table: "LichTrinhs");

            migrationBuilder.RenameTable(
                name: "DiemDens",
                newName: "DiaDiems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaDiems",
                table: "DiaDiems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BangGias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaVe = table.Column<decimal>(nullable: false),
                    NhaXesId = table.Column<int>(nullable: false),
                    LoaiXesId = table.Column<int>(nullable: false),
                    LichTrinhsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BangGias_LichTrinhs_LichTrinhsId",
                        column: x => x.LichTrinhsId,
                        principalTable: "LichTrinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BangGias_LoaiXes_LoaiXesId",
                        column: x => x.LoaiXesId,
                        principalTable: "LoaiXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BangGias_NhaXes_NhaXesId",
                        column: x => x.NhaXesId,
                        principalTable: "NhaXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BangGias_LichTrinhsId",
                table: "BangGias",
                column: "LichTrinhsId");

            migrationBuilder.CreateIndex(
                name: "IX_BangGias_LoaiXesId",
                table: "BangGias",
                column: "LoaiXesId");

            migrationBuilder.CreateIndex(
                name: "IX_BangGias_NhaXesId",
                table: "BangGias",
                column: "NhaXesId");

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinhs_DiaDiems_DiemDensId",
                table: "LichTrinhs",
                column: "DiemDensId",
                principalTable: "DiaDiems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinhs_DiaDiems_DiemDisId",
                table: "LichTrinhs",
                column: "DiemDisId",
                principalTable: "DiaDiems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiaDiems_DiemDensId",
                table: "LichTrinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiaDiems_DiemDisId",
                table: "LichTrinhs");

            migrationBuilder.DropTable(
                name: "BangGias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaDiems",
                table: "DiaDiems");

            migrationBuilder.RenameTable(
                name: "DiaDiems",
                newName: "DiemDens");

            migrationBuilder.AddColumn<decimal>(
                name: "GiaGhe",
                table: "Xes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaChuyenDi",
                table: "LichTrinhs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiemDens",
                table: "DiemDens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiemDensId",
                table: "LichTrinhs",
                column: "DiemDensId",
                principalTable: "DiemDens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiemDisId",
                table: "LichTrinhs",
                column: "DiemDisId",
                principalTable: "DiemDens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
