using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogCMS.Controllers
{
    public class ProjectGalleryController : Controller
    {
        private IProjectGalleryRepository projectGalleryRepository;
        private MyBlogContext db = new MyBlogContext();
        public ProjectGalleryController()
        {
            projectGalleryRepository = new ProjectGalleryRepository(db);
        }


        // GET: ProjectGallery
        [Route("Gallery/{id}")]
        public ActionResult Gallery(int id = 1)
        {
            int take = 6;
            ViewBag.CurrentGallery = id;
            ViewBag.CountGallery = projectGalleryRepository.CountGallery() / take;
            var getGalleryArchive = projectGalleryRepository.getArchiveGallery(id);

            return View(getGalleryArchive);
        }

        [Route("ShowGallery/{galleryId}")]
        public ActionResult ShowGallery(int galleryId)
        {
            
            var getGallery = projectGalleryRepository.GetById(galleryId);
            if (getGallery == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrentGallery = galleryId;
            return View(getGallery);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                projectGalleryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}