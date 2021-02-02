using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class ShoppingCartModel
    {
        [Key]
        public string UserId { get; set; }
        public List<int> Quantity { get; set; }
        public virtual List<Product> products { get; set; }

        public ShoppingCartModel(string userID)
        {
            Quantity = new List<int>();
            products = new List<Product>();
            UserId = userID;
        }

        public ShoppingCartModel()
        {
            Quantity = new List<int>();
            products = new List<Product>();
        }
    }
}