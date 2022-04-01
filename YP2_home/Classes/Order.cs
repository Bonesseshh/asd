using System;
using System.Collections.Generic;

namespace YP2_home
{
    public partial class Order
    {
        public Order()
        {
            DishInOrders = new HashSet<DishInOrder>();
        }

        public int OrderId { get; set; }
        public int IdStatus { get; set; }
        public int IdUsers { get; set; }
        public decimal? Sum { get; set; }

        public virtual Status IdStatusNavigation { get; set; } = null!;
        public virtual User IdUsersNavigation { get; set; } = null!;
        public virtual ICollection<DishInOrder> DishInOrders { get; set; }
    }
}
