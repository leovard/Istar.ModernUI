using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IstarWindows.Models
{
    public class Counter
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Counter()
        {
        }

        public int Id { get; set; }

        public int Serviceid { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime Setdate { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public virtual Service Service { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; } = new HashSet<Report>();
    }
}
