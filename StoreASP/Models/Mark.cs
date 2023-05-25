using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class Mark
    {
        public Mark()
        {
            Products = new HashSet<Product>();
        }

        public decimal IdMark { get; set; }
        public string NazvanieMark { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
