using Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MySql.Data;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
 //   [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PiContext : IdentityDbContext<User>
    {
        
        public PiContext() : base("Name=PIEPIONE")
        {
            Database.SetInitializer(new ContexInit());
         }

        //  public DbSet<Patient> Patients { get; set; }
        //  public DbSet<Doctor> Doctors{ get; set; }
        //     public DbSet<User> Users{ get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Disponibility> Disponibilities { get; set; }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Treatement> Treatements { get; set; }
        public DbSet<MedicalPath> MedicalPaths { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Speciality> Specialities { get; set; }





        public static PiContext Create()
        {
            return new PiContext();
        }



    }
    public class ContexInit : DropCreateDatabaseIfModelChanges<PiContext>
    {
        protected override void Seed(PiContext context)
        {
         /*   List<Patient> patients = new List<Patient>() {
                new Patient {PatientId=1
                            }
               
            };
            context.Patients.AddRange(patients);
            context.SaveChanges();*/
        }
    }
}
