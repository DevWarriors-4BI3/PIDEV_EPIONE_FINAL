using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Validation {valitaded, notvalidated }

namespace Domain
{
    public class Treatement
    {
        public int TreatementId { get; set; }
        [Required(ErrorMessage = "la date est obligatoire")]
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public String description { get; set; }
        [Required(ErrorMessage = "Durée obligatoire")]

        public string DuréeTretement { get; set; }


        [Display(Name = "Tretement Date")]
        [DataType(DataType.Date)]
        public DateTime DateTretement { get; set; }



        public virtual User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public bool Validation { get; set; }
        // public MedicalPath path { get; set; }
    }
}
