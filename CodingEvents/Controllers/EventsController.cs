using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {        
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());
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
                };
                EventData.Add(newEvent);
                return Redirect("/Events");
            }
            else
            {
                return Redirect("/Events/Add");
            }
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int id in eventIds)
            {
                EventData.Remove(id);
            }
            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Edit/{eventID}")]
        public IActionResult Edit(int eventID)
        {
            Event editEvent = EventData.GetById(eventID);
            ViewBag.eventToEdit = editEvent;
            ViewBag.title = "Edit Event" + editEvent.Name + "(id = " + editEvent.ID + ")";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventID, string name, string description)
        {
            Event editEvent = EventData.GetById(eventID);
            editEvent.Name = name;
            editEvent.Description = description;
            return Redirect("/Events");
        }
    }
}
