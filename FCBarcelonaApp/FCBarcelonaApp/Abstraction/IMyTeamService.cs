using FCBarcelonaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Abstraction
{
     public interface IMyTeamService
    {
        List<MyTeam> GetMyTeams();
        MyTeam GetMyTeamById(int teamId);
        List<Game> GetGameByMyTeams(int teamId);
    }
}
