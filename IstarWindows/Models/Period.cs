using System;
using System.ComponentModel.DataAnnotations;

namespace IstarWindows.Models
{
    public class Period
    {
        public int Id { get; set; }

        public DateTime Workingstart { get; set; }

        [Required]
        public string Workingperiod { get; set; }
    }
}
