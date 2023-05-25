using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class PostavkaProduct
    {
        public decimal IdPostavka { get; set; }
        public decimal IdProduct { get; set; }
        public decimal KolVo { get; set; }

        public virtual Postavka IdPostavkaNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
