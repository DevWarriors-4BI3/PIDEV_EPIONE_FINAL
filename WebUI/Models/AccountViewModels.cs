using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class AccountViewModels
    {

        public class RegisterViewModel

        {
            [Required]
            public string firstName { get; set; }

            [Required(ErrorMessage = "Champ obligatoire")]
            [MaxLength(50)]
            public String lastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Account Type")]
            public EAccountType AccountType { get; set; }

            [Required]
            public virtual Address address { get; set; }

            [ForeignKey("Speciality")]
            [Display(Name = "Speciality")]
            public int? SpecialityId { get; set; }
            public IEnumerable<SelectListItem> Specialitys { get; set; }

        }

        public class LoginViewModel
        {
            [Required]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

           
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
    }
}
