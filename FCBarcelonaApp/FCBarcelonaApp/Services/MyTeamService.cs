using FCBarcelonaApp.Abstraction;
using FCBarcelonaApp.Data;
using FCBarcelonaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Services
{
    public class MyTeamService: IMyTeamService
    {
        private readonly ApplicationDbContext _context;

        public MyTeamService(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public List<Game> GetGameByMyTeams(int teamId)
        {
            return _context.Games
                  .Where(x => x.MyTeamId == teamId)
                 .ToList();
        }

        public MyTeam GetMyTeamById(int teamId)
        {
            return _context.MyTeams.Find(teamId);
        }

        public List<MyTeam> GetMyTeams()
        {
            List<MyTeam> teams = _context.MyTeams.ToList();
            return teams;
        }

       

    }
}
