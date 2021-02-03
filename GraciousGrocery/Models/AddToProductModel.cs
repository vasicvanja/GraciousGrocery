using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class AddToProductModel
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
        public List<Category> categories { get; set; }
        public AddToProductModel()
        {
            categories = new List<Category>();
        }
    }
}