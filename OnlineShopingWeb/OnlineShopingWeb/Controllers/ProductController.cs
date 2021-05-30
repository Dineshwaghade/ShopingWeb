using OnlineShopingWeb.Models;
using OnlineShopingWeb.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopingWeb.Controllers
{
    public class ProductController : Controller
    {
        DataContext db = new DataContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        // ------------- Start Category -------------
        [HttpGet]
        public ActionResult AddCategory()
        {
            ViewBag.CategoryList = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category cat)
        {
            if(ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                ViewBag.success = "Added Successfully";
            }
            ViewBag.CategoryList = db.Categories.ToList();

            return View();
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var data = db.Categories.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditCategory(Category cat)
        {
            if(ModelState.IsValid)
            {
                db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Success = "Added Succesfully";
                return RedirectToAction("AddCategory", "Product");
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            List<SubCategory> sc_data = db.SubCategories.Where(x => x.Category_id == id).ToList();
            var data = db.Categories.Find(id);
            if(data!=null)
            {
                if(sc_data!=null)
                {
                    foreach (var item in sc_data)
                        db.SubCategories.Remove(item);
                    db.SaveChanges();
                }
                db.Categories.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("AddCategory");
        }
        // ------------- End Category -------------

        [HttpGet]
        public ActionResult AddSubCategory()
        {
            List<Category> lst = db.Categories.ToList();
            ViewBag.CList= new SelectList(lst,"Category_id", "Category_Name");
            ViewBag.SubCategoryList = db.SubCategories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCategory(SubCategory scat)
        {
            if (ModelState.IsValid)
            {
                db.SubCategories.Add(scat);
                db.SaveChanges();
                ViewBag.success = "Added Successfully";
            }
            ViewBag.SubCategoryList = db.SubCategories.ToList();



            return RedirectToAction("AddSubCategory");
        }

        [HttpGet]
        public ActionResult EditSubCategory(int id)
        {
            List<Category> lst = db.Categories.ToList();
            ViewBag.CList = new SelectList(lst, "Category_id", "Category_Name");

            var data = db.SubCategories.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditSubCategory(SubCategory scat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Success = "Added Succesfully";
                return RedirectToAction("AddSubCategory", "Product");
            }
            return View();
        }
        public ActionResult DeleteSubCategory(int id)
        {
            var data = db.SubCategories.Find(id);
            if (data != null)
            {
                db.SubCategories.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("AddSubCategory");
        }

        public ActionResult ProductList()
        {
            var plist = db.Products.ToList();
            return View(plist);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SubCategory> lst = db.SubCategories.ToList();
            ViewBag.SCList = new SelectList(lst, "SubCategory_id", "SubCategory_Name");
            ViewBag.ProductList = db.Products.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product prod)
        {
            if (ModelState.IsValid)
           {
                if (prod.UserImageFile != null)
                {
                    //------------- delete previous image from folder
                    //if (prod.Product_Image != "~/Images/img-not-found.png")
                    //{
                    //    var imgpath = Server.MapPath(TempData["UserImage"].ToString());
                    //    System.IO.File.Delete(imgpath);

                    //}
                    //--------- to insert new image in folder
                    var filename = Path.GetFileNameWithoutExtension(prod.UserImageFile.FileName);
                    var fileextension = Path.GetExtension(prod.UserImageFile.FileName);

                    filename = filename + DateTime.Now.ToString("yymmssff") + fileextension;

                    prod.Product_Image = "~/Images/ProductImages/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/ProductImages/"), filename);
                    prod.UserImageFile.SaveAs(filename);
                }

                if (prod.Product_Image == "~/Images/img-not-found.png")
                {
                    prod.Product_Image = null;
                    if (TempData["UserImage"].ToString() != null)
                    {
                        var imgpath = Server.MapPath(TempData["UserImage"].ToString());
                        System.IO.File.Delete(imgpath);
                    }
                }

                db.Products.Add(prod);
                db.SaveChanges();
                ViewBag.success = "Added Successfully";
            }
            ViewBag.ProductList = db.Products.ToList();



            return RedirectToAction("AddProduct");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            List<SubCategory> lst = db.SubCategories.ToList();
            ViewBag.SCList = new SelectList(lst, "SubCategory_id", "SubCategory_Name");

            var data = db.Products.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditProduct(Product prod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Success = "Added Succesfully";
                return RedirectToAction("ProductList", "Product");
            }
            return View();
        }
        public ActionResult DeleteProduct(int id)
        {
            var data = db.Products.Find(id);
            if (data != null)
            {
                db.Products.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductDetails(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

    }
}