using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.ViewComponents
{
    public class CategoryMenuViewComponent: ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        public CategoryMenuViewComponent(ICategoryRepository repo)
        {
            _categoryRepository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["id"];
            return View(_categoryRepository.GetAll());
        }
    }
}
