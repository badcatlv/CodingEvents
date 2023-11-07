using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;

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
            List<Event> events = context.Events.ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Location = addEventViewModel.Location,
                    NumberOfAttendees = addEventViewModel.NumberOfAttendees,
                };
                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/Events");
            }
            else
            {
                return Redirect("/Events/Add");
            }
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

        [HttpGet]
        [Route("/Events/Edit/{eventID}")]
        public IActionResult Edit(int eventID)
        {
            Event? editEvent = context.Events.Find(eventID);
            ViewBag.eventToEdit = editEvent;
            ViewBag.title = "Edit Event" + editEvent.Name + "(id = " + editEvent.Id + ")";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventID, string name, string description)
        {
            Event? editEvent = context.Events.Find(eventID);
            editEvent.Name = name;
            editEvent.Description = description;
            return Redirect("/Events");
        }
    }
}
