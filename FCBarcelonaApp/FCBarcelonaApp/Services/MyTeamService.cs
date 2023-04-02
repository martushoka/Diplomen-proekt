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

       
        public List<Game> GetGameByMyTeams(int myteamId)
        {
            return _context.Games
                  .Where(x => x.MyTeamId == myteamId)
                 .ToList();
        }

        public MyTeam GetMyTeamById(int myteamId)
        {
            return _context.MyTeams.Find(myteamId);
        }

        public List<MyTeam> GetMyTeams()
        {
            List<MyTeam> myteams = _context.MyTeams.ToList();
            return myteams;
        }

       

    }
}
