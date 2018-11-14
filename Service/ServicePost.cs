using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServicePost : Service<Post>, IServicePost
    {
        static DatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(dbf);



        public ServicePost() : base(UOW)
        {

        }

        public List<Post> GetPosts()
        {
            return dbf.DataContext.Posts.ToList();
        }

        public List<Post> GetPostsByrecherch(string recherch)
        {
            List<Post> lst = dbf.DataContext.Posts.Where(u => u.Titre.Contains(recherch)).ToList();
            return lst;
        }

        public Post GetPostsByid(int id)
        {
            return dbf.DataContext.Posts.Find(id);
        }
        public List<Comment> GetComments()
        {
            return dbf.DataContext.Comments.ToList();
        }

        public List<User> GetUsers()
        {

            return dbf.DataContext.Users.ToList();
        }
        public void SaveChanges()
        {
            dbf.DataContext.SaveChanges();
        }

    }

}
