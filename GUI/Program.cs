using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;
using Data;

namespace GUI
{
    class Program
    {

        static void Main(string[] args)
        {
            PiContext ctx = new PiContext();
            /*  User u = new User { Email = "emel.garouachi@esprit.tn",
               Password= "1234",
              adress = "1 rue de sfax",
              UserName="emel",
              gender=Gender.
              female,
              lastName="Garouachi",
              birthDate=DateTime.Now};*/
            //    ctx.Users.Add(u);
            //   ctx.SaveChanges();


            Disponibility dispo = new Disponibility { startTimeOfDisponibility = DateTime.Now, endTimeOfDisponibility = DateTime.Now };
            List<Disponibility> disponibilities=new List<Disponibility>();
            disponibilities.Add(dispo);
            Address DocAdd = new Address { country = "France", city = "paris", Street = "Montrouge" };
            
            User doctor1 = new Doctor { firstName = "malek", lastName = "malek", PhoneNumber = "99574476", disponibilities = disponibilities, Email = "doctor@gmail.com" ,address=DocAdd};
            User patient1 = new Patient { firstName = "malek1", lastName = "malek1", PhoneNumber = "99574476", Email = "patient@gmail.com", address = DocAdd };
            Appointment apointment = new Appointment { state = State.accepted, doctor = doctor1, patient = patient1,appointementDate=DateTime.Now,reason="rassi youja3 fiya" };
        }
    }
}
