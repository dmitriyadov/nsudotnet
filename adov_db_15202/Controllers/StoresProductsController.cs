using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using adov_db_15202.DAL;
using adov_db_15202.Models;

namespace adov_db_15202.Controllers
{
    public class StoresProductsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: StoresProducts
        public ActionResult Index()
        {
            var storesProducts = db.StoresProducts.Include(s => s.Product).Include(s => s.Store);
            return View(storesProducts.ToList());
        }

        // GET: StoresProducts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresProduct storesProduct = db.StoresProducts.Find(id);
            if (storesProduct == null)
            {
                return HttpNotFound();
            }
            return View(storesProduct);
        }

        // GET: StoresProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name");
            return View();
        }

        // POST: StoresProducts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StoreID,ProductID,Number,Price,Date")] StoresProduct storesProduct)
        {
            if (ModelState.IsValid)
            {
                db.StoresProducts.Add(storesProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", storesProduct.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", storesProduct.StoreID);
            return View(storesProduct);
        }

        // GET: StoresProducts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresProduct storesProduct = db.StoresProducts.Find(id);
            if (storesProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", storesProduct.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", storesProduct.StoreID);
            return View(storesProduct);
        }

        // POST: StoresProducts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StoreID,ProductID,Number,Price,Date")] StoresProduct storesProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storesProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", storesProduct.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", storesProduct.StoreID);
            return View(storesProduct);
        }

        // GET: StoresProducts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresProduct storesProduct = db.StoresProducts.Find(id);
            if (storesProduct == null)
            {
                return HttpNotFound();
            }
            return View(storesProduct);
        }

        // POST: StoresProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            StoresProduct storesProduct = db.StoresProducts.Find(id);
            db.StoresProducts.Remove(storesProduct);
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
    }
}
