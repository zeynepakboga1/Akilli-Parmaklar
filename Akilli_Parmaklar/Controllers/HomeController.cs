using Akilli_Parmaklar.Models;
using Akilli_Parmaklar.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Akilli_Parmaklar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;
        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddGame(CreateGameRequest game)
        {
            return View();

        }
        public IActionResult Register(RegisterUser request)
        {
            User user = new User();
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.SurName = request.SurName;
            user.UserName = request.UserName;
            user.Age = request.Age;
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges(); 

        }
        public IActionResult Games()
        {
            var games = _appDbContext.Games.ToList();
            ViewBag.Games = games;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
