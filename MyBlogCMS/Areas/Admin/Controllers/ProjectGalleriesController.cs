using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Models.ViewModel;
using DataLayer.Repositories;
using DataLayer.Services;

namespace MyBlogCMS.Areas.Admin.Controllers
{
    [Authorize]
    public class ProjectGalleriesController : Controller
    {
        private IProjectGalleryRepository projectGalleryRepository;
        private MyBlogContext db = new MyBlogContext();
        public ProjectGalleriesController()
        {
            projectGalleryRepository = new ProjectGalleryRepository(db);
        }

        // GET: Admin/ProjectGalleries
        public ActionResult Index()
        {
            return View(projectGalleryRepository.GetAll());
        }

        // GET: Admin/ProjectGalleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectGallery projectGallery = projectGalleryRepository.GetById(id.Value);
            if (projectGallery == null)
            {
                return HttpNotFound();
            }
            return View(projectGallery);
        }

        // GET: Admin/ProjectGalleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProjectGalleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectGalleryViewModel pGalleryVM)
        {
            if (ModelState.IsValid)
            {
                ProjectGallery projectGallery = new ProjectGallery()
                {
                    pGalleryId = pGalleryVM.pGalleryId,
                    Title = pGalleryVM.Title,
                    ShortDes = pGalleryVM.ShortDes,
                    Text = pGalleryVM.Text,
                    Customer = pGalleryVM.Customer,
                    CreateDate = pGalleryVM.CreateDate,
                    Website = pGalleryVM.Website,
                    Location = pGalleryVM.Location,
                    ImageName = pGalleryVM.ImageName
                };
                if (pGalleryVM.GalleryImageUpload != null)
                {
                    projectGallery.ImageName = Guid.NewGuid() + Path.GetExtension(pGalleryVM.GalleryImageUpload.FileName);
                    pGalleryVM.GalleryImageUpload.SaveAs(Server.MapPath("/Images/ProjectGallery/" + projectGallery.ImageName));
                }

                projectGalleryRepository.Create(projectGallery);
                projectGalleryRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/ProjectGalleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectGallery projectGallery = projectGalleryRepository.GetById(id.Value);
            if (projectGallery == null)
            {
                return HttpNotFound();
            }
            return View(projectGallery);
        }

        // POST: Admin/ProjectGalleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectGalleryViewModel pGalleryVM)
        {
            if (ModelState.IsValid)
            {

                ProjectGallery projectGallery = new ProjectGallery()
                {
                    pGalleryId = pGalleryVM.pGalleryId,
                    Title = pGalleryVM.Title,
                    ShortDes = pGalleryVM.ShortDes,
                    Text = pGalleryVM.Text,
                    Customer = pGalleryVM.Customer,
                    CreateDate = pGalleryVM.CreateDate,
                    Website = pGalleryVM.Website,
                    Location = pGalleryVM.Location,
                    ImageName = pGalleryVM.ImageName,
                };

                if (pGalleryVM.GalleryImageUpload != null)
                {
                    if (projectGallery.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/ProjectGallery/" + projectGallery.ImageName));
                    }
                    projectGallery.ImageName = Guid.NewGuid() + Path.GetExtension(pGalleryVM.GalleryImageUpload.FileName);
                    pGalleryVM.GalleryImageUpload.SaveAs(Server.MapPath("/Images/ProjectGallery/" + projectGallery.ImageName));
                }

                projectGalleryRepository.Edit(projectGallery);
                projectGalleryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(pGalleryVM);
        }

        // GET: Admin/ProjectGalleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectGallery projectGallery = projectGalleryRepository.GetById(id.Value);
            if (projectGallery == null)
            {
                return HttpNotFound();
            }
            return View(projectGallery);
        }

        // POST: Admin/ProjectGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectGallery projectGallery = projectGalleryRepository.GetById(id);

            if(projectGallery.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/ProjectGallery/" + projectGallery.ImageName));
            }

            projectGalleryRepository.Delete(id);
            projectGalleryRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                projectGalleryRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
