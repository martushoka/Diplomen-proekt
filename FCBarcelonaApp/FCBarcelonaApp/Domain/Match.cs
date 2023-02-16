using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Domain
{
    public class Match
    {
        public int Id { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]

        public DateTime DateOfMatch { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

      

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        [Required]

        [Range(0,500)]

        public int Quantity { get; set; }
        [Required]

        [Range(0,1000)]
        public decimal Price { get; set; }


    }
}

