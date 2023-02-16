using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Domain
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        public string Picture { get; set; }
        public string Position { get; set; }

       

        public string Country { get; set; }
        [Required]


        public int TeamId { get; set; }
        public virtual Team Team { get; set; }


    }
}
