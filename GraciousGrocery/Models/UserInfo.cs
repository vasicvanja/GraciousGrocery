using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class UserInfo
    {
        ApplicationUser User { get; set; }
        public int Quantity { get; set; }
        public UserInfo() { }
    }
}