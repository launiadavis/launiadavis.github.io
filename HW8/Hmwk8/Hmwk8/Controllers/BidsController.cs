using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hmwk8.DAL;
using Hmwk8.Models;

namespace Hmwk8.Controllers
{
    public class BidsController : Controller
    {
        private HW8Context db = new HW8Context();

        // GET: Bids
        public ActionResult Index()
        {
            var bids = db.Bids.Include(b => b.Buyer).Include(b => b.Item);
            return View(bids.ToList());
        }

        // GET: Bids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // GET: Bids/Create
        public ActionResult Create()
        {
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "BuyerNAME");
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemNAME");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemID,BuyerID,BidPRICE,BidTIMESTAMP")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                bid.BidTIMESTAMP = DateTime.Now;

                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Details", "Items", new {id = bid.ItemID});
            }

            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "BuyerNAME", bid.BuyerID);
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemNAME", bid.ItemID);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "BuyerNAME", bid.BuyerID);
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemNAME", bid.ItemID);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemID,BuyerID,BidPRICE,BidTIMESTAMP")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "BuyerNAME", bid.BuyerID);
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemNAME", bid.ItemID);
            return View(bid);
        }

        // GET: Bids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bid bid = db.Bids.Find(id);
            db.Bids.Remove(bid);
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
