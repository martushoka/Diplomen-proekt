using FCBarcelonaApp.Models.MyTeam;
using FCBarcelonaApp.Models.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Models.Game
{
    public class GameEditVM
    {
        public GameEditVM()
        {
            MyTeams = new List<MyTeamPairVM>();
            Teams = new List<TeamPairVM>();
        }
        [Key]

        public int Id { get; set; }


        [Display(Name = "Place")]

        public string Place { get; set; }
        public DateTime DateOfGame { get; set; }





        public int MyTeamId { get; set; }

        public virtual List<TeamPairVM> Teams { get; set; }




        public int TeamId { get; set; }

        public virtual List<MyTeamPairVM> MyTeams { get; set; }

        [Display(Name = "TicketQuantity")]
        public int Quantity { get; set; }

        [Display(Name = "TicketPrice")]

        public decimal Price { get; set; }

    }
}
