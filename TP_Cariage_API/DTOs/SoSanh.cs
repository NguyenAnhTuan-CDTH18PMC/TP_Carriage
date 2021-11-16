using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.DTOs
{
    public class SoSanh
    {
        public SoSanh(string nhaxe,string loai,decimal gia,int idnhaxe,int idloaixe,int idbanggia)
        {
            TenNhaXe = nhaxe;
            TenLoai = loai;
            GiaVe = gia;
            IdNhaXe = idnhaxe;
            IdLoaiXe = idloaixe;
            IdBangGia = idbanggia;
        }
        public string TenNhaXe { get; set; }
        public int IdNhaXe { get; set; }
        public int IdLoaiXe { get; set; }
        public int IdBangGia { get; set; }
        public string TenLoai { get; set; }
        public decimal GiaVe { get; set; }
    }
}
