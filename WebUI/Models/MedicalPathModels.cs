using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class MedicalPathModels
    {
        public Speciality Speciality { get; set; }
        [Required(ErrorMessage = "la description est obligatoire")]
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Display(Name = "UserId")]
        [DataType(DataType.Text)]
        public String UserId { get; set; }
      

        [Display(Name = "Parcour Date")]
        [DataType(DataType.Date)]
        public DateTime DateParcour { get; set; }


      
        [ForeignKey("Speciality")]
        [Display(Name = "Speciality")]
        public int? SpecialityId { get; set; }
        public IEnumerable<SelectListItem> Specialitys { get; set; }





    
        [ForeignKey("Doctor")]
        [Display(Name = "ProposerDotor")]
        public string DoctorId { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }

       // public string ProposerDotor { get; set; }

      //  public string AdresseDotor { get; set; }


    }
}