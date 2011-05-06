using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEventCalendar.Controllers
{
    public class IcalendarController : Controller
    {
        //
        // GET: /Icalendar/

        public ActionResult Index()
        {
            return View();
        }

    }
}
