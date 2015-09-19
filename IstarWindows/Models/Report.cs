using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IstarWindows.Models
{
    public class Report
    {
        public int Id { get; set; }

        public int Counterid { get; set; }

        public DateTime Reportdate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(65)]
        public string Period { get; set; }

        public decimal Newdata { get; set; }

        public decimal Prevdata { get; set; }

        [Required]
        [StringLength(50)]
        public string Point { get; set; }

        public virtual Counter Counter { get; set; }
    }
}
