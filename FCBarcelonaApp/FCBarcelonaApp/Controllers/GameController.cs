using FCBarcelonaApp.Abstraction;
using FCBarcelonaApp.Domain;
using FCBarcelonaApp.Models.Game;
using FCBarcelonaApp.Models.MyTeam;
using FCBarcelonaApp.Models.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Controllers
{
    [Authorize(Roles = "Administrator")]
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
        [AllowAnonymous]
        public ActionResult Index(string searchStringMyTeamName, string searchStringTeamName)
        {
            List<GameIndexVM> games = _gameService.GetGames(searchStringMyTeamName, searchStringTeamName)
            .Select(game => new GameIndexVM
            {
                Id = game.Id,
                Place = game.Place,
                DateOfGame=game.DateOfGame,
                MyTeamId = game.MyTeamId,
                MyTeamName = game.MyTeam.MyTeamName,
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
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Game game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            GameDetailsVM details = new GameDetailsVM()
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
            return View(details);


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
                var createdId = _gameService.Create(game.Place,game.DateOfGame, game.MyTeamName,
                    game.TeamName, game.Quantity, game.Price);

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
            updatedGame.MyTeams = _myTeamService.GetMyTeams()
              .Select(b => new MyTeamPairVM()
              {
                  Id = b.Id,
                  Name = b.MyTeamName
              })
              .ToList();
            
            updatedGame.Teams = _teamService.GetTeams()
              .Select(c => new TeamPairVM()
              {
                  Id = c.Id,
                  Name = c.TeamName
              })
              .ToList();
            return View(updatedGame);


            
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEditVM game)
        {
            if (ModelState.IsValid)
            {
                var updated = _gameService.Update(game.Id,game.Place, game.DateOfGame, game.MyTeamId,
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
            Game game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            GameDeleteVM delete = new GameDeleteVM()
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

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _gameService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
