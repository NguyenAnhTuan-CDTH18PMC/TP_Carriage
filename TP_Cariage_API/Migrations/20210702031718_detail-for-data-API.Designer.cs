﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_Cariage_API.Data;

namespace TP_Cariage_API.Migrations
{
    [DbContext(typeof(TPCarriageContext))]
    [Migration("20210702031718_detail-for-data-API")]
    partial class detailfordataAPI
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Accounts", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cmnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("NamSinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTaoTk")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Quyen")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.BenXes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenBenXe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BenXes");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Chats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NhaXeId")
                        .HasColumnType("int");

                    b.Property<int?>("NhaXesId")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountsId");

                    b.HasIndex("NhaXesId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.ChiTietVes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GheId")
                        .HasColumnType("int");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GiaVe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VeXeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GheId");

                    b.HasIndex("VeXeId");

                    b.ToTable("ChiTietVes");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.ChuyenXes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GioKhoiHanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LichTrinhId")
                        .HasColumnType("int");

                    b.Property<int?>("LichTrinhsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayKhoiHanh")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThoiGianDen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<int>("XeId")
                        .HasColumnType("int");

                    b.Property<int?>("XesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LichTrinhsId");

                    b.HasIndex("XesId");

                    b.ToTable("ChuyenXes");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.DiaDiems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDiaDiem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiemDens");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Ghes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SoCot")
                        .HasColumnType("int");

                    b.Property<int>("SoHang")
                        .HasColumnType("int");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("XeId")
                        .HasColumnType("int");

                    b.Property<int?>("XesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("XesId");

                    b.ToTable("Ghes");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.LichTrinhs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiaDiemId")
                        .HasColumnType("int");

                    b.Property<int?>("DiaDiemsId")
                        .HasColumnType("int");

                    b.Property<decimal>("GiaChuyenDi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KhoangCach")
                        .HasColumnType("int");

                    b.Property<int>("ThoiGianUocTinh")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiaDiemsId");

                    b.ToTable("LichTrinhs");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.LoaiXes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiXes");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Messagegroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReceved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<string>("TenGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messagegroups");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Messages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descreption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReceved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.NhaXes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BenXeId")
                        .HasColumnType("int");

                    b.Property<int?>("BenXesId")
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongXe")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BenXesId");

                    b.ToTable("NhaXes");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.NhanXets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AccountsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayNhanXet")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhaXeId")
                        .HasColumnType("int");

                    b.Property<int?>("NhaXesId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDungNhanXet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountsId");

                    b.HasIndex("NhaXesId");

                    b.ToTable("NhanXets");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.TienIchCuaXes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TienIchId")
                        .HasColumnType("int");

                    b.Property<int?>("TienIchsId")
                        .HasColumnType("int");

                    b.Property<int>("XeId")
                        .HasColumnType("int");

                    b.Property<int?>("XesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TienIchsId");

                    b.HasIndex("XesId");

                    b.ToTable("TienIchCuaXes");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.TienIchs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTienIch")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TienIchs");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.VeXes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AccountsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ChuyenXeId")
                        .HasColumnType("int");

                    b.Property<int?>("ChuyenXesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianHuy")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountsId");

                    b.HasIndex("ChuyenXesId");

                    b.ToTable("VeXes");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Xes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BienSoXe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GiaGhe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiXe")
                        .HasColumnType("int");

                    b.Property<int>("LoaiXeId")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiXesId")
                        .HasColumnType("int");

                    b.Property<int>("MaTienIch")
                        .HasColumnType("int");

                    b.Property<int>("NhaXeId")
                        .HasColumnType("int");

                    b.Property<int?>("NhaXesId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongCot")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongHang")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiXesId");

                    b.HasIndex("NhaXesId");

                    b.ToTable("Xes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.Accounts", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.Accounts", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_Cariage_API.Models.Accounts", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.Accounts", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Chats", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.Accounts", null)
                        .WithMany("Chats")
                        .HasForeignKey("AccountsId");

                    b.HasOne("TP_Cariage_API.Models.NhaXes", "NhaXes")
                        .WithMany("Chats")
                        .HasForeignKey("NhaXesId");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.ChiTietVes", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.Ghes", "Ghe")
                        .WithMany("ChiTietVes")
                        .HasForeignKey("GheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_Cariage_API.Models.VeXes", "VeXe")
                        .WithMany("ChiTietVes")
                        .HasForeignKey("VeXeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_Cariage_API.Models.ChuyenXes", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.LichTrinhs", "LichTrinhs")
                        .WithMany("ChuyenXes")
                        .HasForeignKey("LichTrinhsId");

                    b.HasOne("TP_Cariage_API.Models.Xes", "Xes")
                        .WithMany("ChuyenXes")
                        .HasForeignKey("XesId");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Ghes", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.Xes", "Xes")
                        .WithMany("Ghes")
                        .HasForeignKey("XesId");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.LichTrinhs", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.DiaDiems", "DiaDiems")
                        .WithMany("LichTrinhs")
                        .HasForeignKey("DiaDiemsId");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.NhaXes", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.BenXes", "BenXes")
                        .WithMany("NhaXes")
                        .HasForeignKey("BenXesId");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.NhanXets", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.Accounts", "Accounts")
                        .WithMany("NhanXets")
                        .HasForeignKey("AccountsId");

                    b.HasOne("TP_Cariage_API.Models.NhaXes", "NhaXes")
                        .WithMany("NhanXets")
                        .HasForeignKey("NhaXesId");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.TienIchCuaXes", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.TienIchs", "TienIchs")
                        .WithMany("TienIchCuaXes")
                        .HasForeignKey("TienIchsId");

                    b.HasOne("TP_Cariage_API.Models.Xes", "Xes")
                        .WithMany("TienIchCuaXes")
                        .HasForeignKey("XesId");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.VeXes", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.Accounts", "Accounts")
                        .WithMany("VeXes")
                        .HasForeignKey("AccountsId");

                    b.HasOne("TP_Cariage_API.Models.ChuyenXes", "ChuyenXes")
                        .WithMany("VeXes")
                        .HasForeignKey("ChuyenXesId");
                });

            modelBuilder.Entity("TP_Cariage_API.Models.Xes", b =>
                {
                    b.HasOne("TP_Cariage_API.Models.LoaiXes", "LoaiXes")
                        .WithMany("Xes")
                        .HasForeignKey("LoaiXesId");

                    b.HasOne("TP_Cariage_API.Models.NhaXes", "NhaXes")
                        .WithMany("Xes")
                        .HasForeignKey("NhaXesId");
                });
#pragma warning restore 612, 618
        }
    }
}
