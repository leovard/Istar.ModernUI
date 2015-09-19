using System;
using System.ComponentModel.DataAnnotations;

namespace IstarWindows.Models
{
    public class Job
    {
        public int Id { get; set; }

        public DateTime Jobdate { get; set; }

        [Required]
        public string Jobtitle { get; set; }

        [Required]
        public string Jobtext { get; set; }

        public bool Ismonthly { get; set; }

        public bool Iscomplete { get; set; }
    }
}
