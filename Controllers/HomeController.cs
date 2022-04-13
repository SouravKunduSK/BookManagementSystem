using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        BookManagementEntities db = new BookManagementEntities();
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                ViewBag.latest = db.Books.Where(x => x.BuyingDate!=null).Take(10).ToList();
                ViewBag.AllBooks = db.Books.Where(x => x.BookStatu.Status != "Buyable" && x.Reading.ReadingStatus != null).Count();
                ViewBag.BuyAble = db.Books.Where(a => a.BookStatu.Status == "Buyable").Count();
                ViewBag.Completed = db.Books.Where(a => a.Reading.ReadingStatus == "Completed" && a.EndDate != null).Count();
                ViewBag.Lended = db.Books.Where(a => a.BookStatu.Status == "Lended").Count();

                
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}