using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopingWeb.Models.ProductModel
{
    public class SubCategory
    {
        [Key]
        public int SubCategory_id{ get; set; }
        [Required]
        public string SubCategory_Name { get; set; }
        [ForeignKey("Category")]
        public Nullable<int> Category_id { get; set; }
        public virtual Category Category { get; set; }
    }
}