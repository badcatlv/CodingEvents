using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //instance of Dbcontext
        private EventDbContext context;
        public EventsController (EventDbContext dbcontext)
        {
            context = dbcontext;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> events = context.Events.Include(e => e.Category).ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<EventCategory> categories = context.Categories.ToList();
            AddEventViewModel addEventViewModel = new AddEventViewModel(categories);
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory category = context.Categories.Find(addEventViewModel.Categories);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Category = category
                };
                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/Events");
            }
            return View(addEventViewModel);
            //else
            //{
            //    return Redirect("/Events/Add");
            //}
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int id in eventIds)
            {
                Event? theEvent = context.Events.Find(id);
                context.Events.Remove(theEvent);
            }
            context.SaveChanges();
            return Redirect("/Events");
        }

    }
}
