using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int PostID { get; set; }
        public string Titre { get; set; }
        public string Message { get; set; }
        //public Nullable<System.DateTime> PostedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PostedDate { get; set; }

        public string UserId;
        public virtual User User { get; set; }

        //   public virtual CategoriePost categoriePost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
