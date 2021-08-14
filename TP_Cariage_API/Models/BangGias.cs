using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.Models
{
    public class BangGias
    {
        public int Id { get; set; }
        public decimal GiaVe { get; set; }
        public int TrangThai { get; set; }
        public int NhaXesId { get; set; }
        public virtual NhaXes NhaXes { get; set; }

        public int LoaiXesId { get; set; }
        public virtual LoaiXes LoaiXes { get; set; }

        public int LichTrinhsId { get; set; }
        public virtual LichTrinhs LichTrinhs { get; set; }
    }
}
