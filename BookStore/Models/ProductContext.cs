using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ProductContext : DbContext
    {
        private const string DbName = "ProductContext";

        public ProductContext() : base(DbName) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ImageProduct> ImagesProducts { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<New> News { get; set; }
        public DbSet<ImageNew> ImageNews { get; set; }
        public DbSet<Them> Thems { get; set; }

    }
}