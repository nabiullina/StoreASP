using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Sales = new HashSet<Sale>();
        }

        public decimal IdDiscount { get; set; }
        public string NazvanieSkidki { get; set; } = null!;
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public decimal DiscountSum { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
