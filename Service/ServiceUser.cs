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
    public class ServiceUser : Service<User>, IUserService
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
    static IUnitOfWork uow = new UnitOfWork(dbf);
    public ServiceUser() : base(uow)
        {

    }
       public IEnumerable<User> GetAllDoctors() {

            return GetMany(p => p.GetType() == typeof(Doctor)); }
       
    }
}
