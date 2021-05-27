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
    }
}