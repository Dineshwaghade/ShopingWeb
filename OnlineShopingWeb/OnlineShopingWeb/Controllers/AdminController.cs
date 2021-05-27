using OnlineShopingWeb.Models;
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
            var data = db.Users.ToList();
            return View(data);
        }
    }
}