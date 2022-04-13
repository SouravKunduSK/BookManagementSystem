using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class BuyBookController : Controller
    {
        BookManagementEntities db = new BookManagementEntities();
        // GET: BuyBook
        public ActionResult Index()
        {
            var q = db.Books.Where(x => x.BookStatu.Status == "Buyable").ToList();
            return View(q);
        }

        public ActionResult Create()
        {
            List<Category> CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryId", "CategoryName");
            List<Author> AuthorList = db.Authors.ToList();
            ViewBag.AuthorList = new SelectList(AuthorList, "AuthorId", "AuthorName");
            List<BookStatu> SatList = db.BookStatus.ToList();
            ViewBag.SatList = new SelectList(SatList, "BookStatusId", "Status");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book b, HttpPostedFileBase Image)
        {
            List<Category> CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryId", "CategoryName");
            List<Author> AuthorList = db.Authors.ToList();
            ViewBag.AuthorList = new SelectList(AuthorList, "AuthorId", "AuthorName");
            List<BookStatu> SatList = db.BookStatus.ToList();
            ViewBag.SatList = new SelectList(SatList, "BookStatusId", "Status");
            b.Photo = Image.FileName.ToString();

            var folder = Server.MapPath("~/Uploads/");
            Image.SaveAs(Path.Combine(folder, Image.FileName.ToString()));
            db.Books.Add(b);
            db.SaveChanges();



            return RedirectToAction("Index", "BuyBook");
        }


        public ActionResult Delete(int? id)
        {
            var query = db.Books.SingleOrDefault(m => m.BookId == id);
            db.Books.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index", "BuyBook");
        }
    }
}