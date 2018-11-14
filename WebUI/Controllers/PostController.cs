using Domain;
using Microsoft.AspNet.Identity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class PostController : Controller
    {
        ServicePost sp = new ServicePost();

        ServiceUser su = new ServiceUser();
        // GET: Post
        //public ActionResult Index()
        //{
        //    List<Post> Posts = new List<Post>();
        //    Posts = sp.GetPosts();
        //    return View();
        //}
        public ActionResult Index(int? idcat, string recherch)
        {
            List<Post> Posts = new List<Post>();
            try
            {
                //ViewBag.categoriepost = ps.GetCategoriePost();

                if (recherch != null)
                {
                    Posts = sp.GetPostsByrecherch(recherch);
                }
                else
                {
                    Posts = sp.GetPosts();
                    // Posts = idcat == null ? ps.GetPosts() : ps.GetPostsBycat(idcat);
                }
                return View(Posts);
            }
            catch (Exception ex)
            {
                return View(Posts);
            }
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post p)
        {
            try
            {

                string currentUserId = User.Identity.GetUserId();
                List<User> GetUsers = sp.GetUsers();
                var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);

                Post post = new Post
                {
                    Message = p.Message,
                    Titre = p.Titre,
                    PostedDate = p.PostedDate,
                    UserId = currentUserId,

                };
                if (user != null)
                {
                    user.Posts.Add(post);
                    sp.Commit();
                    su.Commit();
                }



                return RedirectToAction("Index", "Post");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
