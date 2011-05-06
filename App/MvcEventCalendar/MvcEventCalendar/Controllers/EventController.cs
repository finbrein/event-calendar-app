using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEventCalendar.Models;
using PagedList;

namespace MvcEventCalendar.Controllers
{
    public class EventController : Controller
    {
        EventCalendarEntities storeDB = new EventCalendarEntities();
        //
        // GET: /Event/
        public ViewResult Index(string currentFilter, string searchString, string searchCategory, string searchPlace, string datepicker1, string datepicker2, int? page)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString;

            var theEvents = from s in storeDB.Events
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                theEvents = theEvents.Where(s => s.Title.Contains(searchString.ToUpper())
                                       );
            }
            theEvents = theEvents.OrderBy(s => s.Title);

            int pageSize = 6;
            int pageIndex = (page ?? 1) - 1;

            return View(theEvents.ToPagedList(pageIndex, pageSize));
        }

        //
        // GET: /Event/Browse
        public ActionResult Browse(int category)
        {

            // Retrieve Category and its Associated Events from database
            var categoryModel = storeDB.Categories.Include("Events").Single(g => g.CategoryId == category);
            return View(categoryModel);
        }
        //
        // GET: /Event/Details
        public ActionResult Details(int id)
        {
            var cevent = storeDB.Events.Find(id);

            return View(cevent);
        }

        //
        // GET: /Event/CategoryMenu
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            int id = 400;
            ViewBag.Categories = storeDB.Categories.OrderBy(g => g.Name).ToList();
            var cevent = storeDB.Events.Single(a => a.EventId == id);
            return PartialView(cevent);
            //var categories = storeDB.Categories.ToList();
            //return PartialView(categories);
        }


    }
}
