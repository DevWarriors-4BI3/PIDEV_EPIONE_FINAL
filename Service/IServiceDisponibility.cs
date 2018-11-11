using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IServiceDisponibility : IService<Disponibility>
    {
        IEnumerable<Disponibility> GetDisponibilitiesByDoctor(Doctor doctor);
        Doctor GetDisponibilities();
    }
}
