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
    public class CartItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CartItems
        public ActionResult Order()
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            CartItem items = db.CartItems.Find(User.Identity.GetUserId());
            for (int i = 0; i < items.Products.Count; i++)
            {
                items.Products.Remove(items.Products[i]);
                i--;
            }
            db.Entry(items).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details");
        }
        // GET: ShoppingCart/Details/5
        public ActionResult Details()
        {
            List<Product> shoppingItem = db.CartItems.Find(User.Identity.GetUserId()).Products;
            if (shoppingItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingItem);
        }
        

        // GET: ShoppingCart/Create
        /*public ActionResult AddItemToCart(int id, int quantity = 1)
        {
            string Userid = User.Identity.GetUserId();
            CartItem shoppingCartItems = db.CartItems.Find(Userid);//.Where(i => i.UserID.Equals(Userid)).First();
            if (shoppingCartItems != null)
            {
                Product item = db.Products.Find(id);
                shoppingCartItems.Quantity.Add(item.Quantity >= quantity ? quantity : item.Quantity);
                shoppingCartItems.Products.Add(item);
                db.Entry(shoppingCartItems).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }*/


        // GET: CartItems/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // POST: CartItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartItem);
        }

        // GET: CartItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem shoppingCartItems = db.CartItems.Find(User.Identity.GetUserId());
            if (shoppingCartItems == null)
            {
                return HttpNotFound();
            }
            shoppingCartItems.Products.Remove(db.Products.Find(id));
            db.Entry(shoppingCartItems).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: CartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            db.CartItems.Remove(cartItem);
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
