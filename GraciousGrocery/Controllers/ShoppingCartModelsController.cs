using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GraciousGrocery.Models;
using Microsoft.AspNet.Identity;

namespace GraciousGrocery.Controllers
{
    public class ShoppingCartModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingCartModels
        public ActionResult Index()
        {
            return View(db.ShoppingCartModels.ToList());
        }

        public ActionResult Order()
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            ShoppingCartModel products = db.ShoppingCartModels.Find(User.Identity.GetUserId());
            for (int i = 0; i < products.products.Count; i++)
            {
                products.products.Remove(products.products[i]);
                i--;
            }
            db.Entry(products).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        // GET: ShoppingCartModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCartModel shoppingCartModel = db.ShoppingCartModels.Find(id);
            if (shoppingCartModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCartModel);
        }

        // GET: ShoppingCartModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCartModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId")] ShoppingCartModel shoppingCartModel)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingCartModels.Add(shoppingCartModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingCartModel);
        }

        // GET: ShoppingCartModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCartModel shoppingCartModel = db.ShoppingCartModels.Find(id);
            if (shoppingCartModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCartModel);
        }

        // POST: ShoppingCartModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId")] ShoppingCartModel shoppingCartModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingCartModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingCartModel);
        }

        // GET: ShoppingCartModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCartModel shoppingCartModel = db.ShoppingCartModels.Find(id);
            if (shoppingCartModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCartModel);
        }

        // POST: ShoppingCartModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ShoppingCartModel shoppingCartModel = db.ShoppingCartModels.Find(id);
            db.ShoppingCartModels.Remove(shoppingCartModel);
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
