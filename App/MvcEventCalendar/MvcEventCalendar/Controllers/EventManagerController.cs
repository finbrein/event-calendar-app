using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEventCalendar.Models;
using System.Web.Helpers;
using System.IO;

namespace MvcEventCalendar.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EventManagerController : Controller
    {
        EventCalendarEntities storeDB = new EventCalendarEntities();
        //
        // GET: /EventManager/

        public ActionResult Index()
        {
            var cevents = storeDB.Events.Include("Category").Include("Place").ToList();
            return View(cevents);
        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /EventManager/Create

        public ActionResult Create()
        {
            ViewBag.Categories = storeDB.Categories.OrderBy(g => g.Name).ToList();
            ViewBag.Places = storeDB.Places.OrderBy(a => a.Name).ToList();
            var theEvent = new Event();
            return View(theEvent);
        }

        //
        // POST: /EventManager/Create
        [HttpPost]
        public ActionResult Create(Event theEvent)
        {
            var image = WebImage.GetImageFromRequest();
            var filename = "";

            if (ModelState.IsValid)
            {
                if (image != null)
                {

                    image.Resize(87, 87);

                    filename = Path.GetFileName(image.FileName);

                    string sourceName = filename;

                    string fileExt = "";

                    int i;

                    if ((i = filename.IndexOf(".")) != -1)
                    {

                        /*

                        Here we read s substring of filename starting from ".", which

                        will be the file extension

                        */

                        fileExt = filename.Substring(i);

                        //Here we read the filename without its extension

                        filename = filename.Substring(0, i);

                    }

                    DateTime time = DateTime.Now;              // Use current time
                    string format = "dd-MM-yyyy hh-mm-ss";    // Use this format
                    string sdf = time.ToString(format);

                    //Here we add the date time stamp to the file name

                    filename = sdf + "_" + filename;

                    //Here we put the file name parts together and create a new filename with the

                    //directory path and the extension

                    filename = filename + fileExt;


                    theEvent.EventPlaceUrl = "/Content/Images/" + filename;
                    image.Save(Path.Combine("~/Content/Images/", filename));
                    filename = Path.Combine("~/Content/Images/", filename);

                    var ImageUrl = Url.Content(filename);

                }
                else
                {
                    theEvent.EventPlaceUrl = "/Content/Images/placeholder.gif";
                }



                //Save event
                storeDB.Events.Add(theEvent);
                storeDB.SaveChanges();
                return RedirectToAction("Index");

            }
            
            // Invalid – redisplay with errors
            ViewBag.Categories = storeDB.Categories.OrderBy(g => g.Name).ToList();
            ViewBag.Places = storeDB.Places.OrderBy(a => a.Name).ToList();
            return View(theEvent);
        }

        //
        // GET: /EventManager/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = storeDB.Categories.OrderBy(g => g.Name).ToList();
            ViewBag.Places = storeDB.Places.OrderBy(a => a.Name).ToList();
            var theEvent = storeDB.Events.Single(a => a.EventId == id);

            return View(theEvent);
        }

        //
        // POST: /EventManager/Edit/386        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theEvent = storeDB.Events.Find(id);

            var image = WebImage.GetImageFromRequest();
            var filename = "";

            if (TryUpdateModel(theEvent))
            {
                    if (image != null)
                    {

                        //image.Resize(250, 250);

                        filename = Path.GetFileName(image.FileName);

                        string sourceName = filename;

                        string fileExt = "";

                        int i;

                        if ((i = filename.IndexOf(".")) != -1)
                        {

                            /*

                            Here we read s substring of filename starting from ".", which

                            will be the file extension

                            */

                            fileExt = filename.Substring(i);

                            //Here we read the filename without its extension

                            filename = filename.Substring(0, i);

                        }

                        DateTime time = DateTime.Now;              // Use current time
                        string format = "dd-MM-yyyy hh-mm-ss";    // Use this format
                        string sdf = time.ToString(format);

                        //Here we add the date time stamp to the file name

                        filename = sdf + "_" + filename;

                        //Here we put the file name parts together and create a new filename with the

                        //directory path and the extension

                        filename = filename + fileExt;


                        theEvent.EventPlaceUrl = "/Content/Images/" + filename;
                        image.Save(Path.Combine("~/Content/Images/", filename));
                        filename = Path.Combine("~/Content/Images/", filename);

                        var ImageUrl = Url.Content(filename);

                    }
                    else
                    {
                        theEvent.EventPlaceUrl = "/Content/Images/placeholder.gif";
                    }


                //************

                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = storeDB.Categories.OrderBy(g => g.Name).ToList();
                ViewBag.Places = storeDB.Places.OrderBy(a => a.Name).ToList();
                return View(theEvent);
            }
        }

        //
        // GET: /EventManager/Delete/5
        public ActionResult Delete(int id)
        {
            var theEvent = storeDB.Events.Find(id);

            return View(theEvent);
        }

        //
        // POST: /EventManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var theEvent = storeDB.Events.Find(id);

            storeDB.Events.Remove(theEvent);
            storeDB.SaveChanges();
            return View("Deleted");
        }
    }
}
