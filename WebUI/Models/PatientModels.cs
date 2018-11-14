using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PatientModels
    {
        [Required(ErrorMessage = "Champ obligatoire")]
        [MaxLength(50)]
        public String firstName { get; set; }
        [Required(ErrorMessage = "Champ obligatoire")]
        [MaxLength(50)]
        public String lastName { get; set; }
    }
}