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
    public class LogoesController : Controller
    {
        private ILogoRepository logoRepository;
        private MyBlogContext db = new MyBlogContext();
        public LogoesController()
        {
            logoRepository = new LogoRepository(db);
        }

        // GET: Admin/Logoes
        public ActionResult Index()
        {
            return View(logoRepository.GetAll());
        }

        // GET: Admin/Logoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = logoRepository.GetByID(id.Value);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // GET: Admin/Logoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Logoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogoViewModel logoVM)
        {
            if (ModelState.IsValid)
            {
                var getCount = logoRepository.LogoCount();
                if(getCount >= 1)
                {
                    ModelState.AddModelError("", "نباید تکراری و بیش از یک یا کمتر از آن باشد.");
                    return RedirectToAction("Index");
                }

                Logo logo = new Logo()
                {
                    LogoID = logoVM.LogoID,
                    Title = logoVM.Title,
                    ImageName = logoVM.ImageName
                };
                if(logoVM.LogoImageUpload != null)
                {
                    logo.ImageName = Guid.NewGuid() + Path.GetExtension(logoVM.LogoImageUpload.FileName);
                    logoVM.LogoImageUpload.SaveAs(Server.MapPath("/Images/Logoes/" + logo.ImageName));
                }
                logoRepository.Create(logo);
                logoRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/Logoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = logoRepository.GetByID(id.Value);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: Admin/Logoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LogoViewModel logoVM)
        {
            if (ModelState.IsValid)
            {

                Logo logo = new Logo()
                {
                    LogoID = logoVM.LogoID,
                    Title = logoVM.Title,
                    ImageName = logoVM.ImageName,
                };
                if(logoVM.LogoImageUpload != null)
                {
                    if(logo.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/Logoes/" + logo.ImageName));
                    }

                    logo.ImageName = Guid.NewGuid() + Path.GetExtension(logoVM.LogoImageUpload.FileName);
                    logoVM.LogoImageUpload.SaveAs(Server.MapPath("/Images/Logoes/" + logo.ImageName));
                }

                logoRepository.Edit(logo);
                logoRepository.Save();
                return RedirectToAction("Index");
            }
            return View(logoVM);
        }

        // GET: Admin/Logoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = logoRepository.GetByID(id.Value);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: Admin/Logoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logo logo = logoRepository.GetByID(id);
            logoRepository.Delete(id);
            logoRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                logoRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
