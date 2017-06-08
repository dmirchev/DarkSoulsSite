using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DarkSoulsSite.DbContext;
using DarkSoulsSite.Entities.Functions;
using Microsoft.AspNet.Identity;
using DarkSoulsSiteMVC.DTOs;

namespace DarkSoulsSiteMVC.Controllers.FunctionControllers
{
    public class FightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fights
        public ActionResult Index()
        {
            var fights = db.Fights.Include(f => f.Boss).Include(f => f.Character);
            return View(fights.ToList());
        }

        // GET: Fights/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fight fight = db.Fights.Find(id);
            if (fight == null)
            {
                return HttpNotFound();
            }
            return View(fight);
        }

        // GET: Fights/Create
        public ActionResult Create()
        {
            var user = User.Identity.GetUserId();

            ViewBag.BossId = new SelectList(db.Bossеs, "Id", "Name");
            ViewBag.CharacterId = new SelectList(db.Characters.Where(m => m.UserId == user), "Id", "Name");
            return View();
        }

        // POST: Fights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FightEntry entry)
        {
            //var user = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                Fight fight = new Fight(entry.CharacterId, entry.BossId, null);

                db.Fights.Add(fight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BossId = new SelectList(db.Bossеs, "Id", "Name", entry.BossId);
            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name", entry.CharacterId);
            return View(entry);
        }

        //// GET: Fights/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Fight fight = db.Fights.Find(id);
        //    if (fight == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.BossId = new SelectList(db.Bossеs, "Id", "Reward", fight.BossId);
        //    ViewBag.CharacterId = new SelectList(db.Characters, "Id", "UserId", fight.CharacterId);
        //    return View(fight);
        //}

        //// POST: Fights/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,CharacterId,BossId")] Fight fight)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(fight).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.BossId = new SelectList(db.Bossеs, "Id", "Reward", fight.BossId);
        //    ViewBag.CharacterId = new SelectList(db.Characters, "Id", "UserId", fight.CharacterId);
        //    return View(fight);
        //}

        //// GET: Fights/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Fight fight = db.Fights.Find(id);
        //    if (fight == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fight);
        //}

        //// POST: Fights/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Fight fight = db.Fights.Find(id);
        //    db.Fights.Remove(fight);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
