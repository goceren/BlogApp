using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        private ICategoryRepository _categoryRepository;
        public BlogController(IBlogRepository _blogRepo, ICategoryRepository _categoryRepo)
        {
            _blogRepository = _blogRepo;
            _categoryRepository = _categoryRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(_blogRepository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog entity)
        {
            //Kayıt işlemi yapılacak
            entity.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                _blogRepository.AddBlog(entity);
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "Name");
            return View(entity);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "Name");
            return View(_blogRepository.GetById(id));
        }
        
        [HttpPost]
        public IActionResult Edit(Blog entity)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.UpdateBlog(entity);
                TempData["message"] = $"{entity.Title} güncellendi";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "Name");
                return View(entity);
            }
        }
    }
}