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
using MyBlogCMS.Utilities;

namespace MyBlogCMS.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private IBlogRepository blogRepository;
        private IBlogGroupRepository blogGroupRepository;
        private MyBlogContext db = new MyBlogContext();
        public BlogsController()
        {
            blogRepository = new BlogRepository(db);
            blogGroupRepository = new BlogGroupRepository(db);
        }

        // GET: Admin/Blogs
        public ActionResult Index()
        {
            ViewBag.CountBlog = blogRepository.CountBlog();
            var list = blogRepository.GetAll();
            return View(list);

        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogRepository.GetByID(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.blogGroups, "GroupID", "GroupName");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogViewModel blogVM)
        {
            if (ModelState.IsValid)
            {
                Blog blog = new Blog()
                {
                    BlogID = blogVM.BlogID,
                    GroupID = blogVM.GroupID,
                    Title = blogVM.Title,
                    ShortDescription = blogVM.ShortDescription,
                    BlogText = blogVM.BlogText,
                    ImageName = blogVM.ImageName,
                    visit = blogVM.visit,
                    CreateDate = blogVM.CreateDate,
                    BlogTag = blogVM.BlogTag
                };

                blog.visit = 0;
                blog.CreateDate = DateTime.Now;
                if (blogVM.blogImageUpload != null)
                {
                    blog.ImageName = Guid.NewGuid() + Path.GetExtension(blogVM.blogImageUpload.FileName);
                    blogVM.blogImageUpload.SaveAs(Server.MapPath("/Images/" + blog.ImageName));
                }


                blogRepository.Create(blog);
                blogRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(blogGroupRepository.GetAll(), "GroupID", "GroupName");
            return View();
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogViewModel blog = blogRepository.GetByIdForVM(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(blogGroupRepository.GetAll(), "GroupID", "GroupName", blog.GroupID);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogViewModel blogVM)
        {
            if (ModelState.IsValid)
            {
                Blog blog = new Blog()
                {
                    BlogID = blogVM.BlogID,
                    GroupID = blogVM.GroupID,
                    Title = blogVM.Title,
                    ShortDescription = blogVM.ShortDescription,
                    BlogText = blogVM.BlogText,
                    ImageName = blogVM.ImageName,
                    visit = blogVM.visit,
                    CreateDate = blogVM.CreateDate,
                    BlogTag = blogVM.BlogTag
                };


                if (blogVM.blogImageUpload != null)
                {
                    if (blog.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/" + blog.ImageName));
                    }

                    blog.ImageName = Guid.NewGuid() + Path.GetExtension(blogVM.blogImageUpload.FileName);
                    blogVM.blogImageUpload.SaveAs(Server.MapPath("/Images/" + blog.ImageName));
                }


                blogRepository.Edit(blog);
                blogRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(blogGroupRepository.GetAll(), "GroupID", "GroupName", blogVM.GroupID);
            return View(blogVM);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogRepository.GetByID(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = blogRepository.GetByID(id);
            if (blog.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/" + blog.ImageName));
            }

            blogRepository.Delete(id);
            blogRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blogGroupRepository.Dispose();
                blogRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
