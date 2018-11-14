using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IServiceAppointment : IService<Appointment>
        {
        Doctor GetDoctor();
        IEnumerable<Disponibility> GetDisponibilities(string id);
        Disponibility GetDisponibilityById(int id);
        User GetCrrentUserById(String id);
        Doctor GetDoctor(string id);


    }
}
