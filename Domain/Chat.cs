using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Chat
    {
        public int ChatId { get; set; }
        public virtual User sender { get; set; }
        public virtual User recever { get; set; }
        public DateTime sentAt{ get; set; }
        public bool state { get; set; }
        public string message { get; set; }


    }
}
