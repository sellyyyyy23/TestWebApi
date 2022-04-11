﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class KaryawansController : Controller
    {
        private TESTAPIEntities db = new TESTAPIEntities();

        // GET: Karyawans
        public ActionResult Index()
        {
            // retruns a list 0f all entries in the database
            return View(db.Karyawans.ToList());
        }

        // GET: Karyawans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // GET: Karyawans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Karyawans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kd_nama,Nama,Jenis_Kelamin,Tanggal_Lahir,Alamat,no_telp")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                db.Karyawans.Add(karyawan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(karyawan);
        }

        // GET: Karyawans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // POST: Karyawans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kd_nama,Nama,Jenis_Kelamin,Tanggal_Lahir,Alamat,no_telp")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karyawan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(karyawan);
        }

        // GET: Karyawans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // POST: Karyawans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Karyawan karyawan = db.Karyawans.Find(id);
            db.Karyawans.Remove(karyawan);
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
