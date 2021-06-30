using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string HinhAnh { get; set; }
        public int TrangThai { get; set; }
    }
}
