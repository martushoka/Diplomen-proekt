using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Models.Game
{
    public class GameDetailsVM
    {
        [Key]

        public int Id { get; set; }

        public DateTime DateOfGame { get; set; }


        public string Place { get; set; }


        public int TeamId { get; set; }


        [Display(Name = "Away Team")]
        public string TeamName { get; set; }
        [Display(Name = "Emblem")]
        public string TeamPicture { get; set; }
        public int MyTeamId { get; set; }


        [Display(Name = "Home Team")]
        public string MyTeamName { get; set; }
        [Display(Name = "Emblem")]
        public string MyTeamPicture { get; set; }


        [Display(Name = "Ticket Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Ticket Price")]
        public decimal Price { get; set; }



    }
}

