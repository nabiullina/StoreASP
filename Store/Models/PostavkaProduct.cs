using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoreASP.Models
{
    public partial class PostavkaProduct
    {
        [DisplayName("Delivery's id")]
        public long IdPostavka { get; set; }
        
        [DisplayName("Product's id")]
        public long IdProduct { get; set; }
        
        [DisplayName("Amount")]
        public long KolVo { get; set; }

        [DisplayName("Delivery")]
        public virtual Postavka IdPostavkaNavigation { get; set; } = null!;
        
        [DisplayName("Product")]
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
