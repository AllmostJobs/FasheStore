using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public bool? Sale { get; set; }
        public bool? New { get; set; }

        public int? TypeId { get; set; }
        public Type Type { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ImageProduct> ImageProducts { get; set; }

        public Product()
        {
            ImageProducts = new List<ImageProduct>();
        }
    }
}