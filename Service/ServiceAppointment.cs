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
        public Doctor GetDoctor()
        {

            return uow.getRepository<Doctor>().GetById("952b6457-fdbe-4c8e-ae98-0b0992b16b19");
        }
    }
}
