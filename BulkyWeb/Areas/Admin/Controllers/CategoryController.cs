using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                //Index - action
                //Category - Controller
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

            Category categoryFromDv = _unitOfWork.Category.Get(u => u.Id == id);

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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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

            Category categoryFromDv = _unitOfWork.Category.Get(u => u.Id == id);

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
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category removed successfully";
            //Index - action
            //Category - Controller
            return RedirectToAction("Index", "Category");


        }

    }
}
