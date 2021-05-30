﻿//using OnlineShopingWeb.Models.ProductModel;
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
        [Range(0, double.MaxValue, ErrorMessage = "Please enter price")]
        public string Price { get; set; }
        [ForeignKey("SubCategory")]
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