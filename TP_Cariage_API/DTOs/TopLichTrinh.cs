using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.DTOs
{
    public class TopLichTrinh
    {
        public TopLichTrinh(int lichtrinh,int ve)
        {
            LichTrinhId = lichtrinh;
            tongVe = ve;
        }
        public int LichTrinhId { get; set; }
        public int tongVe { get; set; }
    }
}
