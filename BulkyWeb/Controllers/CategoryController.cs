using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepositry;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepositry = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepositry.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepositry.Add(obj);
                _categoryRepositry.Save();
                TempData["Success"] = "Category Created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromDb = _categoryRepositry.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepositry.Update(obj);
                _categoryRepositry.Save();
                TempData["Success"] = "Category Edted successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromDb = _categoryRepositry.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletPOST(int id)
        {
            Category obj = _categoryRepositry.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepositry.Remove(obj);
            _categoryRepositry.Save();
            TempData["Success"] = "Category Deleted successfully";
            return RedirectToAction("Index", "Category");
        }

    }
}