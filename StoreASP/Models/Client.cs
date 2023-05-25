using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreASP.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        [Required]
        public decimal IdClient { get; set; }
        public string FioClient { get; set; } = null!;
        public long Number { get; set; }
        [UIHint("EmailAddress")]
        public string? Email { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
