using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Address
    {
        public int AddressId { get; set; }
        [Required(ErrorMessage = "le pays doit etre mentionné")]
        [MaxLength(50)]
        public String country { get; set; }
        [Required(ErrorMessage = "la ville doit etre mentionné")]
        [MaxLength(50)]
        public String city { get; set; }
        [Required(ErrorMessage = "la rue doit etre mentionné")]
        [MaxLength(50)]
        public String Street { get; set; }
      
      

    }
}
