using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.DTOs
{
    public class NhaXeMoney
    {
        public NhaXeMoney(string hanhTrinh, decimal tongTien)
        {
            HanhTrinh = hanhTrinh;
            TongTien = tongTien;
        }
        public string HanhTrinh { get; set; }
        public decimal TongTien { get; set; }
    }
}
