using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelProject.Models;

namespace TravelProject.Controllers
{
    public class ToursController : Controller
    {
        private TravelProjectContextCheckingNow db = new TravelProjectContextCheckingNow();

        // GET: Tours
        public ActionResult Index()
        {
            var tours = db.Tours.Include(t => t.Place).Include(t => t.Transporter);
            return View(tours.ToList());
        }

        // GET: Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            return View(tours);
        }

        // GET: Tours/Create
        public ActionResult Create()
        {
            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title");
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title");
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Place_Id,Transporter_Id,Titile,Description,Quantity_people,Price,Time_start,Time_end,Duration,Time_departure")] Tours tours)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title", tours.Place_Id);
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title", tours.Transporter_Id);
            return View(tours);
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title", tours.Place_Id);
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title", tours.Transporter_Id);
            return View(tours);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Place_Id,Transporter_Id,Titile,Description,Quantity_people,Price,Time_start,Time_end,Duration,Time_departure")] Tours tours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title", tours.Place_Id);
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title", tours.Transporter_Id);
            return View(tours);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            return View(tours);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tours tours = db.Tours.Find(id);
            db.Tours.Remove(tours);
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
