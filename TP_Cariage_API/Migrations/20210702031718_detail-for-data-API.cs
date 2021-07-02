using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class detailfordataAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Xes_LoaiGhes_LoaiXesId",
                table: "Xes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiGhes",
                table: "LoaiGhes");

            migrationBuilder.RenameTable(
                name: "LoaiGhes",
                newName: "LoaiXes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiXes",
                table: "LoaiXes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Xes_LoaiXes_LoaiXesId",
                table: "Xes",
                column: "LoaiXesId",
                principalTable: "LoaiXes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Xes_LoaiXes_LoaiXesId",
                table: "Xes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiXes",
                table: "LoaiXes");

            migrationBuilder.RenameTable(
                name: "LoaiXes",
                newName: "LoaiGhes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiGhes",
                table: "LoaiGhes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Xes_LoaiGhes_LoaiXesId",
                table: "Xes",
                column: "LoaiXesId",
                principalTable: "LoaiGhes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
