using System;
using System.Collections.Generic;

namespace YP2_home
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string NameRole { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
