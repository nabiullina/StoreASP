using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoreASP.Models
{
    public partial class Mark
    {
        public Mark()
        {
            Products = new HashSet<Product>();
        }

        [DisplayName("Mark's id")]
        public long IdMark { get; set; }
        
        [DisplayName("Mark's name")]
        public string NazvanieMark { get; set; } = null!;

        [DisplayName("Mark's products")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
