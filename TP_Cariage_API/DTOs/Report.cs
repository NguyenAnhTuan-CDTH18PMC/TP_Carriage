using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.DTOs
{
    public class Report
    { 
        public Report(int thang,decimal money)
        {
            Thang = thang;
            TongTien = money;
        }

        public int Thang { get; set; }
        public decimal TongTien { get; set; }
    }
}
