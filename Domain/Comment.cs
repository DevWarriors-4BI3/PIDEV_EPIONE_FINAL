using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment
    {

        public Comment()
        {
        }
        [Key]
        public int ComID { get; set; }
        public string CommentMsg { get; set; }
        public Nullable<System.DateTime> CommentedDate { get; set; }
        public Nullable<int> PostID { get; set; }
        public virtual Post Post { get; set; }
        public Nullable<int> UserID { get; set; }
        public virtual User User { get; set; }

    }

}
