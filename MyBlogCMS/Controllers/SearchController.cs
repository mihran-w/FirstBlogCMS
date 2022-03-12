using DataLayer.Context;
using DataLayer.Repositories;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogCMS.Controllers
{
    public class SearchController : Controller
    {
        private IBlogRepository blogRepository;
        MyBlogContext db = new MyBlogContext();
        public SearchController()
        {
            blogRepository = new BlogRepository(db);
        }


        // GET: Search
        public ActionResult Index(string qSearch , int id =1)
        {
            int take = 3;
            ViewBag.CurrentBlog = id;
            ViewBag.CountBlog = blogRepository.CountBlog() / take;
            var SearchResult = blogRepository.Search(qSearch);
            ViewBag.SearchParam = qSearch;

            return View(SearchResult);
        }
    }
}