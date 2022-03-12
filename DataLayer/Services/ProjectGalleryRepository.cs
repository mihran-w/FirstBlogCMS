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
    public class ProjectGalleryRepository : IProjectGalleryRepository
    {
        private MyBlogContext db;
        public ProjectGalleryRepository(MyBlogContext context)
        {
            this.db = context;
        }
        public IEnumerable<ProjectGallery> GetAll()
        {
            return db.projectGalleries.ToList();
        }
        public ProjectGallery GetById(int pGalleryid)
        {
            var getId = db.projectGalleries.Find(pGalleryid);
            return getId;
        }

        public IEnumerable<ProjectGallery> getArchiveGallery(int id = 1)
        {
            int take = 6;
            int skip = (id - 1) * take;
            return (db.projectGalleries.OrderByDescending(p => p.CreateDate).Skip(skip).Take(take));
        }

        public ProjectGalleryViewModel getByVM(int pGalleryid)
        {
            var getId = db.projectGalleries.Where(p => p.pGalleryId == pGalleryid).Select(p => new ProjectGalleryViewModel()
            {
                pGalleryId = p.pGalleryId,
                ShortDes = p.ShortDes,
                Text = p.Text,
                Customer = p.Customer,
                CreateDate = p.CreateDate,
                Website = p.Website,
                ImageName = p.ImageName,
                Location = p.Location,
                Title = p.Title
            }).FirstOrDefault();
            return getId;
        }
        public int CountGallery()
        {
            int Count = db.projectGalleries.Count();
            return Count;
        }

        public bool Create(ProjectGallery projectGallery)
        {
            try
            {
                db.projectGalleries.Add(projectGallery);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن با خطا مواجه شد");
            }
        }

        public bool Delete(int pGalleryid)
        {
            try
            {
                var getId = GetById(pGalleryid);
                db.projectGalleries.Remove(getId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف با خطا مواجه شد");
            }
        }

        public bool Edit(ProjectGallery projectGallery)
        {
            try
            {
                db.Entry(projectGallery).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش با خطا مواجه شد");
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
