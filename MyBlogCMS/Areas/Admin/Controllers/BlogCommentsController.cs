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
    public class BlogCommentsController : Controller
    {
        private IBlogRepository blogRepository;
        private IBlogCommentRepository blogCommentRepository;
        private MyBlogContext db = new MyBlogContext();
        public BlogCommentsController()
        {
            blogRepository = new BlogRepository(db);
            blogCommentRepository = new BlogCommentRepository(db);
        }

        // GET: Admin/BlogComments
        public ActionResult Index()
        {
            var blogComments = blogCommentRepository.GetAll();
            return View(blogComments);
        }

        // GET: Admin/BlogComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = blogCommentRepository.GetByID(id.Value);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // GET: Admin/BlogComments/Create
        public ActionResult Create()
        {
            ViewBag.BlogID = new SelectList(blogRepository.GetAll(), "BlogID", "Title");
            return View();
        }

        // POST: Admin/BlogComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,BlogID,Name,Email,Website,Comment,CreateDate")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                blogComment.CreateDate = DateTime.Now;
                blogCommentRepository.Create(blogComment);
                blogCommentRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.BlogID = new SelectList(blogRepository.GetAll(), "BlogID", "Title", blogComment.BlogID);
            return View(blogComment);
        }


        // GET: Admin/BlogComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = blogCommentRepository.GetByID(id.Value);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // POST: Admin/BlogComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogComment blogComment = blogCommentRepository.GetByID(id);
            blogCommentRepository.DeleteById(id);
            blogCommentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blogRepository.Dispose();
                blogCommentRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
