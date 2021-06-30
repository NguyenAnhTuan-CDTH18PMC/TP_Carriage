using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Xes
    {
        public int Id { get; set; }
        public string HinhAnh { get; set; }
        public string BienSoXe { get; set; }
        public decimal GiaGhe { get; set; }
        public int LoaiXe { get; set; }
        public int SoLuongHang { get; set; }
        public int SoLuongCot { get; set; }
        public int TrangThai { get; set; }
        public int MaTienIch { get; set; }


        public virtual NhaXes NhaXe { get; set; }
        public virtual LoaiXes LoaiXes { get; set; }
        public virtual ICollection<ChuyenXes> ChuyenXes { get; set; }
        public virtual ICollection<Ghes> Ghes { get; set; }
        public virtual ICollection<TienIchCuaXes> TienIchCuaXes { get; set; }
    }
}
