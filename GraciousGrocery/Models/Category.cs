using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Display(Name = "Image")]
        public string CategoryUrl { get; set; }
        public List<Product> products { get; set; }
        public Category()
        {
            products = new List<Product>();
        }
    }
}