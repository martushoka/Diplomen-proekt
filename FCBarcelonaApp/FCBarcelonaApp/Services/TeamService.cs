using FCBarcelonaApp.Abstraction;
using FCBarcelonaApp.Data;
using FCBarcelonaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Game> GetGamesByTeams(int teamId)
        {
            return _context.Games
                  .Where(x => x.TeamId == teamId)
                 .ToList();
        }

        public Team GetTeamById(int teamId)
        {
            return _context.Teams.Find(teamId);
        }

        public List<Team> GetTeams()
        {
            List<Team> teams = _context.Teams.ToList();
            return teams;
        }

       
    }
}
