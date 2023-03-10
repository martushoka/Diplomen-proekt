using FCBarcelonaApp.Abstraction;
using FCBarcelonaApp.Data;
using FCBarcelonaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace FCBarcelonaApp.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;

        public GameService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string place, DateTime dateOfGame, string description, int myteamId, int teamId, int quantity, decimal price)
        {
            Game item = new Game
            {
                Place = place,
                DateOfGame = dateOfGame,
                MyTeam = _context.MyTeams.Find(myteamId),
                Team = _context.Teams.Find(teamId),
                Description = description,



            };

            _context.Games.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Game GetGameById(int gameId)
        {
            return _context.Games.Find(gameId);
        }

        public List<Game> GetGames()
        {
            List<Game> games = _context.Games.ToList();
            return games;
        }

        public List<Game> GetGames(string searchStringMyTeamName, string searchStringTeamName)
        {
            List<Game> games = _context.Games.ToList();
            if (!String.IsNullOrEmpty(searchStringMyTeamName) && !String.IsNullOrEmpty(searchStringTeamName))
            {
                games = games.Where(x => x.MyTeam.MyTeamName.ToLower().Contains(searchStringMyTeamName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringTeamName))
            {
                games = games.Where(x => x.Team.TeamName.ToLower().Contains(searchStringTeamName.ToLower())).ToList();
            }
            return games;
        }

        public bool RemoveById(int gameId)
        {
            var game = GetGameById(gameId);
            if (game == default(Game))
            {
                return false;
            }
            _context.Remove(game);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int gameId, string place, DateTime dateOfGame, string description, int myteamId, int teamId, int quantity, decimal price)
        {
            var game = GetGameById(gameId);
            if (game == default(Game))
            {
                return false;
            }


            game.DateOfGame = dateOfGame;
            game.Place = place;
            game.Description = description;
            game.TeamId = teamId;
            _context.Update(game);
            return _context.SaveChanges() != 0;
        }

        
    }
    
}
