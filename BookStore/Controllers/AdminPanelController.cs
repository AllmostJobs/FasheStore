using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class AdminPanelController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: AdminPanel
        public ActionResult Index()
        {
            var query = db.Products.Include(p => p.ImageProducts);
            return View(query.ToList());
        }

        // GET: AdminPanel/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: AdminPanel/Create
        public ActionResult Create() => View();

        // POST: AdminPanel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase ImageFile, ImageProduct imageProduct)
        {
            if (ImageFile != null)
            {
                string fileExtention = Path.GetExtension(ImageFile.FileName);
                string fileName = Guid.NewGuid().ToString() + fileExtention.ToString();
                ImageFile.SaveAs(Server.MapPath("~/ProductImages/" + fileName));

                imageProduct.ImageName = fileName;

                imageProduct.ProductId = product.Id;

                db.Products.Add(product);
                db.ImagesProducts.Add(imageProduct);

                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: AdminPanel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: AdminPanel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Size,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: AdminPanel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: AdminPanel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);

            foreach(var item in product.ImageProducts)
            {
                if(item.ProductId == id)
                {
                    string imagePath = "~/ProductImages/" + item.ImageName;

                    System.IO.File.Delete(imagePath);
                }
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //////////////////------BLOG------///////////////////
        // GET: AdminPanel
        public ActionResult Blog()
        {
            var query = db.News.Include(p => p.ImagesNew);
            return View(query.ToList());
        }

        public ActionResult CreateNew() => View();

        // POST: AdminPanel/CreateNew
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateNew(New news, HttpPostedFileBase ImageFile, ImageNew imageNew)
        {
            if (ImageFile != null)
            {
                string fileExtention = Path.GetExtension(ImageFile.FileName);
                string fileName = Guid.NewGuid().ToString() + fileExtention.ToString();
                ImageFile.SaveAs(Server.MapPath("~/NewsImage/" + fileName));

                imageNew.ImageName = fileName;

                imageNew.NewId = news.Id;

                db.News.Add(news);
                db.ImageNews.Add(imageNew);

                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Blog");
            }
            return RedirectToAction("Blog");
        }

        // GET: AdminPanel/EditNew/5
        public ActionResult EditNew(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: AdminPanel/EditNew/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNew([Bind(Include = "Id,Title,Text,Them")] New news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Blog");
            }
            return View(news);
        }

        // GET: AdminPanel/DeleteNew/5
        public ActionResult DeleteNew(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: AdminPanel/DeleteNew/5
        [HttpPost, ActionName("DeleteNew")]
        [ValidateAntiForgeryToken]
        public ActionResult NewDeleteConfirmed(int id)
        {
            New news = db.News.Find(id);

            foreach (var item in news.ImagesNew)
            {
                if (item.NewId == id)
                {
                    string imagePath = "~/NewsImage/" + item.ImageName;

                    System.IO.File.Delete(imagePath);
                }
            }

            db.News.Remove(news);
            db.SaveChanges();

            return RedirectToAction("Blog");
        }
    }
}
