using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class Updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ghes_LoaiGhes_LoaiGheId",
                table: "Ghes");

            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiaDiemId",
                table: "LichTrinhs");

            migrationBuilder.DropIndex(
                name: "IX_LichTrinhs_DiaDiemId",
                table: "LichTrinhs");

            migrationBuilder.DropIndex(
                name: "IX_Ghes_LoaiGheId",
                table: "Ghes");

            migrationBuilder.DropColumn(
                name: "TenXe",
                table: "Xes");

            migrationBuilder.DropColumn(
                name: "GiaGhe",
                table: "LoaiGhes");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LoaiGhes");

            migrationBuilder.DropColumn(
                name: "DiaDiemId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "LoaiGheId",
                table: "Ghes");

            migrationBuilder.DropColumn(
                name: "TenDiemDi",
                table: "DiemDens");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "DiemDens");

            migrationBuilder.AddColumn<string>(
                name: "BienSoXe",
                table: "Xes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiXesId",
                table: "Xes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaTienIch",
                table: "Xes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianHuy",
                table: "VeXes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TenLoai",
                table: "LoaiGhes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiaDiemsId",
                table: "LichTrinhs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenDiaDiem",
                table: "DiemDens",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianDen",
                table: "ChuyenXes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "GioKhoiHanh",
                table: "ChuyenXes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "GioiTinh",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TienIchs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTienIch = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    HinhAnh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienIchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TienIchCuaXes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XesId = table.Column<int>(nullable: true),
                    TienIchsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienIchCuaXes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TienIchCuaXes_TienIchs_TienIchsId",
                        column: x => x.TienIchsId,
                        principalTable: "TienIchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TienIchCuaXes_Xes_XesId",
                        column: x => x.XesId,
                        principalTable: "Xes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Xes_LoaiXesId",
                table: "Xes",
                column: "LoaiXesId");

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinhs_DiaDiemsId",
                table: "LichTrinhs",
                column: "DiaDiemsId");

            migrationBuilder.CreateIndex(
                name: "IX_TienIchCuaXes_TienIchsId",
                table: "TienIchCuaXes",
                column: "TienIchsId");

            migrationBuilder.CreateIndex(
                name: "IX_TienIchCuaXes_XesId",
                table: "TienIchCuaXes",
                column: "XesId");

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiaDiemsId",
                table: "LichTrinhs",
                column: "DiaDiemsId",
                principalTable: "DiemDens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Xes_LoaiGhes_LoaiXesId",
                table: "Xes",
                column: "LoaiXesId",
                principalTable: "LoaiGhes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiaDiemsId",
                table: "LichTrinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_Xes_LoaiGhes_LoaiXesId",
                table: "Xes");

            migrationBuilder.DropTable(
                name: "TienIchCuaXes");

            migrationBuilder.DropTable(
                name: "TienIchs");

            migrationBuilder.DropIndex(
                name: "IX_Xes_LoaiXesId",
                table: "Xes");

            migrationBuilder.DropIndex(
                name: "IX_LichTrinhs_DiaDiemsId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "BienSoXe",
                table: "Xes");

            migrationBuilder.DropColumn(
                name: "LoaiXesId",
                table: "Xes");

            migrationBuilder.DropColumn(
                name: "MaTienIch",
                table: "Xes");

            migrationBuilder.DropColumn(
                name: "ThoiGianHuy",
                table: "VeXes");

            migrationBuilder.DropColumn(
                name: "TenLoai",
                table: "LoaiGhes");

            migrationBuilder.DropColumn(
                name: "DiaDiemsId",
                table: "LichTrinhs");

            migrationBuilder.DropColumn(
                name: "TenDiaDiem",
                table: "DiemDens");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TenXe",
                table: "Xes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaGhe",
                table: "LoaiGhes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "LoaiGhes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaDiemId",
                table: "LichTrinhs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiGheId",
                table: "Ghes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenDiemDi",
                table: "DiemDens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "DiemDens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianDen",
                table: "ChuyenXes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GioKhoiHanh",
                table: "ChuyenXes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinhs_DiaDiemId",
                table: "LichTrinhs",
                column: "DiaDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ghes_LoaiGheId",
                table: "Ghes",
                column: "LoaiGheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ghes_LoaiGhes_LoaiGheId",
                table: "Ghes",
                column: "LoaiGheId",
                principalTable: "LoaiGhes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinhs_DiemDens_DiaDiemId",
                table: "LichTrinhs",
                column: "DiaDiemId",
                principalTable: "DiemDens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
