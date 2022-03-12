using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer.Services
{
    public class BlogCommentRepository : IBlogCommentRepository
    {
        private MyBlogContext db;
        public BlogCommentRepository(MyBlogContext context)
        {
            this.db = context;
        }
        public IEnumerable<BlogComment> GetAll()
        {
            var blogComment = db.blogComments.Include(x => x.Blog).ToList();
            return blogComment;
        }
        public IEnumerable<BlogComment> GetCommentByBlogId(int blogId)
        {
            return db.blogComments.Where(x => x.BlogID == blogId);
        }
        public BlogComment GetByID(int CommentID)
        {
            var getId = db.blogComments.Find(CommentID);
            return getId;
        }
        public bool Create(BlogComment blogComment)
        {
            var addToComment = db.blogComments.Add(blogComment);
            return true;
        }
        public bool DeleteById(int BlogCommentID)
        {
            var getId = GetByID(BlogCommentID);
            db.blogComments.Remove(getId);
            return true;
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }


    }
}
