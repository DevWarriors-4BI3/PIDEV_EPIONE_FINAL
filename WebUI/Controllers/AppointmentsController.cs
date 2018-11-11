using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using WebUI.Models;
using Service;

namespace WebUI.Controllers
{
    public class AppointmentsController : Controller
    {
        IServiceAppointment sap = new ServiceAppointment();

        // GET: Appointments
        public ActionResult Index()
        {
            return View(sap.GetMany());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int id)
        {
            
            Appointment appointment = sap.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentId,appointementDate,reason,state")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                sap.Add(appointment);
                sap.Commit();
                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = sap.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId,appointementDate,reason,state")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                //sap.Entry(appointment).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = sap.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = sap.GetById(id);
            sap.Delete(appointment);
            sap.Commit();
            return RedirectToAction("Index");
        }

     
    }
}
