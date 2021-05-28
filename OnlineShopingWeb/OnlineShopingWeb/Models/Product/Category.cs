using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopingWeb.Models.Product
{
    public class Category
    {
        [Key]
        public int Category_id { get; set; }
        [Required]
        public string Category_Name { get; set; }
        public virtual ICollection<SubCategory> Subcategories { get; set; }

    }
}