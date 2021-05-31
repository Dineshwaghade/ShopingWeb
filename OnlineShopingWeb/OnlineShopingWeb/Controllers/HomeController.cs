using OnlineShopingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopingWeb.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var list = db.Products.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            //List<SubCategory> lst = db.SubCategories.ToList();
            //ViewBag.SCList = new SelectList(lst, "SubCategory_id", "SubCategory_Name");

            var data = db.Products.Find(id);
            //if (data.Product_Image != null)
            //{
            //    TempData["UserImage"] = data.Product_Image;
            //    TempData.Keep();
            //}
            if (data.Product_Image == null || data.Product_Image == string.Empty)
            {
                data.Product_Image = "~/Images/img-not-found.png";
            }

            return View(data);
        }

    }

}