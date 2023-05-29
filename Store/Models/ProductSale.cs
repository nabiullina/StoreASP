using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreASP.Models
{
    public partial class ProductSale
    {
        [DisplayName("Product's id")]
        public long IdProduct { get; set; }
        
        [DisplayName("Sale's id")]
        public long IdSale { get; set; }
        
        [DisplayName("Amount")]
        [Range(1, 10)]
        public long KolVo2 { get; set; }

        [DisplayName("Product")]
        public virtual Product? IdProductNavigation { get; set; } = null!;
        
        [DisplayName("Sale")]
        public virtual Sale? IdSaleNavigation { get; set; } = null!;
    }
}
