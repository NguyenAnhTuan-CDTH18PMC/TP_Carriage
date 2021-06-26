using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Chats
    {
        public Chats()
        {
            Messagegroups = new HashSet<Messagegroups>();
        }

        public int Id { get; set; }
        public int TrangThai { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual NhaXes NhaXe { get; set; }
        public virtual ICollection<Messagegroups> Messagegroups { get; set; }
    }
}
