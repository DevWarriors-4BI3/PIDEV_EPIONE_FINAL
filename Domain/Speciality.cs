using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Speciality
    {
        public int SpecialityId { get; set; }
        public string nomSpecialite { get; set; }
        ICollection<Doctor> Doctors { get; set; }

    }
}
