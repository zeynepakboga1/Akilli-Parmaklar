using Akilli_Parmaklar.Models;
using Akilli_Parmaklar.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Akilli_Parmaklar.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly AppDbContext _appDbContext;
        public GameController(ILogger<GameController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var games = _appDbContext.Games.ToList();
            ViewBag.Games = games;
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(CreateGameRequest request)
        {
            Game game = new Game();
            game.Name = request.Name;
            game.Description = request.Description;

            _appDbContext.Games.Add(game);
            _appDbContext.SaveChanges();
            return View();

        }
    }
}
