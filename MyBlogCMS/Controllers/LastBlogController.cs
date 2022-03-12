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
    public class LastBlogController : Controller
    {
        private IBlogRepository blogRepository;
        private IBlogCommentRepository blogCommentRepository;
        private MyBlogContext db = new MyBlogContext();
        public LastBlogController()
        {
            blogRepository = new BlogRepository(db);
            blogCommentRepository = new BlogCommentRepository(db);
        }

        // GET: LastBlog
        public ActionResult LastBlogs()
        {
            return PartialView(blogRepository.GetLastBlog());
        }

        // Left Last Blogs
        public ActionResult LeftCornerLastBlogs()
        {
            return PartialView(blogRepository.GetLastBlog());
        }


        [Route("Archive/{id}")]
        public ActionResult Archive(int id = 1)
        {
            int take = 6;
            ViewBag.CurrentBlog = id;
            ViewBag.CountBlog = blogRepository.CountBlog() / take;
            var getArchiveBlogs = blogRepository.ArchiveBlog(id);

            return View(getArchiveBlogs);
        }

        [Route("Blogs/{id}")]
        public ActionResult ShowBlogs(int id)
        {
            var blogs = blogRepository.GetByID(id);
            if (blogs == null)
            {
                return HttpNotFound();
            }

            blogs.visit += 1;
            blogRepository.Edit(blogs);
            blogRepository.Save();

            return View(blogs);
        }


        // Add Comments 
        public ActionResult addComment(int id, string name, string email, string comment)
        {
            BlogComment addComment = new BlogComment()
            {
                BlogID = id,
                Name = name,
                Email = email,
                Comment = comment
            };
            addComment.CreateDate = DateTime.Now;
            blogCommentRepository.Create(addComment);
            blogCommentRepository.Save();

            return PartialView("ShowComment", blogCommentRepository.GetCommentByBlogId(id));
        }

        // Show Comment
        public ActionResult ShowComment(int id)
        {
            return PartialView(blogCommentRepository.GetCommentByBlogId(id));
        }


    }
}