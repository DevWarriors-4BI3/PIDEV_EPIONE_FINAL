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
using MimeKit;
using MailKit.Net.Smtp;
using Org.BouncyCastle.X509;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.Mail;
using Rotativa;
using Microsoft.AspNet.Identity;
using WebUI.Controllers;


namespace WebUI.Controllers
{
    public class AppointmentsController : Controller
    {
        IServiceAppointment sap = new ServiceAppointment();
        IserviceDocteur sd = new ServiceDocteur();

        IServiceDisponibility sdipo= new ServiceDisponibility();
        IUserService us = new ServiceUser();

        

        // GET: Appointments
        public ActionResult Index()
        {
            Global.appointmentToEditId = 0;   
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
            

            AppointmentModel CreatelistDisponibilities = new AppointmentModel();
            CreatelistDisponibilities.Disponibilities = sap.GetDisponibilities(Global.globalIdDoctor);

            return View(CreatelistDisponibilities);
        }
        [Obsolete("Do not use this in Production code!!!", true)]
        static void NEVER_EAT_POISON_Disable_CertificateValidation()
        {
          
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                ) {
                    return true;
                };
        }

        // POST: Appointments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentModel AM, int id)
        {
            if (Global.appointmentToEditId == 0)
            {
                Doctor dr = sap.GetDoctor(Global.globalIdDoctor);
                User u = sap.GetCrrentUserById(User.Identity.GetUserId());
                Disponibility d = sap.GetDisponibilityById(id);
                Appointment a = new Appointment()
                {
                    appointementDate = d.startTimeOfDisponibility,
                    reason = AM.appointement.reason,
                    state = State.accepted,
                    patient = u,
                    doctor = dr


                };


                sap.Add(a);
                sap.Commit();

                var message = new MailMessage("devworriors@gmail.com", dr.Email);
                //message.From=new MailAddress("devworriors@gmail.com");
                //message.From = new MailAddress("medmalek125@gmail.tn");
                message.Subject = "Nouveau rendez-vous";
                message.Body = "Bonsoir Dr."+dr.firstName+" "+dr.lastName+" , je vous informe que je serais au rendez-vous pour le "+d.startTimeOfDisponibility
                    +"                                                                                                               Cordialement"+u.lastName+" "+u.firstName;
                System.Net.Mail.SmtpClient SC = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                SC.Port = 587;
                SC.DeliveryMethod = SmtpDeliveryMethod.Network;
                SC.UseDefaultCredentials = false;
                SC.Credentials = new NetworkCredential("devworriors@gmail.com", "pidev-123456789");
                SC.EnableSsl = true;
                SC.Timeout = 20000;
                message.Priority = MailPriority.High;
                try
                {
                    SC.Send(message);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
            else
            {
                Doctor dr = sap.GetDoctor(Global.globalIdDoctor);
                User u = sap.GetCrrentUserById(User.Identity.GetUserId());
                Disponibility d = sap.GetDisponibilityById(id);
                Appointment a = sap.GetById(Global.appointmentToEditId);
                a.reason = AM.appointement.reason;
                a.appointementDate = d.startTimeOfDisponibility;
                sap.Update(a);
                sap.Commit();
                var message = new MailMessage("devworriors@gmail.com", dr.Email);
                //message.From=new MailAddress("devworriors@gmail.com");
                //message.From = new MailAddress("medmalek125@gmail.tn");
                message.Subject = "Nouveau rendez-vous";
                message.Body = "Bonsoir Dr." + dr.firstName + " " + dr.lastName + " , je vous informe que mon rendez-vous est mis à jours pour le " + d.startTimeOfDisponibility
                    + "                                                                                                               Cordialement" + u.lastName + " " + u.firstName;
                System.Net.Mail.SmtpClient SC = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                SC.Port = 587;
                SC.DeliveryMethod = SmtpDeliveryMethod.Network;
                SC.UseDefaultCredentials = false;
                SC.Credentials = new NetworkCredential("devworriors@gmail.com", "pidev-123456789");
                SC.EnableSsl = true;
                SC.Timeout = 20000;
                message.Priority = MailPriority.High;
                try
                {
                    SC.Send(message);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
            Global.appointmentToEditId = 0;
            return RedirectToAction("Index");
         
            //var message = new MailMessage("devworriors@gmail.com", "medmalek125@gmail.com");
            ////message.From=new MailAddress("devworriors@gmail.com");
            ////message.From = new MailAddress("medmalek125@gmail.tn");
            //message.Subject = "Nouveau rendez-vous";
            //message.Body = "Hello";
            //System.Net.Mail.SmtpClient SC = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            //SC.Port = 587;
            //SC.DeliveryMethod = SmtpDeliveryMethod.Network;
            //SC.UseDefaultCredentials = false;
            //SC.Credentials = new NetworkCredential("devworriors@gmail.com", "pidev-123456789");
            //SC.EnableSsl = true;
            //SC.Timeout = 20000;
            //message.Priority = MailPriority.High;
            //try
            //{
            //    SC.Send(message);

            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}
        

            return View();
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int id)
        {
            Global.appointmentToEditId = id;
            return RedirectToAction("Create");
        }

        // POST: Appointments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId,appointementDate,reason,state")] Appointment appointment)
        {
           Appointment a= sap.GetById(Global.appointmentToEditId);
     
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int id)
        {
            Appointment appointment = sap.GetById(id);
            sap.Delete(appointment);
            sap.Commit();
            return RedirectToAction("Index");
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


        

        [HttpPost]
        public ActionResult PrintViewToPdf(int id)
        {
            User.Identity.GetUserId();


               var report = new ActionAsPdf("Index");
            return report;
        }



      

    }
}
