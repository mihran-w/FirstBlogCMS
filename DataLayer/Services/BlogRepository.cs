using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using System.Data.Entity;
using DataLayer.Models.ViewModel;

namespace DataLayer.Services
{
    public class BlogRepository : IBlogRepository
    {
        // Dependency
        private MyBlogContext db;
        public BlogRepository(MyBlogContext context)
        {
            this.db = context;
        }


        public IEnumerable<Blog> ArchiveBlog(int id = 1)
        {
            int take = 6;
            int skip = (id - 1) * take;
             
            return (db.Blogs.OrderBy(b => b.CreateDate).Skip(skip).Take(take).ToList()); 
        }

        public int CountBlog()
        {
            return (db.Blogs.Count());
        }

        public IEnumerable<Blog> GetAll()
        {
            var GetList = db.Blogs.ToList();
            return GetList;
        }
        public IEnumerable<Blog> GetLastBlog(int take = 3)
        {
            var getLastBlogs = db.Blogs.OrderByDescending(x => x.CreateDate).Take(take);
            return getLastBlogs;
        }

        public Blog GetByID(int BlogId)
        {
            var getId = db.Blogs.Find(BlogId);
            return getId;
            
        }
        public bool Create(Blog blog)
        {
            try
            {
                var AddtoBlog = db.Blogs.Add(blog);
                return true;
            }
            catch
            {
                throw new Exception("عملیات ایجاد بلاک با خطا مواجه شد");
            }
        }
        public bool Edit(Blog blog)
        {
            try
            {
                db.Entry(blog).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش بلاک با خطا مواجه شد");
            }
        }

        public bool Delete(int BlogID)
        {
            try
            {
                var getID = GetByID(BlogID);
                db.Blogs.Remove(getID);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف بلاک با خطا مواجه شد");
            }
        }

        public BlogViewModel GetByIdForVM(int BlogId)
        {
            var getID = db.Blogs.Where(x => x.BlogID == BlogId).Select(x => new BlogViewModel()
            {
                BlogID = x.BlogID,
                GroupID = x.GroupID,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                BlogText = x.BlogText,
                ImageName = x.ImageName,
                visit = x.visit,
                CreateDate = x.CreateDate,
                BlogTag = x.BlogTag

            }).FirstOrDefault();
            return getID;
        }

        public IEnumerable<Blog> Search(string Param)
        {
            return db.Blogs.Where(b => b.Title.Contains(Param) || b.BlogTag.Contains(Param) || b.BlogText.Contains(Param) || b.ShortDescription.Contains(Param)).Distinct();
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
