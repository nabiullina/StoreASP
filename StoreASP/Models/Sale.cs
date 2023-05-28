using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoreASP.Models
{
    public partial class Sale
    {
        public Sale()
        {
            ProductSales = new HashSet<ProductSale>();
        }

        [DisplayName("Sale's id")]
        public long IdSale { get; set; }
        
        [DisplayName("Sale's date")]
        public DateTime DataS { get; set; }
        
        [DisplayName("Payment method")]
        public string Oplata { get; set; } = null!;
        
        [DisplayName("Sum")]
        public decimal Itogo { get; set; }
        
        [DisplayName("Client's id")]
        public long? IdClient { get; set; }
        

        [DisplayName("Client")]
        public virtual Client? IdClientNavigation { get; set; }

        [DisplayName("Product's sales")]
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
