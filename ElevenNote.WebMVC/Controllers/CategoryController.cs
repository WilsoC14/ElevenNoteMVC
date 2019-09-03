using ElevenNote.Data;
using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var service = new CategoryService();
            var model = service.GetCategories();
            return View(model);
        }

        //Get: Create
        public ActionResult Create()
        {

            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CategoryService();
           // return service;

            
            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        //Get: Edit
        public ActionResult Edit(int id)
        {
            var service = new CategoryService();
            var detail = service.GetCategoryById(id);
            var model = new CategoryEdit
            {
                CategoryId = detail.CategoryId,
                Name = detail.Name,
                Description = detail.Description
            };
            return View(model);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, CategoryEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new CategoryService();
            if(service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your Category was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Category could not be updated");
            return View();

        }

        //Get Delete
        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var service = new CategoryService();
            var model = service.GetCategoryById(id);
            return View(model);
        }

        //Post Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new CategoryService();
            service.DeleteCategory(id);
            TempData["SaveResult"] = "Your note was deleted";
            return RedirectToAction("Index");
        }


        public ActionResult Details (int id)
        {
            var service = new CategoryService();
            var model = service.GetCategoryById(id);
            return View(model);
        }
    }
}