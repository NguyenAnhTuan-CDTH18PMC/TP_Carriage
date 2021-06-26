using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class Delete_ID_for_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaAccount",
                table: "VeXes");

            migrationBuilder.DropColumn(
                name: "MaChuyenXe",
                table: "VeXes");

            migrationBuilder.DropColumn(
                name: "MaAccount",
                table: "NhanXets");

            migrationBuilder.DropColumn(
                name: "MaNhaXe",
                table: "NhanXets");

            migrationBuilder.DropColumn(
                name: "MaMesageGroup",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MaChat",
                table: "Messagegroups");

            migrationBuilder.DropColumn(
                name: "MaDiemDen",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "MaDiemDi",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "MaLoaiGhe",
                table: "Ghes");

            migrationBuilder.DropColumn(
                name: "MaXe",
                table: "Ghes");

            migrationBuilder.DropColumn(
                name: "MaLichTrinh",
                table: "ChuyenXes");

            migrationBuilder.DropColumn(
                name: "MaXe",
                table: "ChuyenXes");

            migrationBuilder.DropColumn(
                name: "MaGhe",
                table: "ChiTietVes");

            migrationBuilder.DropColumn(
                name: "MaVeXe",
                table: "ChiTietVes");

            migrationBuilder.DropColumn(
                name: "MaAccount",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "MaNhaXe",
                table: "Chats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaAccount",
                table: "VeXes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaChuyenXe",
                table: "VeXes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaAccount",
                table: "NhanXets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaNhaXe",
                table: "NhanXets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaMesageGroup",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaChat",
                table: "Messagegroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaDiemDen",
                table: "LichTrinhs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaDiemDi",
                table: "LichTrinhs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaLoaiGhe",
                table: "Ghes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaXe",
                table: "Ghes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaLichTrinh",
                table: "ChuyenXes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaXe",
                table: "ChuyenXes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaGhe",
                table: "ChiTietVes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaVeXe",
                table: "ChiTietVes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaAccount",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaNhaXe",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
