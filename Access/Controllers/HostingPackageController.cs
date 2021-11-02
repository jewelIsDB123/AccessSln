using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Access.Models;
using PagedList;

namespace Access.Controllers
{
    public class HostingPackageController : Controller
    {
         AccessDBContext db = new AccessDBContext();
        // GET: HostingPackage
        public ActionResult Index()
        {
            return View(db.HostingPackages.ToList());
        }

        // GET: HostingPackage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingPackage hostingPackage = db.HostingPackages.Find(id);
            if (hostingPackage == null)
            {
                return HttpNotFound();
            }
            return View(hostingPackage);
        }

        // GET: HostingPackage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostingPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HostingPackageId,HostingPackageName")] HostingPackage hostingPackage)
        {
            if (ModelState.IsValid)
            {
                db.HostingPackages.Add(hostingPackage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hostingPackage);
        }

        // GET: HostingPackage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingPackage hostingPackage = db.HostingPackages.Find(id);
            if (hostingPackage == null)
            {
                return HttpNotFound();
            }
            return View(hostingPackage);
        }

        // POST: HostingPackage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HostingPackageId,HostingPackageName")] HostingPackage hostingPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostingPackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hostingPackage);
        }

        // GET: HostingPackage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingPackage hostingPackage = db.HostingPackages.Find(id);
            if (hostingPackage == null)
            {
                return HttpNotFound();
            }
            return View(hostingPackage);
        }

        // POST: HostingPackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HostingPackage hostingPackage = db.HostingPackages.Find(id);
            db.HostingPackages.Remove(hostingPackage);
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
