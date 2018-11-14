using Domain;
using Microsoft.AspNet.Identity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class CommentsController : Controller
    {
        ServicePost sp = new ServicePost();
        ServiceComment sc = new ServiceComment();
        ServiceUser su = new ServiceUser();
        // GET: Response
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetResponse(int id)
        {
            Post pos = sp.GetPostsByid(id);
            List<Post> Postsf = new List<Post> { pos };

            IEnumerable<PostsVM> Postsvm = Postsf
                .Select(p => new PostsVM
                {
                    PostID = p.PostID,
                    Titre = p.Titre,
                    Message = p.Message,
                    PostedDate = p.PostedDate.Value,
                    Username = p.User.firstName + " " + p.User.lastName,

                }).ToList();

            return View(Postsvm);
        }

        public PartialViewResult GetComments(int postId)
        {
            List<Comment> Comments = sp.GetComments();
            IEnumerable<CommentsVM> comments = Comments.Where(c => c.Post.PostID == postId)
                                                       .Select(c => new CommentsVM
                                                       {
                                                           ComID = c.ComID,
                                                           CommentedDate = c.CommentedDate.Value,
                                                           CommentMsg = c.CommentMsg,
                                                           Users = new UserVM
                                                           {
                                                               UserID = 1,
                                                               Username = c.User.firstName,
                                                               //imageProfile = c.User.ImageName
                                                           }
                                                       }).ToList();

            return PartialView("~/Views/Shared/_MyComments.cshtml", comments);
        }




        [HttpPost]
        public ActionResult AddComment(CommentsVM comment, int postId)
        {
            //bool result = false;
            Comment commentEntity = null;

            string currentUserId = User.Identity.GetUserId();
            int userId = 1;
            //int.Parse(currentUserId);
            //(int)Session["UserID"]; 
            List<User> GetUsers = sp.GetUsers();

            var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
            var post = sp.GetPosts().FirstOrDefault(p => p.PostID == postId);

            if (comment != null)
            {

                commentEntity = new Comment
                {
                    CommentMsg = comment.CommentMsg,
                    CommentedDate = DateTime.Now

                };


                if (user != null && post != null)
                {
                    post.Comments.Add(commentEntity);
                    user.Comments.Add(commentEntity);
                    //sq.SaveChanges( );
                    //dbContext.SaveChanges();
                    //result = true;

                    sp.Commit();
                    su.Commit();
                }
            }

            return RedirectToAction("GetComments", "Comments", new { postId = postId });
        }

    }

}
