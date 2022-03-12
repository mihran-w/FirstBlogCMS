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
    public class HomeController : Controller
    {
        private ISliderRepository sliderRepository;
        private ILogoRepository logoRepository;
        private IAdminLoginRepository adminLoginRepository;
        private MyBlogContext db = new MyBlogContext();
        public HomeController()
        {
            sliderRepository = new SliderRepository(db);
            logoRepository = new LogoRepository(db);
            adminLoginRepository = new AdminLoginRepository(db);
        }
        public ActionResult Index()
        {
            ViewBag.CurrentBlog = 1;
            ViewBag.CurrentGallery = 1;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logo()
        {
            return PartialView(logoRepository.GetAll());
        }

        public ActionResult Slider()
        {
            return PartialView(sliderRepository.GetAll());
        }

    }
}