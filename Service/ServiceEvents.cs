using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceEvents : Service<Events>, IServiceEvents
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceEvents() : base(uow)
        {
        }
       
        public IEnumerable<Appointment> GetPatientAppointments()
        {//connectred user
            return uow.getRepository<Appointment>().GetMany();
        }
    }
}
