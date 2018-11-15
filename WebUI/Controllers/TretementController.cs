using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class TretementController : Controller
    {


        ServiceTretement st = new ServiceTretement();


        // GET: Tretement
        public ActionResult Index()
        {
            var tretements = st.GetMany();
            return View(tretements);
        }

        //[HttpPost]

        //public ActionResult Index(string UserId)
        //{
        //    // var ProductSearched = sp.GetMany(p=>p.Name== searchString);
        //    //var MedSearched = sm.GetMany(p => p.UserId==UserId);
        //    var TreSearched = st.GetMany().Where(s => s.UserId == UserId);
        //    return View(TreSearched);
        //}


        //    public ActionResult ExportPDF()
        //{
        //    return new ActionAsPdf("Index")
        //    {
        //        FileName = Server.MapPath("~/Content/listtretemnts.pdf")
        //    };
         

        //}



        // GET: Tretement/Details/5
        public ActionResult Details(int id)
        {
            Treatement tret = st.GetMany().Single(s => s.TreatementId == id);
            return View(tret);
           
        }

        // GET: Tretement/Create
        public ActionResult Create()
        {
            TretementModels pm = new TretementModels();
            return View(pm);
        }

        // POST: Tretement/Create
        [HttpPost]
        public ActionResult Create(TretementModels pm)
        {
            try
            {
                Treatement t = new Treatement()
                {
                    description = pm.description,
                   DuréeTretement= pm.DuréeTretement,
                    DateTretement = pm.DateTretement,
                   UserId=pm.UserId,
                   Validation=pm.Validation,

                };

                st.Add(t);
                st.Commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tretement/Edit/5
        public ActionResult Edit(int id)
        {
            Treatement tret = st.GetMany().Single(s => s.TreatementId == id);
            return View(tret);
        }

        // POST: Tretement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Treatement newtret)
        {
            try
            {
                Treatement oldTretement = st.GetMany().Single(s => s.TreatementId == id);
                oldTretement.description = newtret.description;
                oldTretement.DuréeTretement = newtret.DuréeTretement;
                oldTretement.DateTretement = newtret.DateTretement;
                oldTretement.UserId = newtret.UserId;
                oldTretement.Validation = newtret.Validation;
              
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tretement/Delete/5
        public ActionResult Delete(int id)
        {
            Treatement tret = st.GetMany().Single(s => s.TreatementId == id);
            return View(tret);
       
        }

        // POST: Tretement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Treatement tret = st.GetMany().Single(s => s.TreatementId == id);
                st.Delete(tret);
                st.Commit();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult listPatient()
        {


            return RedirectToAction("Index", "Patient");

        }

    }

}
