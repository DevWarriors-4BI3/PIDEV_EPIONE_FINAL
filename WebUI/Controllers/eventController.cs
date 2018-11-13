using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class eventController : Controller
    {   
        ServiceEvents se = new ServiceEvents();
        // GET: event
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            List<Events> events=new List<Events>() ;
            var appointments = se.GetPatientAppointments();
            foreach (Appointment a in appointments)
            {
                Events evt = new Events()
                {
                    Description = a.reason,
                    Start = a.appointementDate,
                    End = a.appointementDate.AddMinutes(15),
                    Subject = a.reason,
                    EventId = 1
                };
                events.Add(evt);

            }
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //action to request in a mandate creation
        [HttpPost]
        public ActionResult Create(String subject, String description, DateTime start, DateTime end)
        {
            Events e = new Events();
            e.Subject = subject;
            e.Description = description;
            e.End = end;
            e.Start = start;
            se.Add(e);
            se.Commit();

            return RedirectToAction("Index");
        }
    }
}