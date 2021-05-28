using OnlineShopingWeb.Models.Product;
using OnlineShopingWeb.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopingWeb.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("conn"){}
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
   
    }
}