using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class BlogGroupRepository : IBlogGroupRepository
    {
        // Dependency
        private MyBlogContext db;
        public BlogGroupRepository(MyBlogContext context)
        {
            this.db = context;
        }


        public IEnumerable<BlogGroup> GetAll()
        {
            var list = db.blogGroups.ToList();
            return list;
        }

        public BlogGroup GetByID(int GroupID)
        {
            var GetId = db.blogGroups.Find(GroupID);
            return GetId;
        }

        public bool Create(BlogGroup blogGroup)
        {
            try
            {
                var AddToGroup = db.blogGroups.Add(blogGroup);
                return true;
            }
            catch
            {
                throw new Exception("عملیات ایجاد گروه با خطا مواجه شد");
            }
        }
        public bool Edit(BlogGroup blogGroup)
        {
            try
            {
                db.Entry(blogGroup).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش با خطا مواجه شد");
            }
        }

        public bool DeleteByID(int GroupID)
        {
            try
            {
                var GetId = GetByID(GroupID);
                db.blogGroups.Remove(GetId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف با خطا مواجه شد");
            }
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
