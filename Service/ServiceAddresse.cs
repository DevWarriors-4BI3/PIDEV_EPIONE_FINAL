using Data.Infrastructure;
using Domain;
using Infrastructure;
using Service;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class ServiceAddresse : Service<Address>, IServiceAddresse
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);

        public ServiceAddresse() : base(uow)
        {
        }
        

    }

}
