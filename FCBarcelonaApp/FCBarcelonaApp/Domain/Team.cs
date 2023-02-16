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

        public string Country { get; set; }
        public string Description { get; set; }

        public string Picture { get; set; }
        public virtual IEnumerable<Player> Players { get; set; } = new List<Player>();

        public virtual IEnumerable<Match> Matches { get; set; } = new List<Match>();



    }
}
