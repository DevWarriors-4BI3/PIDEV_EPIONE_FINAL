using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using Data.Infrastructure;
using ServicePattern;
using Service;

namespace Service
{
    public class ServiceDocteur : Service<Doctor>, IserviceDocteur
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceDocteur() : base(uow)
        {

        }
        public IEnumerable<Address> GetAddresses() {
            var Addresses = uow.getRepository<Address>().GetMany();
            
            return Addresses;



            
        }



    }
}
        

