using E_Tickets.Data;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_Tickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ApplicationDbContext dbcontext = new ApplicationDbContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var movies = dbcontext.Movies.Include(e=>e.Cinema).Include(e=>e.Category).ToList();
            return View(movies);
        }
        public IActionResult Details(int Id)
        {
           
            var movie = dbcontext.Movies.Include(e=>e.Category).Include(e => e.Cinema).Include(e => e.Actors).FirstOrDefault(e=>e.Id==Id);
            return View(movie);
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
