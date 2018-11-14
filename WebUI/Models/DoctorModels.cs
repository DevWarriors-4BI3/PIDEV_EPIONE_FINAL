using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class DoctorModels
    {

        [Required(ErrorMessage = "Champ obligatoire")]
        [MaxLength(50)]
        public String firstName { get; set; }
        [Required(ErrorMessage = "Champ obligatoire")]
        [MaxLength(50)]
        public String lastName { get; set; }
        [ForeignKey("Speciality")]
        [Display(Name = "Speciality")]
        public int? SpecialityId { get; set; }
        public IEnumerable<SelectListItem> Specialitys { get; set; }
    }
}