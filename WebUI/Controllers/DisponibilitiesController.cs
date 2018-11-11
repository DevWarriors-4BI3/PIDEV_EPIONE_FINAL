using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain;
using Service;

namespace WebUI.Controllers
{
    public class DisponibilitiesController : Controller
    {
        private IServiceDisponibility sdis = new ServiceDisponibility();
        private IserviceDocteur sd = new ServiceDocteur();

        // GET: Disponibilities
        public ActionResult Index()
        {
            return View(sdis.GetMany());
        }

        // GET: Disponibilities/Details/5
        public ActionResult Details(int id)
        {
           
            Disponibility disponibility = sdis.GetById(id);
            if (disponibility == null)
            {
                return HttpNotFound();
            }
            return View(disponibility);
        }

        // GET: Disponibilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disponibilities/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisponibilityId,startTimeOfDisponibility,endTimeOfDisponibility,State")] Disponibility disponibility)
        {
            if (ModelState.IsValid)
            {
                disponibility.doctor = sdis.GetDisponibilities();
                sdis.Add(disponibility);
                sdis.Commit();
                return RedirectToAction("Index");
            }

            return View(disponibility);
        }

        // GET: Disponibilities/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibility disponibility = sdis.GetById(id);
            if (disponibility == null)
            {
                return HttpNotFound();
            }
            return View(disponibility);
        }

        // POST: Disponibilities/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisponibilityId,startTimeOfDisponibility,endTimeOfDisponibility,State")] Disponibility disponibility)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(disponibility).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disponibility);
        }

        // GET: Disponibilities/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibility disponibility = sdis.GetById(id);
            if (disponibility == null)
            {
                return HttpNotFound();
            }
            return View(disponibility);
        }

        // POST: Disponibilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disponibility disponibility = sdis.GetById(id);
            //db.Disponibilities.Remove(disponibility);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
