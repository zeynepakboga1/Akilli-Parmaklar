using Akilli_Parmaklar.Models;
using Akilli_Parmaklar.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Akilli_Parmaklar.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;
        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var games = _appDbContext.Games.ToList();
            foreach (var game in games)
            {

                Console.WriteLine(game.Name);
            }
            ViewBag.Game = games[0];
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginUser request)
        {
            User? user = _appDbContext.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if (user == null)
            {
                Console.WriteLine("Kullanıcı bulunamadı");
            }
            if (user.Password == request.Password)
            {
                Console.WriteLine("Kullanıcı giriş yaptı");
                return View();
            }
            else
            {
                Console.WriteLine("Şifre yanlış");
                return View();
            }

        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterUser request)
        {
            User? user = _appDbContext.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if (user != null)
            {
                Console.WriteLine("Bu kullanıcı adına ait bir hesap daha önce oluşturuldu");
                ViewBag.ErrorMessage = "Bu kullanıcı adına ait bir hesap daha önce oluşturuldu";
                return View();
            }
            User createUser = new User();
            createUser.Name = request.Name;
            createUser.Email = request.Email;
            createUser.Password = request.Password;
            createUser.SurName = request.SurName;
            createUser.UserName = request.UserName;
            createUser.Age = request.Age;
            _appDbContext.Users.Add(createUser);
            _appDbContext.SaveChanges();
            return View();
        }

        [HttpGet("Privacy")]
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
