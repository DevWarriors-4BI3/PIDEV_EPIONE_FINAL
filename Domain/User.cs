using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//public enum Role {admin,patient,doctor}
namespace Domain
{
    public enum EAccountType
    {
        Patient,
        Doctor,
        Administrator
    }
    public class User  : IdentityUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Comments = new HashSet<Comment>();
        }



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
        
       
           
        [Required]
        public virtual Address address { get; set; }
        
       // public EAccountType role { get; set; }
   
      
       
        public virtual ICollection<Appointment> Appointments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }






    }

}
