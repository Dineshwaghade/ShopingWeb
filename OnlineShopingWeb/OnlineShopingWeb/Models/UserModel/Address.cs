using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopingWeb.Models.UserModel
{
    public class Address
    {
        [Key]
        public int Address_id { get; set; }
        [Required]
        public string Landmark { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [ForeignKey("User")]
        public virtual User User { get; set; }

    }
}