using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class PostsVM
    {
        public int PostID { get; set; }
        public string Titre { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Categorie { get; set; }
        public DateTime PostedDate { get; set; }
    }

    public class CommentsVM
    {
        public int ComID { get; set; }
        public string CommentMsg { get; set; }
        public DateTime CommentedDate { get; set; }
        public PostsVM Posts { get; set; }
        public UserVM Users { get; set; }
    }

    public class UserVM
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string imageProfile { get; set; }
    }


}