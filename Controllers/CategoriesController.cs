using E_Tickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext dbContext=new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories=dbContext.Categories.ToList();
            return View(categories);
        }
        public IActionResult DisplayMovies(int Id)
        {
            var Movies = dbContext.Movies. Include(e=>e.Category).Include(e => e.Cinema).Where(e=>e.CategoryId==Id).ToList();
            return View(Movies);
        }

    }
}
