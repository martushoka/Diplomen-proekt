using FCBarcelonaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Abstraction
{
    public interface IGameService
    {
        bool Create(string place, DateTime dateOfGame, string description, int myteamId, int teamId, int quantity, decimal price);

        bool Update(int gameId, string place, DateTime dateOfGame, string description, int myteamId, int teamId, int quantity, decimal price);

        List<Game> GetGames();

        Game GetGameById(int gameId);

        bool RemoveById(int gameId);

        List<Game> GetGames(string searchStringMyTeamName, string searchStringTeamName);
    }
}
