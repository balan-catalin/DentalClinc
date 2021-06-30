using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Interfaces;

namespace Entities
{
    public class County : Entity
    {
        public County()
        {
        }

        public County(string name, int? id = null)
        {
            if (id != null)
            {
                this.Id = (int)id;
            }
            this.Name = name;
        }

        [Required]
        public string Name { get; set; }
    }
}
