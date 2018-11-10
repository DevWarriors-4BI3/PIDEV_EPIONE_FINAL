using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class PatientIndexController : Controller
    {
        ServiceUser su = new ServiceUser();
        ServiceDocteur sd = new ServiceDocteur();
        ServiceAddresse sa = new ServiceAddresse();
        // GET: PatientIndex
        public ActionResult Index()
        {
           var AllAddresses= sd.GetAddresses();
            var All = sd.GetMany();

            return View(All);
        }

        // GET: PatientIndex/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientIndex/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientIndex/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientIndex/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientIndex/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientIndex/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientIndex/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
