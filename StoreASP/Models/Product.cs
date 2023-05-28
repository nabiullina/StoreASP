using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoreASP.Models
{
    public partial class Product
    {
        public Product()
        {
            PostavkaProducts = new HashSet<PostavkaProduct>();
            ProductSales = new HashSet<ProductSale>();
        }

        [DisplayName("Product's id")]
        public long IdProduct { get; set; }
        
        [DisplayName("Product's name")]
        public string NazvanieProduct { get; set; } = null!;
        
        [DisplayName("Product's description")]
        public string Opisanie { get; set; } = null!;
        
        [DisplayName("Product's pictire")]
        public string? Foto { get; set; }
        
        [DisplayName("Product's price")]
        public decimal CostSales { get; set; }
        
        [DisplayName("Product's imei")]
        public long Imei { get; set; }
        
        [DisplayName("Mark's id")]
        public long? IdMark { get; set; }
        
        [DisplayName("Category's id")]
        public long? IdCategory { get; set; }

        [DisplayName("Category")]
        public virtual Category? IdCategoryNavigation { get; set; }
        
        [DisplayName("Mark")]
        public virtual Mark? IdMarkNavigation { get; set; }
        
        [DisplayName("Products in delivery")]
        public virtual ICollection<PostavkaProduct> PostavkaProducts { get; set; }
        
        [DisplayName("Products in sales")]
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
