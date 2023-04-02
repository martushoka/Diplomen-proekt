using FCBarcelonaApp.Data;
using FCBarcelonaApp.Domain;
using FCBarcelonaApp.Models.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Controllers
{
    public class OrderController : Controller
    {

        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            this._context = context;
        }
        
        public ActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            List<OrderIndexVM> orders = _context
                .Orders
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    GameId = x.GameId,
                    DateOfGame = x.Game.DateOfGame,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    TotalPrice = x.TotalPrice,
                }).ToList();
            return View(orders);
        }

        public IActionResult MyOrders(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null)
            {
                return null;
            }
            List<OrderIndexVM> orders = _context
                .Orders
                .Where(x => x.UserId == user.Id)
                .Select(x => new OrderIndexVM
                {
                Id = x.Id,
                OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                UserId = x.UserId,
                User = x.User.UserName,
                GameId = x.GameId,
                DateOfGame = x.Game.DateOfGame,
                
                Quantity = x.Quantity,
                Price = x.Price,
                TotalPrice = x.TotalPrice,
            }).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.Game.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return this.View(orders);

        }


        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create(int gameId, int quantity)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var game = this._context.Games.SingleOrDefault(x => x.Id == gameId);

            if (user == null || game == null || game.Quantity < quantity)
            {
                return this.RedirectToAction("Index", "Game");
            }
            OrderConfirmVM orderForDb = new OrderConfirmVM
            {
                UserId = userId,
                User = user.UserName,
                GameId = gameId,
                


                Quantity = quantity,
                Price = game.Price,
                
                TotalPrice = quantity * game.Price 
            };
            return View(orderForDb);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderConfirmVM bindingModel)
        {
            if (ModelState.IsValid)
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _context.Users.SingleOrDefault(u => u.Id == userId);
                var game = this._context.Games.SingleOrDefault(x => x.Id == bindingModel.GameId);

                if (user == null || game  == null || bindingModel.Quantity < bindingModel.Quantity || bindingModel.Quantity == 0)
                {
                    return this.RedirectToAction("Index", "Game");
                }
                Order orderForDb = new Order
                {
                    OrderDate = DateTime.UtcNow,
                    GameId = bindingModel.GameId,
                    UserId = userId,
                    Quantity = bindingModel.Quantity,
                    Price = game.Price,
                    
                };
                game.Quantity -= bindingModel.Quantity;
                this._context.Games.Update(game);
                this._context.Orders.Add(orderForDb);
                this._context.SaveChanges();
            }
            return this.RedirectToAction("Index", "Game");
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
