using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public virtual List<Product> Products { get; set; }
        public CartItem(string userID)
        {
            Products = new List<Product>();
            
            UserId = userID;
        }
        public CartItem()
        {
            Products = new List<Product>();
            
        }
    }
}