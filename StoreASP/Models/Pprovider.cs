using System;
using System.Collections.Generic;

namespace StoreASP.Models
{
    public partial class Pprovider
    {
        public Pprovider()
        {
            Postavkas = new HashSet<Postavka>();
        }

        public decimal IdProvider { get; set; }
        public string? Nazvanie { get; set; }
        public string Fio { get; set; } = null!;
        public long Number { get; set; }
        public string Adress { get; set; } = null!;

        public virtual ICollection<Postavka> Postavkas { get; set; }
    }
}
