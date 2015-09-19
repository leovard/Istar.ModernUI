using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace IstarWindows.Models
{
    public class Customer
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
        }

        public int Id { get; set; }

        public int Buildingid { get; set; }

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

        public string Email { get; set; }

        [Required]
        public string Contact { get; set; }

        public virtual Building Building { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renter> Renters { get; set; } = new HashSet<Renter>();
    }
}
