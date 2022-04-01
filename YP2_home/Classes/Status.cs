using System;
using System.Collections.Generic;

namespace YP2_home
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string NameStatus { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
