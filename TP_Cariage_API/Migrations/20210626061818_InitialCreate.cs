using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TenKh = table.Column<string>(nullable: true),
                    Cmnd = table.Column<string>(nullable: true),
                    AnhDaiDien = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    NamSinh = table.Column<DateTime>(nullable: false),
                    Quyen = table.Column<int>(nullable: false),
                    NgayTaoTk = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenXes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBenXe = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Sdt = table.Column<string>(nullable: true),
                    HinhAnh = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenXes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiemDens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDiemDi = table.Column<string>(nullable: true),
                    HinhAnh = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Mota = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemDens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiGhes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaGhe = table.Column<decimal>(nullable: false),
                    HinhAnh = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGhes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaXes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(nullable: true),
                    Sdt = table.Column<string>(nullable: true),
                    HinhAnh = table.Column<string>(nullable: true),
                    SoLuongXe = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    BenXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhaXes_BenXes_BenXeId",
                        column: x => x.BenXeId,
                        principalTable: "BenXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LichTrinhs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaChuyenDi = table.Column<decimal>(nullable: false),
                    KhoangCach = table.Column<int>(nullable: false),
                    ThoiGianUocTinh = table.Column<int>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    MaDiemDen = table.Column<int>(nullable: false),
                    MaDiemDi = table.Column<int>(nullable: false),
                    DiaDiemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichTrinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichTrinhs_DiemDens_DiaDiemId",
                        column: x => x.DiaDiemId,
                        principalTable: "DiemDens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<int>(nullable: false),
                    MaAccount = table.Column<int>(nullable: false),
                    MaNhaXe = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: true),
                    NhaXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_NhaXes_NhaXeId",
                        column: x => x.NhaXeId,
                        principalTable: "NhaXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanXets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDungNhanXet = table.Column<string>(nullable: true),
                    NgayNhanXet = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    MaNhaXe = table.Column<int>(nullable: false),
                    MaAccount = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: true),
                    NhaXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanXets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanXets_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanXets_NhaXes_NhaXeId",
                        column: x => x.NhaXeId,
                        principalTable: "NhaXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Xes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnh = table.Column<string>(nullable: true),
                    TenXe = table.Column<string>(nullable: true),
                    GiaGhe = table.Column<decimal>(nullable: false),
                    LoaiXe = table.Column<int>(nullable: false),
                    SoLuongHang = table.Column<int>(nullable: false),
                    SoLuongCot = table.Column<int>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    NhaXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xes_NhaXes_NhaXeId",
                        column: x => x.NhaXeId,
                        principalTable: "NhaXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messagegroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGroup = table.Column<string>(nullable: true),
                    IsSeen = table.Column<bool>(nullable: false),
                    IsReceved = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaChat = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messagegroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messagegroups_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenXes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayKhoiHanh = table.Column<DateTime>(nullable: false),
                    GioKhoiHanh = table.Column<DateTime>(nullable: false),
                    ThoiGianDen = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    MaLichTrinh = table.Column<int>(nullable: false),
                    MaXe = table.Column<int>(nullable: false),
                    LichTrinhId = table.Column<int>(nullable: true),
                    XeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenXes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuyenXes_LichTrinhs_LichTrinhId",
                        column: x => x.LichTrinhId,
                        principalTable: "LichTrinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChuyenXes_Xes_XeId",
                        column: x => x.XeId,
                        principalTable: "Xes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ghes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHang = table.Column<int>(nullable: false),
                    SoCot = table.Column<int>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    MaLoaiGhe = table.Column<int>(nullable: false),
                    MaXe = table.Column<int>(nullable: false),
                    LoaiGheId = table.Column<int>(nullable: true),
                    XeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ghes_LoaiGhes_LoaiGheId",
                        column: x => x.LoaiGheId,
                        principalTable: "LoaiGhes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ghes_Xes_XeId",
                        column: x => x.XeId,
                        principalTable: "Xes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descreption = table.Column<string>(nullable: true),
                    IsSeen = table.Column<bool>(nullable: false),
                    IsReceved = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaMesageGroup = table.Column<int>(nullable: false),
                    MessagegroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Messagegroups_MessagegroupId",
                        column: x => x.MessagegroupId,
                        principalTable: "Messagegroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VeXes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<int>(nullable: false),
                    MaChuyenXe = table.Column<int>(nullable: false),
                    MaAccount = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: true),
                    ChuyenXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeXes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeXes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeXes_ChuyenXes_ChuyenXeId",
                        column: x => x.ChuyenXeId,
                        principalTable: "ChuyenXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietVes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GhiChu = table.Column<string>(nullable: true),
                    MaVeXe = table.Column<int>(nullable: false),
                    MaGhe = table.Column<int>(nullable: false),
                    GheId = table.Column<int>(nullable: true),
                    VeXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietVes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietVes_Ghes_GheId",
                        column: x => x.GheId,
                        principalTable: "Ghes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietVes_VeXes_VeXeId",
                        column: x => x.VeXeId,
                        principalTable: "VeXes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_AccountId",
                table: "Chats",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_NhaXeId",
                table: "Chats",
                column: "NhaXeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietVes_GheId",
                table: "ChiTietVes",
                column: "GheId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietVes_VeXeId",
                table: "ChiTietVes",
                column: "VeXeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXes_LichTrinhId",
                table: "ChuyenXes",
                column: "LichTrinhId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXes_XeId",
                table: "ChuyenXes",
                column: "XeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ghes_LoaiGheId",
                table: "Ghes",
                column: "LoaiGheId");

            migrationBuilder.CreateIndex(
                name: "IX_Ghes_XeId",
                table: "Ghes",
                column: "XeId");

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinhs_DiaDiemId",
                table: "LichTrinhs",
                column: "DiaDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_Messagegroups_ChatId",
                table: "Messagegroups",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessagegroupId",
                table: "Messages",
                column: "MessagegroupId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanXets_AccountId",
                table: "NhanXets",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanXets_NhaXeId",
                table: "NhanXets",
                column: "NhaXeId");

            migrationBuilder.CreateIndex(
                name: "IX_NhaXes_BenXeId",
                table: "NhaXes",
                column: "BenXeId");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_AccountId",
                table: "VeXes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_ChuyenXeId",
                table: "VeXes",
                column: "ChuyenXeId");

            migrationBuilder.CreateIndex(
                name: "IX_Xes_NhaXeId",
                table: "Xes",
                column: "NhaXeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietVes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "NhanXets");

            migrationBuilder.DropTable(
                name: "Ghes");

            migrationBuilder.DropTable(
                name: "VeXes");

            migrationBuilder.DropTable(
                name: "Messagegroups");

            migrationBuilder.DropTable(
                name: "LoaiGhes");

            migrationBuilder.DropTable(
                name: "ChuyenXes");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "LichTrinhs");

            migrationBuilder.DropTable(
                name: "Xes");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "DiemDens");

            migrationBuilder.DropTable(
                name: "NhaXes");

            migrationBuilder.DropTable(
                name: "BenXes");
        }
    }
}
