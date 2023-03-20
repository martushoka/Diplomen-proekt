using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Models.MyTeam
{
    public class MyTeamPairVM
    {
        public int Id { get; set; }

        [Display(Name = "MyTeam")]

        public string Name { get; set; }
    }
}
