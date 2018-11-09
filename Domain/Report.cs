using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Report
    {
        public int ReportId { get; set; }
        [Required(ErrorMessage = "la Description est obligatoire")]
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public String Description{ get; set; }
        public String photo { get; set; }
        public Appointment appointment { get; set; }
    }
}
