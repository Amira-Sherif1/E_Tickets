using E_Tickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    public class CinemaController : Controller
    {
        ApplicationDbContext dbContext=new ApplicationDbContext();
        public IActionResult Index()
        {
            var cinemas = dbContext.Cinemas.ToList();
            return View(cinemas);
        }
        public IActionResult DisplayMovies(int Id)
        {
           var movies=dbContext.Movies.Include(e=>e.Category).Include(e=>e.Cinema).Where(e=>e.CinemaId==Id).ToList();
            return View(movies);
        }

    }
}
