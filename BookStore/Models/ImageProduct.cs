using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ImageProduct
    {
        public int Id { get; set; }
        public string ImageName { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}