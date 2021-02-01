using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraciousGrocery.Models
{
    public class Store
    {
        [Key]
        [Required]
        public int StoreId { get; set; }
        [Display(Name = "Name")]
        public string StoreName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string StoreAddress { get; set; }
        public List<Product> products { get; set; }
        public Store()
        {
            products = new List<Product>();
        }
    }
}