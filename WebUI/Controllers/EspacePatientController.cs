using Domain;
using Service;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI.Controllers
{
    public class EspacePatientController : Controller
    {
      
        IserviceDocteur sd = new ServiceDocteur();
        IServiceAddresse sa = new ServiceAddresse();
        IServiceAppointment sap = new ServiceAppointment();
        IServiceDisponibility sdispo = new ServiceDisponibility();
        public static IEnumerable<Doctor> doctors; 
        public static String persistantId;
        // GET: PatientIndex
        public ActionResult Index()
        {
            // var AllAddresses = sd.GetAddresses();
       //     List<Doctor> lstd = new List<Doctor>();
  
       //foreach(var item in sd.GetAll())
       //     {
       //         Address aa = sa.GetById(item.address.AddressId);
       //         Doctor d = new Doctor();
       //         d.address.AddressId = item.address.AddressId;
       //         d.firstName = item.firstName;
       //         d.lastName = item.lastName;
       //         d.Email = item.Email;
       //         d.Speciality = item.Speciality;le 
       //         d.address = aa;
       //         d.disponibilities = item.disponibilities;
       //         lstd.Add(d);
       //     }
            return View(sd.GetMany());
        }
        //    return RedirectToAction( "Main", new RouteValueDictionary(
        //new { controller = controllerName, action = "Main", Id = Id
        //} ) );

        public ActionResult AddAppointment(String id)
        {
          

            return RedirectToAction("Create", "Appointments");
        }
        [HttpPost]
        public ActionResult AddAppointment(Appointment doctor)
        {
            
            //sd.Dispose();
            //sa.Dispose();
            //sap.Add(new Appointment()
            //{ 
            //    reason = doctor.reason,
            //    appointementDate = DateTime.Now,
            //    state = State.accepted
            //});
            //sap.Commit();

            ////sdispo.Add(new Disponibility()
            ////{
            ////    doctor = d,
            ////    startTimeOfDisponibility = DateTime.Now,
            ////    endTimeOfDisponibility = DateTime.Now,
            ////    State = true
            ////});
            ////sdispo.Commit();


           return View();
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
