﻿using System;
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
    public class TransportersController : Controller
    {
        private TravelProjectContextCheckingNow db = new TravelProjectContextCheckingNow();

        // GET: Transporters
        public ActionResult Index()
        {
            return View(db.Transporters.ToList());
        }

        // GET: Transporters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(transporter);
        }

        // GET: Transporters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transporters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Image")] Transporter transporter)
        {
            if (ModelState.IsValid)
            {
                db.Transporters.Add(transporter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transporter);
        }

        // GET: Transporters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(transporter);
        }

        // POST: Transporters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Image")] Transporter transporter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transporter);
        }

        // GET: Transporters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(transporter);
        }

        // POST: Transporters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transporter transporter = db.Transporters.Find(id);
            db.Transporters.Remove(transporter);
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
