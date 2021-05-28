using OnlineShopingWeb.Models;
using OnlineShopingWeb.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopingWeb.Controllers
{
    public class UserController : Controller
    {
        DataContext db = new DataContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User usr)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User usr)
        {
            int count = db.Users.Where(x => x.Email == usr.Email && x.Password == usr.Password).Count();
            if(count>0)
            {
                Session["username"] = usr.First_Name;
                return RedirectToAction("index", "Home");
            }
            return View();
        }

    }
}