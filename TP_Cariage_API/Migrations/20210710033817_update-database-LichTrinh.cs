using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class updatedatabaseLichTrinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiaDiemsId",
                table: "LichTrinhs");

            migrationBuilder.DropIndex(
                name: "IX_LichTrinhs_DiaDiemsId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "DiaDiemId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "DiaDiemsId",
                table: "LichTrinhs");

            migrationBuilder.AddColumn<int>(
                name: "DiemDenId",
                table: "LichTrinhs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiemDensId",
                table: "LichTrinhs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiemDiId",
                table: "LichTrinhs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiemDisId",
                table: "LichTrinhs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinhs_DiemDensId",
                table: "LichTrinhs",
                column: "DiemDensId");

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinhs_DiemDisId",
                table: "LichTrinhs",
                column: "DiemDisId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiemDensId",
                table: "LichTrinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiemDisId",
                table: "LichTrinhs");

            migrationBuilder.DropIndex(
                name: "IX_LichTrinhs_DiemDensId",
                table: "LichTrinhs");

            migrationBuilder.DropIndex(
                name: "IX_LichTrinhs_DiemDisId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "DiemDenId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "DiemDensId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "DiemDiId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "DiemDisId",
                table: "LichTrinhs");

            migrationBuilder.AddColumn<int>(
                name: "DiaDiemId",
                table: "LichTrinhs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaDiemsId",
                table: "LichTrinhs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinhs_DiaDiemsId",
                table: "LichTrinhs",
                column: "DiaDiemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiaDiemsId",
                table: "LichTrinhs",
                column: "DiaDiemsId",
                principalTable: "DiemDens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
