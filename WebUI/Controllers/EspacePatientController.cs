using Domain;
using Newtonsoft.Json;
using Service;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;

namespace WebUI.Controllers
{
   static class Global
    {
        public static string globalIdDoctor;
        public static int appointmentToEditId;
        public static Distance t;

    }
    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Element
    {
        public static Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public Element[] elements { get; set; }
    }

    public class Parent
    {
        public string[] destination_addresses { get; set; }
        public string[] origin_addresses { get; set; }
        public Row[] rows { get; set; }
        public string status { get; set; }
    }



    public class EspacePatientController : Controller
    {

        IUserService us = new ServiceUser();
        IserviceDocteur sd = new ServiceDocteur();
        IServiceAddresse sa = new ServiceAddresse();
        IServiceAppointment sap = new ServiceAppointment();
        IServiceDisponibility sdispo = new ServiceDisponibility();
        public static IEnumerable<Doctor> doctors; 
        public static string persistantId;
        public static IEnumerable<Doctor> aux;
        // GET: PatientIndex
        private static void MapsAPICall(string origin,string destination)
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=Washington,DC&destinations=New+York+City,NY&key=AIzaSyA3E4sv-3MduZrfRvlQmnogNaD09dzGGS4";

            //string url1 = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins="+origin+"&destinations="+destination+"&key=AIzaSyA3E4sv-3MduZrfRvlQmnogNaD09dzGGS4";

            //Pass request to google api with orgin and destination details
            HttpWebRequest request =
                    (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                if (!string.IsNullOrEmpty(result))
                {
                    Distance t = JsonConvert.DeserializeObject<Distance>(result);
                    Console.WriteLine(result);

                    Console.WriteLine(t);
                    Console.ReadKey();
                }

            }
        }


        [HttpPost]
        public ActionResult Index(String SearchString)
        {
            int searshCondition = Int32.Parse(SearchString);
            IEnumerable<Doctor> Searhxresult;

            Searhxresult = aux.Where(p => p.distance < searshCondition);
           
            return View(aux);
        }

        public ActionResult Index()
        {
            Random rnd = new Random();
            var aux = sd.GetMany();
            foreach (Doctor a in aux)
            {
                //User u = us.GetById(User.Identity.GetUserId());
                // MapsAPICall(a.address+"",u.address+"");
                //a.distance = Global.t.value;
                
                a.distance = rnd.Next(52);
            }
            return View(aux);
        }
       

        public ActionResult AddAppointment(string id)
        {
            Global.globalIdDoctor = id;
            
            return RedirectToAction("Create", "Appointments");
        }
        [HttpPost]
        public ActionResult AddAppointment(Appointment doctor, string id)
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
