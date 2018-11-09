using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Forum
    {
        public int ForumId { get; set; }
        public virtual User subjectCreater { get; set; }
        public DateTime sentAt { get; set; }
        public string subject { get; set; }
        

    }
}
