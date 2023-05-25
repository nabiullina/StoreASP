using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class ProductSale
    {
        public decimal IdProduct { get; set; }
        public decimal IdSale { get; set; }
        public decimal KolVo2 { get; set; }

        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual Sale IdSaleNavigation { get; set; } = null!;
    }
}
