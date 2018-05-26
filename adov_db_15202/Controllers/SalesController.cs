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
    public class SalesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Buyer).Include(s => s.Product).Include(s => s.Seller).Include(s => s.Store);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "Name");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "Name");
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name");
            return View();
        }

        // POST: Sales/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StoreID,SellerID,BuyerID,ProductID,Date,Number")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "Name", sale.BuyerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", sale.ProductID);
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "Name", sale.SellerID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", sale.StoreID);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "Name", sale.BuyerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", sale.ProductID);
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "Name", sale.SellerID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", sale.StoreID);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StoreID,SellerID,BuyerID,ProductID,Date,Number")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "Name", sale.BuyerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", sale.ProductID);
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "Name", sale.SellerID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", sale.StoreID);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
