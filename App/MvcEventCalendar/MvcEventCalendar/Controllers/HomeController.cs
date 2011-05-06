using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcEventCalendar.Models;
using System;

namespace MvcEventCalendar.Controllers
{
    public class HomeController : Controller
    {
        EventCalendarEntities storeDB = new EventCalendarEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // Get most popular events
            var theEvents = GetTopSellingEvents(5);
            return View(theEvents);
        }

        public ViewResult ViewToday()
        {
            // Get most today's events              
            var EventToday = GetEventsToday();

            return View(EventToday);
        }

        private List<Event> GetEventsToday()
        {
            // Group the order details by event and return
            // the events with the highest count
            DateTime value = new DateTime(2011, 5, 5);
            DateTime value2 = DateTime.Today;
            return storeDB.Events.OrderByDescending(a => a.EventDate == value).ToList();
        }

        private List<Event> GetTopSellingEvents(int count)
        {
            // Group the order details by event and return
            // the events with the highest count
            return storeDB.Events.OrderByDescending(a => a.OrderDetails.Count()).Take(count).ToList();
        }
    }


}
