using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoreASP.Models
{
    public partial class Pprovider
    {
        public Pprovider()
        {
            Postavkas = new HashSet<Postavka>();
        }

        [DisplayName("Provider's id")]
        public long IdProvider { get; set; }
        
        [DisplayName("Provider's company")]
        public string? Nazvanie { get; set; }
        
        [DisplayName("Provider's name'")]
        public string Fio { get; set; } = null!;
        
        [DisplayName("Provider's phone number")]
        public long Number { get; set; }
        
        [DisplayName("Provider's address")]
        public string Adress { get; set; } = null!;

        [DisplayName("Provider's deliveries")]
        public virtual ICollection<Postavka> Postavkas { get; set; }
    }
}
