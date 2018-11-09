using Domain;
using ServicePattern;
using Infrastructure;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class ServiceDoctor: Service<Doctor>,IserviceDoctor
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        //IRepositoryBase<Product> rps = new RepositoryBase<Product>(dbf);
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceDoctor() : base(uow)
        {

        }
    }
}
