using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Interfaces;

namespace Entities
{
    public class Locality : Entity
    {
        public Locality()
        {
            
        }

        public Locality(string name, int countyId, int? id = null)
        {
            if (id != null)
            {
                Id = (int) id;
            }
            Name = name;
            CountyId = countyId;
        }

        [Required]
        public string Name { get; set; }    
        [Required]
        public int CountyId { get; set; }

        [ForeignKey("CountyId")]
        public County County { get; set; }
    }
}
