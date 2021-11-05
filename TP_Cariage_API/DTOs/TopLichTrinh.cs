using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.DTOs
{
    public class TopLichTrinh
    {
        public TopLichTrinh(int lichtrinh,int ve,string diadiem)
        {
            LichTrinhId = lichtrinh;
            tongVe = ve;
            DiaDiem = diadiem;
        }
        public int LichTrinhId { get; set; }
        public int tongVe { get; set; }
        public string DiaDiem { get; set; }
    }
}
