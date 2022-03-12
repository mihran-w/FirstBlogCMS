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
    public class AdminLoginRepository : IAdminLoginRepository
    {
        // Dependency Injection
        private MyBlogContext db;
        public AdminLoginRepository(MyBlogContext context)
        {
            this.db = context;
        }


        public IEnumerable<AdminLogins> GetAll()
        {
            var getAll = db.adminLogins.ToList();
            return getAll;
        }

        public AdminLogins GetById(int loginId)
        {
            var getId = db.adminLogins.Find(loginId);
            return getId;
        }

        public bool Create(AdminLogins login)
        {
            try
            {
                var addAdmin = db.adminLogins.Add(login);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن کاربر با خطا مواجه شد");
            }
        }

        public bool Edit(AdminLogins login)
        {
            try
            {
                db.Entry(login).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش کاربر با خطا مواجه شد");
            }
        }

        public bool DeleteById(int loginId)
        {
            try
            {
                var getId = GetById(loginId);
                db.adminLogins.Remove(getId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف کاربر با خطا مواجه شد");
            }
        }

        public bool IsExistUser(string username, string password)
        {
            return db.adminLogins.Any(a => a.UserName == username && a.Password == password);
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
