using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class updatedatabase210820213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AccountsId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AccountsId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "AccountsId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountsId1",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AccountsId1",
                table: "Comments",
                column: "AccountsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AccountsId1",
                table: "Comments",
                column: "AccountsId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AccountsId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AccountsId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AccountsId1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "AccountsId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AccountsId",
                table: "Comments",
                column: "AccountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AccountsId",
                table: "Comments",
                column: "AccountsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
