using System;
using System.Collections.Generic;

namespace YP2_home
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int IdUser { get; set; }
        public string LoginUs { get; set; } = null!;
        public string PasswordUs { get; set; } = null!;
        public int IdRole { get; set; }
        public string NameUser { get; set; } = null!;

        public virtual Role IdRoleNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
