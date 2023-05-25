using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class Product
    {
        public Product()
        {
            PostavkaProducts = new HashSet<PostavkaProduct>();
            ProductSales = new HashSet<ProductSale>();
        }

        public decimal IdProduct { get; set; }
        public string NazvanieProduct { get; set; } = null!;
        public string Opisanie { get; set; } = null!;
        public string? Foto { get; set; }
        public decimal CostSales { get; set; }
        public decimal Imei { get; set; }
        public decimal? IdMark { get; set; }
        public decimal? IdCategory { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }
        public virtual Mark? IdMarkNavigation { get; set; }
        public virtual ICollection<PostavkaProduct> PostavkaProducts { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
