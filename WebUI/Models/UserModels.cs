using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class UserModels
    {
        [Required(ErrorMessage = "Champ obligatoire")]
        [MaxLength(50)]
        public String firstName { get; set; }
        [Required(ErrorMessage = "Champ obligatoire")]
        [MaxLength(50)]
        public String lastName { get; set; }
        //[DataType(DataType.EmailAddress)]
        //public String email { get; set; }
        //[Required(ErrorMessage = "Champ obligatoire")]
        //[MaxLength(50)]
        //public String login { get; set; }
        //[Required(ErrorMessage = "Required")]
        //public String Password { get; set; }
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Required")]
        //[NotMapped]
        //[Compare("Password", ErrorMessage = "Confirmer le mot de passe")]
        //public String confirmPassword { get; set; }
        //[Required(ErrorMessage = "Champ obligatoire")]
        //[MaxLength(50)]
    }
}