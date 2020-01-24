using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository _repo)
        {
            _categoryRepository = _repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(_categoryRepository.GetAll());
        }
       
        public IActionResult AddOrUpdate(int? id)
        {
            if (id == null)
            {
                return View(new Category());
            }
            else
            {
                return View(_categoryRepository.GetById((int)id));
            } 
        }
        [HttpPost]
        public IActionResult AddOrUpdate(Category entity)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.SaveCategory(entity);
                TempData["message"] = $"{entity.Name} kayıt edildi.";
                return RedirectToAction("List");
            }
            return View(entity);
        }

        public IActionResult Delete(int id)
        {
            return View(_categoryRepository.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int CategoryId)
        {
            _categoryRepository.DeleteCategory(CategoryId);
            TempData["message"] = $"{CategoryId} numaralı kayıt silindi";
            return RedirectToAction("List");
        }
    }
}