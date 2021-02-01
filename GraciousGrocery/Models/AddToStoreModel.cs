using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class AddToStoreModel
    {
        public int storeId { get; set; }
        public int productId { get; set; }
        public List<Product> products { get; set; }
        public AddToStoreModel()
        {
            products = new List<Product>();
        }
    }
}