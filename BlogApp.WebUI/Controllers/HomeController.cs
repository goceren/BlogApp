using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository blogRepository;
        public HomeController(IBlogRepository repository)
        {
            blogRepository = repository;
        }
        public IActionResult Index()
        {
            HomeBlogModel model = new HomeBlogModel();
            model.HomeBlogs = blogRepository.GetAll().Where(i => i.isApproved && i.IsHome).ToList();
            model.SliderBlogs = blogRepository.GetAll().Where(i => i.isApproved && i.IsSlider).ToList();
            return View(model);
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}