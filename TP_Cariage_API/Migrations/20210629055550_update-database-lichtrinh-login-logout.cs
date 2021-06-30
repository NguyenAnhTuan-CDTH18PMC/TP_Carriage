using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Cariage_API.Migrations
{
    public partial class updatedatabaselichtrinhloginlogout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    AccountId = table.Column<string>(nullable: true),
                    NhaXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
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
                    AccountId = table.Column<string>(nullable: true),
                    NhaXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanXets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanXets_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
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
                    AccountId = table.Column<string>(nullable: true),
                    ChuyenXeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeXes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeXes_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
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
                    GiaVe = table.Column<decimal>(nullable: false),
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChiTietVes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "NhanXets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DiemDens");

            migrationBuilder.DropTable(
                name: "NhaXes");

            migrationBuilder.DropTable(
                name: "BenXes");
        }
    }
}
