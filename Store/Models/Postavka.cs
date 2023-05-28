using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoreASP.Models
{
    public partial class Postavka
    {
        public Postavka()
        {
            PostavkaProducts = new HashSet<PostavkaProduct>();
        }

        [DisplayName("Delivery's id")]
        public long IdPostavka { get; set; }
        
        [DisplayName("Delivery's date")]
        public DateTime? DataPostavka { get; set; }
        
        [DisplayName("Sum of purchases")]
        public decimal CostZakupki { get; set; }
        
        [DisplayName("Delivery's status")]
        public string? StatusPostavka { get; set; }
        
        [DisplayName("Provider's id")]
        public long? IdProvider { get; set; }

        [DisplayName("Provider")]
        public virtual Pprovider? IdProviderNavigation { get; set; }
        
        [DisplayName("Products in delivery")]
        public virtual ICollection<PostavkaProduct> PostavkaProducts { get; set; }
    }
}
