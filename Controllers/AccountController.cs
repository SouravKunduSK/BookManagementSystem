using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        BookManagementEntities db = new BookManagementEntities();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(user.Email);
                if (!isExist)
                {
                    User u = new User();
                    u.FirstName = user.FirstName;
                    u.LastName = user.LastName;
                    u.Username = user.FirstName + user.LastName;
                    u.Email = user.Email;
                    u.Password = user.Password;
                    u.PassCode = Crypto.Hash(user.Password);
                    u.RegDate = DateTime.Now.Date;

                    db.Users.Add(u);
                    db.SaveChanges();

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.Message = "Email has already been Register!!";
                }



            }
            else
            {
                ViewBag.Message = "Not Register!! Try Again...";
            }
            return View();
        }



        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var cust = db.Users.SingleOrDefault(x => x.Email == user.Email);
            if (cust != null)
            {
                if (string.Compare(Crypto.Hash(user.Password), cust.PassCode) == 0)
                {
                    Session["uid"] = cust.UserId;
                    Session["username"] = cust.Username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Email or Password Error!";
                }

            }
            else
            {
                ViewBag.Message = "Email or Password Error!";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["uid"] = null;
            Session["username"] = null;
            return RedirectToAction("Login", "Account");
        }






        public ActionResult Index()
        {
            return View();
        }

        [NonAction]
        public bool IsEmailExist(string email)
        {
            var v = db.Users.Where(x => x.Email == email).FirstOrDefault();
            return v != null;
        }
    }
}