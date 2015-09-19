using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IstarWindows.Models
{
    public class Office
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Office()
        {
        }

        public int Id { get; set; }

        public int Buildingid { get; set; }

        [Required]
        public string Title { get; set; }

        public decimal Area { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }

        public virtual Building Building { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renter> Renters { get; set; } = new HashSet<Renter>();
    }
}
