using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Interfaces;

namespace Entities
{
    public class PatientAllergy : Entity
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int AllergyId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        [ForeignKey("AllergyId")]
        public Allergy Allergy { get; set; } 
    }
}
