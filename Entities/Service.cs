using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Interfaces;

namespace Entities
{
    public class Service : Entity
    {
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
