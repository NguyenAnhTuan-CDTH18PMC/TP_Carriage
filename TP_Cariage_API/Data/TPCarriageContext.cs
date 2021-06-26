using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Cariage_API.Models;

namespace TP_Cariage_API.Data
{
    public class TPCarriageContext:DbContext
    {
        public TPCarriageContext(DbContextOptions<TPCarriageContext> options) : base(options)
        {
        }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<BenXes> BenXes { get; set; }
        public DbSet<Chats> Chats { get; set; }
        public DbSet<ChiTietVes> ChiTietVes { get; set; }
        public DbSet<ChuyenXes> ChuyenXes{ get; set; }
        public DbSet<DiaDiems> DiemDens { get; set; }
        public DbSet<Ghes> Ghes { get; set; }
        public DbSet<LichTrinhs> LichTrinhs { get; set; }
        public DbSet<LoaiGhes> LoaiGhes { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Messagegroups> Messagegroups { get; set; }
        public DbSet<NhanXets> NhanXets { get; set; }
        public DbSet<NhaXes> NhaXes { get; set; }
        public DbSet<VeXes> VeXes { get; set; }
        public DbSet<Xes> Xes { get; set; }
    }
}
