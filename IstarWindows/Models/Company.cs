using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace IstarWindows.Models
{
    public class Company
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
        }

        public int Id { get; set; }

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

        public decimal Inn { get; set; }

        public decimal Kpp { get; set; }

        public decimal Curaccount { get; set; }

        [Required]
        public string Bank { get; set; }

        public decimal Coraccount { get; set; }

        public decimal Bik { get; set; }

        [Required]
        public string Manager { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Building> Buildings { get; set; } = new HashSet<Building>();
    }
}
