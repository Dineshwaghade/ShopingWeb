using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopingWeb.Models.ProductModel
{
    public partial class Product
    {
        [Key]
        public int Product_id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public string Product_Image { get; set; }
        public string Price{ get; set; }
        public double Product_Rating { get; set; }
        public int Product_Qty { get; set; }
        [ForeignKey("SubCategory_id")]
        public Nullable<int> SubCategory_id { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}