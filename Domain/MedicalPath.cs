using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MedicalPath
    {
        public int MedicalPathId { get; set; }
        public Speciality Speciality { get; set; }
        [Required(ErrorMessage = "la description est obligatoire")]
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public User RecomendedDotor{ get; set; }
        [ForeignKey("TreatementId")]
        public virtual ICollection<Treatement> treatments { get; set; }
      

    }
}
