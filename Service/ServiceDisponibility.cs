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
   public class ServiceDisponibility : Service<Disponibility>, IServiceDisponibility
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);

        


        public ServiceDisponibility() : base(uow)
        {
        }

        public IEnumerable<Disponibility> GetDisponibilitiesByDoctor(Doctor doctor)
        {
            return this.GetMany(p=>p.doctor==doctor); 
        }
        public Doctor GetDisponibilities()
        {
            
            return  uow.getRepository<Doctor>().GetById("952b6457-fdbe-4c8e-ae98-0b0992b16b19"); 
        }
    }
}
