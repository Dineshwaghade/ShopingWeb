using OnlineShopingWeb.Models;
using OnlineShopingWeb.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopingWeb.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            List<Role> lst = db.Roles.ToList();
            ViewBag.RList = new SelectList(lst, "Role_Name", "Role_Name");

            var data = db.Users.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditUser(User usr)
        {
            List<Role> lst = db.Roles.ToList();
            ViewBag.RList = new SelectList(lst, "Role_Name", "Role_Name");

            if (ModelState.IsValid)
            {
                db.Entry(usr).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Success = "Added Succesfully";
                return RedirectToAction("Userlist", "Admin");
            }
            return View();
        }
        public ActionResult DeleteUser(int id)
        {
            var data = db.Users.Find(id);
            if (data != null)
            {
                db.Users.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Userlist");
        }

        public ActionResult Userlist()
        {
            var data = db.Users.ToList();
            return View(data);

        }
        [HttpGet]
        public ActionResult AddRole()
        {
            ViewBag.RoleList = db.Roles.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult AddRole(Role rl)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(rl);
                db.SaveChanges();
                ViewBag.success = "Added Successfully";
            }
            ViewBag.RoleList = db.Roles.ToList();

            return View();
        }
        [HttpGet]
        public ActionResult EditRole(int id)
        {
            var data = db.Roles.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditRole(Role rl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rl).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Success = "Added Succesfully";
                return RedirectToAction("AddRole", "Admin");
            }
            return View();
        }
        public ActionResult DeleteRole(int id)
        {
            var data = db.Roles.Find(id);
            if (data != null)
            {
                db.Roles.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("AddRole");
        }

    }
}