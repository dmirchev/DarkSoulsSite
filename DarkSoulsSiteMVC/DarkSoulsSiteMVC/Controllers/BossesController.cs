using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DarkSoulsSite.DbContext;
using DarkSoulsSite.Entities.Common;
using DarkSoulsSiteMVC.DTOs;

namespace DarkSoulsSiteMVC.Controllers
{
    [Authorize]
    public class BossesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bosses
        public ActionResult Index()
        {
            return View(db.Bossеs.ToList());
        }

        // GET: Bosses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boss boss = db.Bossеs.Find(id);
            if (boss == null)
            {
                return HttpNotFound();
            }
            return View(boss);
        }

        // GET: Bosses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bosses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BossEntry entry)
        {
            if (ModelState.IsValid)
            {
                Boss boss = new Boss(entry.BaseDamage, entry.BaseArmor, entry.FireDefense, entry.IceDefense, entry.LightningDefense,
                    entry.BleedDefence, entry.PoisonDefence, entry.Reward, entry.Rating,
                    entry.Name, entry.Level, entry.Image, null);

                db.Bossеs.Add(boss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        // GET: Bosses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boss boss = db.Bossеs.Find(id);
            if (boss == null)
            {
                return HttpNotFound();
            }
            return View(boss);
        }

        // POST: Bosses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BaseDamage,BaseArmor,FireDefense,IceDefense,LightningDefense,BleedDefence,PoisonDefence,Reward,Rating,Name,Level,Image")] Boss boss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boss);
        }

        // GET: Bosses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boss boss = db.Bossеs.Find(id);
            if (boss == null)
            {
                return HttpNotFound();
            }
            return View(boss);
        }

        // POST: Bosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Boss boss = db.Bossеs.Find(id);
            db.Bossеs.Remove(boss);
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
