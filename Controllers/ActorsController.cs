using E_Tickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class ActorsController : Controller
    {
        ApplicationDbContext dbContext=new ApplicationDbContext();
        public IActionResult Index(int Id)
        {
            var actor = dbContext.Actors.Find(Id);
            return View(actor);
        }
    }
}
