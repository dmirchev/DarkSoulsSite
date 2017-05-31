using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DarkSoulsSite.DbContext;
using DarkSoulsSite.Entities.Items;
using DarkSoulsSiteMVC.DTOs;

namespace DarkSoulsSiteMVC.Controllers.ItemControllers
{
    [Authorize]
    public class MagicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Magics
        public ActionResult Index()
        {
            return View(db.Magics.ToList());
        }

        // GET: Magics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magic magic = db.Magics.Find(id);
            if (magic == null)
            {
                return HttpNotFound();
            }
            return View(magic);
        }

        // GET: Magics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Magics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MagicEntry entry)
        {
            if (ModelState.IsValid)
            {
                Magic magic = new Magic(entry.BaseMagic, entry.Fire, entry.Ice, entry.Lightning,
                    entry.Name, entry.Level, entry.Image, null);

                db.Magics.Add(magic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        // GET: Magics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magic magic = db.Magics.Find(id);
            if (magic == null)
            {
                return HttpNotFound();
            }
            return View(magic);
        }

        // POST: Magics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BaseMagic,Fire,Ice,Lightning,Name,Level,Image")] Magic magic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(magic);
        }

        // GET: Magics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magic magic = db.Magics.Find(id);
            if (magic == null)
            {
                return HttpNotFound();
            }
            return View(magic);
        }

        // POST: Magics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Magic magic = db.Magics.Find(id);
            db.Magics.Remove(magic);
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
