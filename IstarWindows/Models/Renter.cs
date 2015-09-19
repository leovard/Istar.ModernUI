using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IstarWindows.Models
{
    public class Renter
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Renter()
        {
        }

        public int Id { get; set; }

        public int Customerid { get; set; }

        public int Officeid { get; set; }

        [Required]
        public string Contract { get; set; }

        public string Occupation { get; set; }

        public decimal Total { get; set; }

        public DateTime Rentdate { get; set; }

        public DateTime? Rentend { get; set; }

        public bool Isend { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Office Office { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
