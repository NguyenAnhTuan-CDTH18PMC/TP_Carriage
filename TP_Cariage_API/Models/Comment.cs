using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Comment
    {

        public int Id { get; set; }
        public string Descreption { get; set; }
        public DateTime CreateAt { get; set; }
        public int ChuyenXesId { get; set; }
        public int DiemDanhGia { get; set; }
        public virtual ChuyenXes ChuyenXes { get; set; }

        public string AccountsId { get; set; }
        public virtual Accounts Accounts { get; set; }
    }
}
