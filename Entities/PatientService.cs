using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Interfaces;

namespace Entities
{
    public class PatientService : Entity
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public DateTime MomentOfChoice { get; set; }
        [Required]
        public double? PriceAtSelection { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}
