﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Cariage_API.Models;

namespace TP_Cariage_API.Data
{
    public class TPCarriageContext:IdentityDbContext<Accounts>
    {
        public TPCarriageContext(DbContextOptions<TPCarriageContext> options) : base(options)
        {
        }
        public DbSet<BenXes> BenXes { get; set; }
        public DbSet<Chats> Chats { get; set; }
        public DbSet<ChiTietVes> ChiTietVes { get; set; }
        public DbSet<ChuyenXes> ChuyenXes { get; set; }
        public DbSet<DiaDiems> DiemDens { get; set; }
        public DbSet<Ghes> Ghes { get; set; }
        public DbSet<LichTrinhs> LichTrinhs { get; set; }
        public DbSet<LoaiXes> LoaiXes { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Messagegroups> Messagegroups { get; set; }
        public DbSet<NhanXets> NhanXets { get; set; }
        public DbSet<NhaXes> NhaXes { get; set; }
        public DbSet<VeXes> VeXes { get; set; }
        public DbSet<Xes> Xes { get; set; }
        public DbSet<TP_Cariage_API.Models.News> News { get; set; }
        public DbSet<TP_Cariage_API.Models.TienIchCuaXes> TienIchCuaXes { get; set; }
        public DbSet<TP_Cariage_API.Models.TienIchs> TienIchs { get; set; }
        //override protected void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<LichTrinhs>().HasKey(sc => new { sc.DiemDenId, sc.DiemDiId });
        //    modelBuilder.Entity<LichTrinhs>()
        //           .HasOne(m => m.DiemDens)
        //           .WithOne(t => t.)
        //           .HasForeignKey<UserUserFavorite>(m => m.UserId1)
        //           .OnDelete(DeleteBehavior.Restrict);
        //    modelBuilder.Entity<LichTrinhs>()
        //                .HasOne(m => m.DiemDis)
        //                .WithOne(t => t.userUserFavorite2)
        //                .HasForeignKey<UserUserFavorite>(m => m.UserId2)
        //                .OnDelete(DeleteBehavior.Restrict);

        //}
    }

}
