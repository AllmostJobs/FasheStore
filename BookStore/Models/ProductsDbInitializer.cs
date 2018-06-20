using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ProductsDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Types.Add(new Type { Name = "Coat" });
            //            ...

            db.Categories.Add(new Category { Name = "Man" });
            db.Categories.Add(new Category { Name = "Woman" });
            db.Categories.Add(new Category { Name = "Kid" });



            base.Seed(db);
        }
    }
}