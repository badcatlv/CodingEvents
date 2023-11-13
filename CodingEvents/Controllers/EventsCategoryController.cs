using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;
using System.Xml.Linq;


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

        [HttpGet]
        //[Route("EventCategory/Create")]
        public IActionResult Create() 
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddEventCategoryViewModel addEventCategoryViewModel) 
        {
            if (ModelState.IsValid) 
            { 
                EventCategory eventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name,
                };
                context.Categories.Add(eventCategory);
                context.SaveChanges();
                return Redirect("/EventsCategory");
            }
            return View("Create", addEventCategoryViewModel);
            //else
            //{
            //    return Redirect("/EventsCategory");
            //}
        }
    }
}
