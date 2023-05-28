using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Client's id")]
        public long IdClient { get; set; }
        
        [DisplayName("Client's name")]
        public string FioClient { get; set; } = null!;
        
        [DisplayName("Client's number")]
        public long Number { get; set; }
        
        [UIHint("EmailAddress")]
        [DisplayName("Client's email")]
        public string? Email { get; set; }

        [DisplayName("Client's purchases")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
