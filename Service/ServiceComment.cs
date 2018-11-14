using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceComment : Service<Post>, IServiceComment
    {
        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);

        public ServiceComment() : base(UOW)
        {


        }

    }

}
