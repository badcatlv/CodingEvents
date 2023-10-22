using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {        
        public IActionResult Index()
        {

            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            
            return Redirect("/Events");
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
