//using OnlineShopingWeb.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopingWeb.Models.ProductModel
{
    public class ProductValidation
    {
        [Required]
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public string Product_Image { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid input")]
        [Required]
        public string Price { get; set; }
        [Range(0, 10000, ErrorMessage = "Maximum limit is 10000")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid quantity")]
        [Required(ErrorMessage ="This field is required")]
        public int Product_Qty { get; set; }

        [ForeignKey("SubCategory")]
        [Required(ErrorMessage = "Please select SubCategory")]
        public Nullable<int> SubCategory_id { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }

    [MetadataType(typeof(ProductValidation))]
    public partial class Product
    {
        [NotMapped]
        public HttpPostedFileBase UserImageFile { get; set; }

    }
}