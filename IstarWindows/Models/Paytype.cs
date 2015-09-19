using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IstarWindows.Models
{
    public class Paytype
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paytype()
        {
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
