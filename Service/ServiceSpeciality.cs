
using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public  class ServiceSpeciality : Service<Speciality>, IServiceSpeciality
    {
        // MyfinanctCtx ctx = new MyfinanctCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();
        // IRepositoryBase<Product> repo = new RepositoryBase<Product>(dbf);
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceSpeciality() : base(uow)
        {

        }

        public static string GetNomById(int? id)
        {

            //return GetMany(p=>p.Category==C).OrderBy(p=>p.Price);
            var req = (from s in dbf.DataContext.Specialities
                       where s.SpecialityId == id
                       select s.nomSpecialite).Single();

            return req;

        }





    }
}
