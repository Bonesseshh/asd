using System;
using System.Collections.Generic;

namespace YP2_home
{
    public partial class DishInOrder
    {
        public int IdDio { get; set; }
        public int IdDish { get; set; }
        public int IdOrder { get; set; }

        public virtual Dish IdDishNavigation { get; set; } = null!;
        public virtual Order IdOrderNavigation { get; set; } = null!;
    }
}
