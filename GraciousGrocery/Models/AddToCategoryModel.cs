using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class AddToCategoryModel
    {
        public int categoryId { get; set; }
        public int productId { get; set; }
        public List<Product> products { get; set; }
        public AddToCategoryModel()
        {
            products = new List<Product>();
        }
    }
}