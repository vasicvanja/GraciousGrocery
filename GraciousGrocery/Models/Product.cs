using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Price")]
        public float ProductPrice { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string ProductUrl { get; set; }

        public virtual List<Category> categories { get; set; }
        public Product()
        {
            categories = new List<Category>();
        }
    }
}