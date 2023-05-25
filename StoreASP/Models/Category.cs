using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public decimal IdCategory { get; set; }
        public string NazvanieCategory { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
