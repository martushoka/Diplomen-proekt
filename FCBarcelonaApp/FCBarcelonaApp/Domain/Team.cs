using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Domain
{
    public class Team
    {
        public int Id { get; set; }
        [Required]

        public string TeamName { get; set; }
        public string Picture { get; set; }
        public virtual IEnumerable<Game> Games { get; set; } = new List<Game>();



    }
}
