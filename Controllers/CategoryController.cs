using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        BookManagementEntities db = new BookManagementEntities();
        // GET: Category
        public ActionResult Index()
        {
            var q = db.Categories.ToList();
            return View(q);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category c)
        {
            var ed = db.Categories.Where(x => x.CategoryName == c.CategoryName).SingleOrDefault();
            if(ed!=null)
            {
                TempData["msg"] = "Category Name has already been added! Try another...";
                return RedirectToAction("Create", "Category");
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    Category cat = new Category();
                    cat.CategoryName = c.CategoryName;
                    db.Categories.Add(cat);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    TempData["msg"] = "Failed Attempt!";
                    return RedirectToAction("Create", "Category");
                }
            }
           
        }

        #region Edit
        public ActionResult Edit(int? id)
        {

           
                var query = db.Categories.Where(m => m.CategoryId == id).ToList().FirstOrDefault();
                return View(query);
           
        }

        [HttpPost]
        public ActionResult Edit(Category c)
        {
            try
            {

                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex;
            }
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Delete(int? id)
        {
            var query = db.Categories.SingleOrDefault(m => m.CategoryId == id);
            db.Categories.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        //Category Ends

        #endregion
    }
}