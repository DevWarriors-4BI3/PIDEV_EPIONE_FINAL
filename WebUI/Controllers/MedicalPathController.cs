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
    public class MedicalPathController : Controller
    {
        // GET: MedicalPath
        ServiceMedicalPath sm = new ServiceMedicalPath();
        ServiceSpeciality ss = new ServiceSpeciality();
        ServiceDocteur sd = new ServiceDocteur();
        public ActionResult Index()
        {

   

               var medical= sm.GetMany();


            return View(medical);

        }


        //[HttpPost]
     
        //public ActionResult Index(string UserId)
        //{
        //    // var ProductSearched = sp.GetMany(p=>p.Name== searchString);
        //    //var MedSearched = sm.GetMany(p => p.UserId==UserId);
        //    var MedSearched = sm.GetMany().Where(s => s.UserId == UserId);
        //    return View(MedSearched);
        //}


        // GET: MedicalPath/Details/5
        public ActionResult Details(int id)
        {
            MedicalPath MedicalPaths = sm.GetMany().Single(s => s.MedicalPathId == id);
            return View(MedicalPaths);
        }

        // GET: MedicalPath/Create
        public ActionResult Create()
        {
            MedicalPathModels pm = new MedicalPathModels();
            pm.Specialitys = ss.GetMany().Select(c => new SelectListItem
            {

                Text = c.nomSpecialite,
                Value = c.SpecialityId.ToString()

            }
              );
            pm.Doctors = sd.GetMany().Select(c => new SelectListItem
            {

                Text = c.firstName,
                Value = c.Id.ToString(),
       

            }
                      );


            return View(pm);
        }

        // POST: MedicalPath/Create
        [HttpPost]
        public ActionResult Create(MedicalPathModels pm)
        {
            try
            {
                MedicalPath p = new MedicalPath()
                {
                    SpecialityId = pm.SpecialityId,
                    Description = pm.Description,
                    UserId = pm.UserId,
                    DateParcour = pm.DateParcour,
                    DoctorId=pm.DoctorId,
       
                };
                // TODO: Add insert logic here
                sm.Add(p);
                sm.Commit();
                return  RedirectToAction("Index");
            }
            catch 
            {  
                return View();
            }
        }

        // GET: MedicalPath/Edit/5
        public ActionResult Edit(int id)
        {

            MedicalPath MedicalPaths = sm.GetMany().Single(s=>s.MedicalPathId==id);
            return View(MedicalPaths);
        }

        // POST: MedicalPath/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MedicalPath newMedicalPath)
        {
            try
            {
                // TODO: Add update logic here
                MedicalPath oldMedicalPath = sm.GetMany().Single(s => s.MedicalPathId == id);
                oldMedicalPath.SpecialityId = newMedicalPath.SpecialityId;
                oldMedicalPath.Description = newMedicalPath.Description;
                oldMedicalPath.UserId = newMedicalPath.UserId;
                oldMedicalPath.DateParcour = newMedicalPath.DateParcour;
                oldMedicalPath.DoctorId = newMedicalPath.DoctorId;
               // oldMedicalPath.AdresseDotor = newMedicalPath.AdresseDotor;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalPath/Delete/5
        public ActionResult Delete(int id)
        {
            MedicalPath MedicalPaths = sm.GetMany().Single(s => s.MedicalPathId == id);

           


            return View(MedicalPaths);
          
        }

        // POST: MedicalPath/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                MedicalPath MedicalPaths = sm.GetMany().Single(s => s.MedicalPathId == id);
                sm.Delete(MedicalPaths);
                sm.Commit();
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
        //public IEnumerable<string> getById(int id)
        //{
        //    var req = from s in ss.GetMany()
        //                   where s.SpecialityId == id
        //                   select s.nomSpecialite;
        //    return req;
        //}
    }
}
