using FCBarcelonaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Abstraction
{
    public interface ITeamService
    {
        List<Team> GetTeams();
        Team GetTeamById(int teamId);
        List<Game> GetGamesByTeams(int teamId);
    }
}
