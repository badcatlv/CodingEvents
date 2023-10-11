using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<string> Events = new()
            { "Wedding", "Birthday", "Funeral" };
            ViewBag.events = Events;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
