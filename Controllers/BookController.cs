using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class BookController : Controller
    {
        BookManagementEntities db = new BookManagementEntities();
        // GET: Book
        public ActionResult Index()
        {
            var q = db.Books.Where(x=>x.BookStatu.Status != "Buyable" && x.Reading.ReadingStatus!= null).ToList();
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
        public ActionResult Create(Book b, DateTime BuyingDate, HttpPostedFileBase Image)
        {
            Book book = new Book();
            List<Category> CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryID", "CategoryName");
            List<Author> AuthorList = db.Authors.ToList();
            ViewBag.AuthorList = new SelectList(AuthorList, "AuthorId", "AuthorName");
            List<BookStatu> SatList = db.BookStatus.ToList();
            ViewBag.SatList = new SelectList(SatList, "BookStatusId", "Status");
            b.ReadingId = 2;
            b.BuyingDate = BuyingDate.Date;

            b.Photo = Image.FileName.ToString();

            var folder = Server.MapPath("~/Uploads/");
            Image.SaveAs(Path.Combine(folder, Image.FileName.ToString()));

            db.Books.Add(b);
            db.SaveChanges();

          

            return RedirectToAction("Index", "Book");

        }

        //Get Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            List<Category> CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryId", "CategoryName");
            List<Author> AuthorList = db.Authors.ToList();
            ViewBag.AuthorList = new SelectList(AuthorList, "AuthorId", "AuthorName");
            List<BookStatu> SatList = db.BookStatus.ToList();
            ViewBag.SatList = new SelectList(SatList, "BookStatusId", "Status");
            List<Reading> ReadList = db.Readings.ToList();
            ViewBag.ReadList = new SelectList(ReadList, "ReadingId", "ReadingStatus");
            var query = db.Books.Where(m => m.BookId == id).ToList().SingleOrDefault();

            if (query == null)
            {
               return HttpNotFound();
            }
            else
            {
                Session["image"] = query.Photo;
                return View(query);
            }
           
            
        }

        //Post Edit
        [HttpPost]
        public ActionResult Edit(Book b, HttpPostedFileBase Image)
        {
            //GetViewBagData();
            var book = new Book();
            List<Category> CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryId", "CategoryName");
            List<Author> AuthorList = db.Authors.ToList();
            ViewBag.AuthorList = new SelectList(AuthorList, "AuthorId", "AuthorName");
            List<BookStatu> SatList = db.BookStatus.ToList();
            ViewBag.SatList = new SelectList(SatList, "BookStatusId", "Status");
            List<Reading> ReadList = db.Readings.ToList();
            ViewBag.ReadList = new SelectList(ReadList, "ReadingId", "ReadingStatus");
            try
            {

                if (Image != null)
                {
                    
                    b.Photo = Image.FileName.ToString();
                    var folder = Server.MapPath("~/Uploads/");
                    Image.SaveAs(Path.Combine(folder, Image.FileName.ToString()));
                    db.Entry(b).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Book");
                }
                else
                {

                    
                    b.Photo = Session["image"].ToString();
                    
                    db.Entry(b).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Book");
                }

                
            }
            catch
            {
                TempData["msg"] = "Product isn't updated!" +
                    "You must update the product Image..";
                return RedirectToAction("Edit", "Book");
            }
        }

        public ActionResult Delete(int? id)
        {
            var query = db.Books.SingleOrDefault(m => m.BookId== id);
            db.Books.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        public ActionResult Completed()
        {
            var q = db.Books.Where(x => x.Reading.ReadingStatus == "Completed" && x.EndDate != null).ToList();
            return View(q);
        }

    }
}