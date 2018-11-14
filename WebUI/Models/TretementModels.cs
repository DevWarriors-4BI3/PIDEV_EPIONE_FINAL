using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class TretementModels
    {
     
        [Required(ErrorMessage = "la date est obligatoire")]
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public String description { get; set; }
        [Required(ErrorMessage = "Durée obligatoire")]

        public string DuréeTretement { get; set; }


        [Display(Name = "Tretement Date")]
        [DataType(DataType.Date)]
        public DateTime DateTretement { get; set; }

        public string UserId { get; set; }

        public bool Validation { get; set; }
        // public MedicalPath path { get; set; }
    }
}