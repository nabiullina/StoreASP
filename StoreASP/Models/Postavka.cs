using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class Postavka
    {
        public Postavka()
        {
            PostavkaProducts = new HashSet<PostavkaProduct>();
        }

        public decimal IdPostavka { get; set; }
        public DateTime? DataPostavka { get; set; }
        public decimal CostZakupki { get; set; }
        public string? StatusPostavka { get; set; }
        public decimal? IdProvider { get; set; }

        public virtual Pprovider? IdProviderNavigation { get; set; }
        public virtual ICollection<PostavkaProduct> PostavkaProducts { get; set; }
    }
}
