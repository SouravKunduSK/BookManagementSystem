using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        BookManagementEntities db = new BookManagementEntities();
        // GET: Author
        public ActionResult Index()
        {
            var q = db.Authors.ToList();
            return View(q);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author a)
        {
            var ed = db.Authors.Where(x => x.AuthorName == a.AuthorName).SingleOrDefault();
            if (ed != null)
            {
                TempData["msg"] = "Category Name has already been added! Try another...";
                return RedirectToAction("Create", "Author");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    Author aut = new Author();
                    aut.AuthorName = a.AuthorName;
                    db.Authors.Add(aut);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    TempData["msg"] = "Failed Attempt!";
                    return RedirectToAction("Create", "Author");
                }
            }

        }

        #region Edit
        public ActionResult Edit(int? id)
        {


            var query = db.Authors.Where(m => m.AuthorId == id).ToList().FirstOrDefault();
            return View(query);

        }

        [HttpPost]
        public ActionResult Edit(Author a)
        {
            try
            {

                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Author");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex;
            }
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Delete(int? id)
        {
            var query = db.Authors.SingleOrDefault(m => m.AuthorId == id);
            db.Authors.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index", "Author");
        }

       

        #endregion
    }
}