using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        ProductContext db = new ProductContext();
        public ActionResult Products()
        {
            var query = db.Products.Include(p => p.ImageProducts);
            return View(query.ToList());
        }

		public ActionResult ProductDetails()
		{
			return View();
		}
    }
}