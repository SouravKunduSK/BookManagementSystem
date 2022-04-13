using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class LendController : Controller
    {
        BookManagementEntities db = new BookManagementEntities();
        // GET: Lend
        public ActionResult Index()
        {
            var q = db.Books.Where(x => x.BookStatu.Status == "Lended").ToList();
            return View(q);
        }

        public ActionResult Edit(int?id)
        {
            List<BookStatu> SatList = db.BookStatus.ToList();
            ViewBag.SatList = new SelectList(SatList, "BookStatusId", "Status");
            var query = db.Books.Where(m => m.BookId == id).ToList().SingleOrDefault();

            if (query == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(query);
            }
        }

        [HttpPost]
        public ActionResult Edit(Book b)
        {
            List<BookStatu> SatList = db.BookStatus.ToList();
            ViewBag.SatList = new SelectList(SatList, "BookStatusId", "Status");
            try
            {



                db.Entry(b).State = EntityState.Modified;

                db.SaveChanges();


                return RedirectToAction("Index", "Lend");
            }
            catch
            {
                TempData["msg"] = "Product isn't updated!" +
                    "You must update the product Image..";
                return RedirectToAction("Edit", "Lend");
            }
        }
    }
}