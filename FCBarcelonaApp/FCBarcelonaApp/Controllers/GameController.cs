using FCBarcelonaApp.Abstraction;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
