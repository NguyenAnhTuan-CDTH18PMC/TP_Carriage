using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Chats
    {

        public int Id { get; set; }
        public int TrangThai { get; set; }

        public int NhaXeId { get; set; }
        public virtual NhaXes NhaXes { get; set; }
    }
}
