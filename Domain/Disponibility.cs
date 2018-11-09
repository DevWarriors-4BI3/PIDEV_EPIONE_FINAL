using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Disponibility
    {
       public int DisponibilityId { get; set; }
        [Required(ErrorMessage = "le date debut est obligatoire")]
        public DateTime startTimeOfDisponibility { get; set; }
        [Required(ErrorMessage = "le date fin est obligatoire")]
        public DateTime endTimeOfDisponibility { get; set; }
        public bool State { get; set; }


    }
}
