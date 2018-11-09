using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Infrastructure;

namespace Service
{
    class ServiceAppointment : Service<ServiceAppointment>, IServiceAppointment
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceAppointment() : base(uow)
        {
        }
    }
}
