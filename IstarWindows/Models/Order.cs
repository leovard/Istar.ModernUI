using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IstarWindows.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Renterid { get; set; }

        public int Paytypeid { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime Orderdate { get; set; }

        public decimal Total { get; set; }

        public decimal Paidtotal { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool? Paid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(65)]
        public string Period { get; set; }

        public virtual Paytype Paytype { get; set; }

        public virtual Renter Renter { get; set; }
    }
}
