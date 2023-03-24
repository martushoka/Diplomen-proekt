using FCBarcelonaApp.Abstraction;
using FCBarcelonaApp.Domain;
using FCBarcelonaApp.Models.Game;
using FCBarcelonaApp.Models.MyTeam;
using FCBarcelonaApp.Models.Team;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IMyTeamService _myTeamService;
        private readonly ITeamService _teamService;

        public GameController(IGameService gameService, IMyTeamService myTeamService, ITeamService teamService)

        {
            this._gameService = gameService;
            this._myTeamService = myTeamService;
            this._teamService = teamService;
        }
        // GET: GameController
        public ActionResult Index(string searchStringMyTeamName, string searchStringTeamName)
        {
            List<GameIndexVM> games = _gameService.GetGames(searchStringMyTeamName, searchStringTeamName)
            .Select(game => new GameIndexVM
            {
                Id = game.Id,
                Place = game.Place,
                DateOfGame=game.DateOfGame,
                MyTeamId = game.MyTeamId,
                MyTeamName=game.MyTeam.MyTeamName,
                MyTeamPicture=game.MyTeam.Picture,
                TeamId = game.TeamId,
                TeamName=game.Team.TeamName,
                TeamPicture = game.Team.Picture,
                Quantity = game.Quantity,
                Price = game.Price,


            }).ToList();
            return this.View(games);

        }
        

        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            Game item = _gameService.GetGameById(id);
            if (item == null)
            {
                return NotFound();
            }
            GameDetailsVM game = new GameDetailsVM()
            {
                Id = game.Id,
                Place = game.Place,
                DateOfGame = game.DateOfGame,
                MyTeamId = game.MyTeamId,
                MyTeamName = game.MyTeamName,
                MyTeamPicture = game.MyTeamPicture,
                TeamId = game.TeamId,
                TeamName = game.TeamName,
                TeamPicture = game.TeamPicture,
                Quantity = game.Quantity,
                Price = game.Price,

            };
            return View(game);


        }

        // GET: GameController/Create
        public ActionResult Create()
        {
            var game = new GameCreateVM();
            game.MyTeams = _myTeamService.GetMyTeams()
                .Select(x => new MyTeamPairVM()
                {
                    Id = x.Id,
                    Name = x.MyTeamName

                }).ToList();

            game.Teams = _teamService.GetTeams()
              .Select(x => new TeamPairVM()
              {
                  Id = x.Id,
                  Name = x.TeamName

              }).ToList();
            return View(game);
        }

        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] GameCreateVM game)
        {

            if (ModelState.IsValid)
            {
                var createdId = _gameService.Create(game.Place,game.DateOfGame, game.MyTeamId,
                    game.TeamId, game.Quantity, game.Price);

                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        // GET: GameController/Edit/5
        public ActionResult Edit(int id)
        {
            Game game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }

            GameEditVM updatedGame = new GameEditVM()
            {
                Id = game.Id,
                Place = game.Place,
                DateOfGame = game.DateOfGame,
                MyTeamId = game.MyTeamId,
                
                TeamId = game.TeamId,
                
                Quantity = game.Quantity,
                Price = game.Price,
            };
            updatedGame.MyTeams = _myteamService.GetMyTeams()
              .Select(b => new MyTeamPairVM()
              {
                  Id = b.Id,
                  Name = b.MyTeamName
              })
            .ToList();
            return View(updatedGame);
            updatedGame.Teams = _teamService.GetTeams()
              .Select(b => new TeamPairVM()
              {
                  Id = b.Id,
                  Name = b.TeamName
              })
            .ToList();

            
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEditVM game)
        {
            if (ModelState.IsValid)
            {
                var updated = _gameService.Update(game.Place, game.DateOfGame, game.MyTeamId,
                    game.TeamId, game.Quantity, game.Price);

                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(game);
        }

        // GET: GameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
