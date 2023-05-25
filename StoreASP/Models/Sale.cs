using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class Sale
    {
        public Sale()
        {
            ProductSales = new HashSet<ProductSale>();
        }

        public decimal IdSale { get; set; }
        public DateTime DataS { get; set; }
        public string Oplata { get; set; } = null!;
        public decimal Itogo { get; set; }
        public decimal? IdClient { get; set; }
        public decimal? IdDiscount { get; set; }

        public virtual Client? IdClientNavigation { get; set; }
        public virtual Discount? IdDiscountNavigation { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
