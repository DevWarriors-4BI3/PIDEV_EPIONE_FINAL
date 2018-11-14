using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor: User
    {
        public virtual Speciality Speciality { get; set; }
        [ForeignKey("Speciality")]
        [Display(Name = "Speciality")]
        public int? SpecialityId { get; set; }

        public virtual ICollection<Disponibility> disponibilities { get; set; }
        [NotMapped]
        public virtual float distance { get; set; }
    }
}
