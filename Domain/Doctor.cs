using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor: User
    {
        public virtual Speciality Speciality { get; set; }
        public virtual ICollection<Disponibility> disponibilities { get; set; }
    }
}
