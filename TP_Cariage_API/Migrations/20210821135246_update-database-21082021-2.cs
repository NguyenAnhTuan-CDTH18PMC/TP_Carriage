using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class updatedatabase210820212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ChuyenXes_ChuyenXesId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ChuyenXeId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ChuyenXesId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ChuyenXes_ChuyenXesId",
                table: "Comments",
                column: "ChuyenXesId",
                principalTable: "ChuyenXes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ChuyenXes_ChuyenXesId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ChuyenXesId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ChuyenXeId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ChuyenXes_ChuyenXesId",
                table: "Comments",
                column: "ChuyenXesId",
                principalTable: "ChuyenXes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
