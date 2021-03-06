using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class RunBookController : Controller
    {
        BookManagementEntities db = new BookManagementEntities();
        // GET: RunBook
        public ActionResult Index()
        {
            var q = db.Books.Where(x=>x.Reading.ReadingStatus == "Running").ToList();
           
            return View(q);
        }

        public ActionResult Edit(int?id)
        {
            List<Reading> ReadList = db.Readings.ToList();
            ViewBag.ReadList = new SelectList(ReadList, "ReadingId", "ReadingStatus");
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
            List<Reading> ReadList = db.Readings.ToList();
            ViewBag.ReadList = new SelectList(ReadList, "ReadingId", "ReadingStatus");
            try
            {
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "RunBook");
            }
            catch
            {
                TempData["msg"] = "Product isn't updated!" +
                    "You must update the product Image..";
                return RedirectToAction("Edit", "RunBook");
            }
        }
    }
}