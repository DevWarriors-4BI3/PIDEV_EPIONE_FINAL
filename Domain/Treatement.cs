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
        [Required(ErrorMessage ="Durée obligatoire")]
        public int daysDuration { get; set; }
        public Validation isValitaded { get; set; }
        public MedicalPath path { get; set; }
    }
}
