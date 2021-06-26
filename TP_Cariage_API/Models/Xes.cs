﻿using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Xes
    {
        public Xes()
        {
            ChuyenXes = new HashSet<ChuyenXes>();
            Ghes = new HashSet<Ghes>();
        }

        public int Id { get; set; }
        public string HinhAnh { get; set; }
        public string TenXe { get; set; }
        public decimal GiaGhe { get; set; }
        public int LoaiXe { get; set; }
        public int SoLuongHang { get; set; }
        public int SoLuongCot { get; set; }
        public int TrangThai { get; set; }
       


        public virtual NhaXes NhaXe { get; set; }
        public virtual ICollection<ChuyenXes> ChuyenXes { get; set; }
        public virtual ICollection<Ghes> Ghes { get; set; }
    }
}
