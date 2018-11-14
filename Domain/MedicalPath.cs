using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MedicalPath
    {
        public int MedicalPathId { get; set; }
        [Required(ErrorMessage = "la description est obligatoire")]
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Display(Name = "Parcour Date")]
        [DataType(DataType.Date)]
        public DateTime DateParcour { get; set; }




        // public string ProposerDotor{ get; set; }

        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Doctor")]
        [Display(Name = "ProposerDotor")]
        public string DoctorId { get; set; }

        // public string AdresseDotor { get; set; }



        public virtual User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual Speciality Speciality { get; set; }
        [ForeignKey("Speciality")]
        [Display(Name = "Speciality")]
        public int? SpecialityId { get; set; }



    }
}
