using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Services;

namespace MyBlogCMS.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminLoginsController : Controller
    {
        private IAdminLoginRepository adminLoginRepository;
        private MyBlogContext db = new MyBlogContext();
        public AdminLoginsController()
        {
            adminLoginRepository = new AdminLoginRepository(db);
        }

        // GET: Admin/AdminLogins
        public ActionResult Index()
        {
            return View(adminLoginRepository.GetAll());
        }

        // GET: Admin/AdminLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogins adminLogins = adminLoginRepository.GetById(id.Value);
            if (adminLogins == null)
            {
                return HttpNotFound();
            }
            return View(adminLogins);
        }

        // GET: Admin/AdminLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginId,UserName,Email,Password")] AdminLogins adminLogins)
        {
            if (ModelState.IsValid)
            {
                adminLoginRepository.Create(adminLogins);
                adminLoginRepository.Save();
                return RedirectToAction("Index");
            }

            return View(adminLogins);
        }

        // GET: Admin/AdminLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogins adminLogins = adminLoginRepository.GetById(id.Value);
            if (adminLogins == null)
            {
                return HttpNotFound();
            }
            return View(adminLogins);
        }

        // POST: Admin/AdminLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginId,UserName,Email,Password")] AdminLogins adminLogins)
        {
            if (ModelState.IsValid)
            {
                adminLoginRepository.Edit(adminLogins);
                adminLoginRepository.Save();
                return RedirectToAction("Index");
            }
            return View(adminLogins);
        }

        // GET: Admin/AdminLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogins adminLogins = adminLoginRepository.GetById(id.Value);
            if (adminLogins == null)
            {
                return HttpNotFound();
            }
            return View(adminLogins);
        }

        // POST: Admin/AdminLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminLogins adminLogins = adminLoginRepository.GetById(id);
            adminLoginRepository.DeleteById(id);
            adminLoginRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                adminLoginRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
