using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class updatedatabaseAccountNhaXe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountsEmail",
                table: "NhaXes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountsId",
                table: "NhaXes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhaXes_AccountsId",
                table: "NhaXes",
                column: "AccountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhaXes_AspNetUsers_AccountsId",
                table: "NhaXes",
                column: "AccountsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhaXes_AspNetUsers_AccountsId",
                table: "NhaXes");

            migrationBuilder.DropIndex(
                name: "IX_NhaXes_AccountsId",
                table: "NhaXes");

            migrationBuilder.DropColumn(
                name: "AccountsEmail",
                table: "NhaXes");

            migrationBuilder.DropColumn(
                name: "AccountsId",
                table: "NhaXes");
        }
    }
}
