using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace IstarWindows.Models
{
    public class Building
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Building()
        {
        }

        public int Id { get; set; }

        public int Companyid { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        private string _phone;
        public string Phone
        {
            get { return _phone != null ? Regex.Replace(_phone, @"(\\d{1})(\\d{3})(\\d{3})(\\d{4})", "+$1 ($2) $3 $4") : _phone; }
            set { _phone = Regex.Replace(value, @"(\\d{1})(\\d{3})(\\d{3})(\\d{4})", "+$1 ($2) $3 $4"); }
        }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public virtual Company Company { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Office> Offices { get; set; } = new HashSet<Office>();

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
    }
}
