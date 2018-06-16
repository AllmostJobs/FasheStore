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
            var products = db.Products;
            return View(products.ToList());
        }

		public ActionResult ProductDetails()
		{
			return View();
		}
    }
}