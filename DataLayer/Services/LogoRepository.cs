using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Models.ViewModel;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class LogoRepository : ILogoRepository
    {
        // Dependency
        private MyBlogContext db;
        public LogoRepository(MyBlogContext contetx)
        {
            this.db = contetx;
        }

        public IEnumerable<Logo> GetAll()
        {
            var list = db.logos.ToList();
            return list;
        }

        public Logo GetByID(int LogoID)
        {
            var getById = db.logos.Find(LogoID);
            return getById;
        }

        public LogoViewModel GetByIdForVM(int LogoID)
        {
            throw new NotImplementedException();
        }
        public bool Create(Logo logo)
        {
            try
            {
                var AddLogo = db.logos.Add(logo);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن لوگو با خطا مواجه شد.");
            }
        }
        public bool Edit(Logo logo)
        {
            try
            {
                db.Entry(logo).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش لوگو با خطا مواجه شد.");
            }
        }

        public bool Delete(int LogoID)
        {
            try
            {
                var getId = GetByID(LogoID);
                db.logos.Remove(getId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف لوگو با خطا مواجه شد.");
            }
        }

        public int LogoCount()
        {
            var getCount = db.logos.Count();
            return getCount;
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
