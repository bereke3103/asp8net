using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() 
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "They do not have to be the same");
            }

            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalide value");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                //Index - action
                //Category - Controller
                return RedirectToAction("Index", "Category");
            }

            return View();
           
        }





        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }

            Category categoryFromDv = _db.Categories.Find(id);

            if (categoryFromDv == null)
            {
                return NotFound();
            }

            return View(categoryFromDv);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "They do not have to be the same");
            }

            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalide value");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfully";

                //Index - action
                //Category - Controller
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

            Category categoryFromDv = _db.Categories.Find(id);

            if (categoryFromDv == null)
            {
                return NotFound();
            }

            return View(categoryFromDv);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category removed successfully";
            //Index - action
            //Category - Controller
            return RedirectToAction("Index", "Category");


        }

    }
}
