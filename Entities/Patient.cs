using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Interfaces;

namespace Entities
{
    public class Patient : Entity
    {
        [Required]
        public int LocalityId { get; set; }
        [Required, MaxLength(35)]
        public string Name { get; set; }
        [Required, MaxLength(13)]
        public string Pin { get; set; }
        public string Adress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        public string ReprezentativeName { get; set; }
        public string ReprezentativePin { get; set; }
        [Required]
        public DateTime RegistreDateTime { get; set; }
        
        [ForeignKey("LocalityId")]
        public Locality Locality { get; set; }
    }
}
