using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.DTOs
{
    public class DanhGia
    {
        public DanhGia(float trungbinh,int tongve,decimal tongtien)
        {
            DiemTrungBinh = trungbinh;
            tongVe = tongve;
            tongTien = tongtien;
        }
        public float DiemTrungBinh { get; set; }
        public int tongVe { get; set; }
        public decimal tongTien { get; set; }
    }
}
