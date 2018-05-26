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
    public class ProvidersPricesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: ProvidersPrices
        public ActionResult Index()
        {
            var providersPrices = db.ProvidersPrices.Include(p => p.Product).Include(p => p.Provider);
            return View(providersPrices.ToList());
        }

        // GET: ProvidersPrices/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidersPrice providersPrice = db.ProvidersPrices.Find(id);
            if (providersPrice == null)
            {
                return HttpNotFound();
            }
            return View(providersPrice);
        }

        // GET: ProvidersPrices/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name");
            return View();
        }

        // POST: ProvidersPrices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProviderID,ProductID,Price,Date")] ProvidersPrice providersPrice)
        {
            if (ModelState.IsValid)
            {
                db.ProvidersPrices.Add(providersPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", providersPrice.ProductID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", providersPrice.ProviderID);
            return View(providersPrice);
        }

        // GET: ProvidersPrices/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidersPrice providersPrice = db.ProvidersPrices.Find(id);
            if (providersPrice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", providersPrice.ProductID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", providersPrice.ProviderID);
            return View(providersPrice);
        }

        // POST: ProvidersPrices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProviderID,ProductID,Price,Date")] ProvidersPrice providersPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providersPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", providersPrice.ProductID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", providersPrice.ProviderID);
            return View(providersPrice);
        }

        // GET: ProvidersPrices/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidersPrice providersPrice = db.ProvidersPrices.Find(id);
            if (providersPrice == null)
            {
                return HttpNotFound();
            }
            return View(providersPrice);
        }

        // POST: ProvidersPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProvidersPrice providersPrice = db.ProvidersPrices.Find(id);
            db.ProvidersPrices.Remove(providersPrice);
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
