using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;


namespace CodingEvents.Controllers
{
    public class EventsCategoryController : Controller
    {
        private EventDbContext context;
        public EventsCategoryController(EventDbContext dbcontext)
        {
            context = dbcontext;
        }
        //Get:/<controller>/
        public IActionResult Index()
        {
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }
    }
}
