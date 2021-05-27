using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopingWeb.Models
{
    public class User
    {
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Registration_id { get; set; }
    }
}