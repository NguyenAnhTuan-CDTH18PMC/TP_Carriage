using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class updatedatabase21082021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descreption = table.Column<int>(nullable: false),
                    ChuyenXeId = table.Column<int>(nullable: false),
                    ChuyenXesId = table.Column<int>(nullable: true),
                    AccountsId = table.Column<string>(nullable: true),
                    NhaXesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_ChuyenXes_ChuyenXesId",
                        column: x => x.ChuyenXesId,
                        principalTable: "ChuyenXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_NhaXes_NhaXesId",
                        column: x => x.NhaXesId,
                        principalTable: "NhaXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AccountsId",
                table: "Comments",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ChuyenXesId",
                table: "Comments",
                column: "ChuyenXesId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NhaXesId",
                table: "Comments",
                column: "NhaXesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NhaXeId = table.Column<int>(type: "int", nullable: false),
                    NhaXesId = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_NhaXes_NhaXesId",
                        column: x => x.NhaXesId,
                        principalTable: "NhaXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_AccountsId",
                table: "Chats",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_NhaXesId",
                table: "Chats",
                column: "NhaXesId");
        }
    }
}
