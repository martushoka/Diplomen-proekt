using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime DateOfGame { get; set; }
        public string Place { get; set; }

        
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public string TeamName { get; set; }
        public string TeamPicture { get; set; }
        public int MyTeamId { get; set; }
        public virtual MyTeam MyTeam { get; set; }
        public string MyTeamName { get; set; }
        public string MyTeamPicture { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

