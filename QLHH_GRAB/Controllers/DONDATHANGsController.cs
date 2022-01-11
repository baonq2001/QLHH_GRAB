using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLHH_GRAB.Models;

namespace QLHH_GRAB.Controllers
{
    public class DONDATHANGsController : Controller
    {
        private QLHH_GRABEntities db = new QLHH_GRABEntities();

        // GET: DONDATHANGs
        public ActionResult Index()
        {
            var dONDATHANGs = db.DONDATHANGs.Include(d => d.KHACHHANG).Include(d => d.NHANVIEN);
            return View(dONDATHANGs.ToList());
        }

        // GET: DONDATHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);
        }

        // GET: DONDATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MAKHACHHANG = new SelectList(db.KHACHHANGs, "MAKHACHHANG", "TENKH");
            ViewBag.MANHANVIEN = new SelectList(db.NHANVIENs, "MANHANVIEN", "HO");
            return View();
        }

        // POST: DONDATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SOHOADON,MAKHACHHANG,MANHANVIEN,NGAYDATHANG,NGAYGIAOHANG,NGAYCHUYENHANG,NOIGIAOHANG")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.DONDATHANGs.Add(dONDATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKHACHHANG = new SelectList(db.KHACHHANGs, "MAKHACHHANG", "TENKH", dONDATHANG.MAKHACHHANG);
            ViewBag.MANHANVIEN = new SelectList(db.NHANVIENs, "MANHANVIEN", "HO", dONDATHANG.MANHANVIEN);
            return View(dONDATHANG);
        }

        // GET: DONDATHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKHACHHANG = new SelectList(db.KHACHHANGs, "MAKHACHHANG", "TENKH", dONDATHANG.MAKHACHHANG);
            ViewBag.MANHANVIEN = new SelectList(db.NHANVIENs, "MANHANVIEN", "HO", dONDATHANG.MANHANVIEN);
            return View(dONDATHANG);
        }

        // POST: DONDATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SOHOADON,MAKHACHHANG,MANHANVIEN,NGAYDATHANG,NGAYGIAOHANG,NGAYCHUYENHANG,NOIGIAOHANG")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONDATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKHACHHANG = new SelectList(db.KHACHHANGs, "MAKHACHHANG", "TENKH", dONDATHANG.MAKHACHHANG);
            ViewBag.MANHANVIEN = new SelectList(db.NHANVIENs, "MANHANVIEN", "HO", dONDATHANG.MANHANVIEN);
            return View(dONDATHANG);
        }

        // GET: DONDATHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);
        }

        // POST: DONDATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            db.DONDATHANGs.Remove(dONDATHANG);
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
