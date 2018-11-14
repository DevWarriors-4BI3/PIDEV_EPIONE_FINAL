using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Infrastructure;
using Domain;

namespace Service
{
    public class ServiceAppointment : Service<Appointment>, IServiceAppointment
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceAppointment() : base(uow)
        {
        }

        public IEnumerable<Disponibility> GetDisponibilities()
        {
            return uow.getRepository<Disponibility>().GetMany();
        }

        

        public Disponibility GetDisponibilityById(int id)
        {
            return uow.getRepository<Disponibility>().GetById(id); 
        }

        public Doctor GetDoctor(string id)
        {

            return uow.getRepository<Doctor>().GetById(id);
        }

        public User GetCrrentUserById(string id)
        {

            return uow.getRepository<User>().GetById(id);
        }

        public IEnumerable<Disponibility> GetDisponibilities(string id)
        {
            return uow.getRepository<Disponibility>().GetMany().Where(p => p.startTimeOfDisponibility >= DateTime.Now).Where(p => p.doctor.Id == id);
        }

        public Doctor GetDoctor()
        {
            throw new NotImplementedException();
        }
    }
}
