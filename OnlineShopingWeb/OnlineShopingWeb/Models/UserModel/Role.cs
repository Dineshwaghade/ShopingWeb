using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopingWeb.Models.UserModel
{
    public class Role
    {
        [Key]
        public int Role_id { get; set; }
        public string Role_Name { get; set; }
    }
}