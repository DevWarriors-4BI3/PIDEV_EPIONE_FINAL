using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum State { accepted, declined}

namespace Domain
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [Required(ErrorMessage = "la date est obligatoire")]
        public DateTime appointementDate { get; set; }
        [Required(ErrorMessage = "la date est obligatoire")]
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public String reason { get; set; }
        [Required(ErrorMessage = "l'etat est obligatoire")]
        public State state { get; set; }
        private float Note { get; set; }
        public virtual User patient{ get; set; }
        public virtual  User doctor { get; set; }

      

    }
}
