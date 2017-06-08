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
using Microsoft.AspNet.Identity;
using DarkSoulsSite.Entities.Items;

namespace DarkSoulsSiteMVC.Controllers
{
    [Authorize]
    public class CharactersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Characters
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();

            var characters = db.Characters.Where(m => m.UserId == user).Include(c => c.Armor).Include(c => c.Magic).Include(c => c.User).Include(c => c.Weapon);
            return View(characters.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Character character = db.Characters.Find(id);

            

            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.ArmorId = new SelectList(db.Armors, "Id", "Name");
            ViewBag.MagicId = new SelectList(db.Magics, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.WeaponId = new SelectList(db.Weapons, "Id", "Name");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterEntry entry)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                Character character = new Character(userId, entry.CharDamage, entry.CharArmor, entry.CharMagic,
                    entry.WeaponId, entry.ArmorId, entry.MagicId,
                    entry.FinalDamage, entry.FinalArmor, entry.FinalMagic,
                    entry.Name, entry.Level, entry.Image, null);

                Weapon weapon = db.Weapons.Find(character.WeaponId);
                Armor armor = db.Armors.Find(character.ArmorId);
                Magic magic = db.Magics.Find(character.MagicId);

                character.FinalDamage = character.CharDamage + weapon.BaseDamage;
                character.FinalArmor = character.CharArmor + armor.BaseArmor;
                character.FinalMagic = character.CharMagic + magic.BaseMagic;

                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArmorId = new SelectList(db.Armors, "Id", "Name", entry.ArmorId);
            ViewBag.MagicId = new SelectList(db.Magics, "Id", "Name", entry.MagicId);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", character.UserId);
            ViewBag.WeaponId = new SelectList(db.Weapons, "Id", "Name", entry.WeaponId);
            return View(entry);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArmorId = new SelectList(db.Armors, "Id", "Name", character.ArmorId);
            ViewBag.MagicId = new SelectList(db.Magics, "Id", "Name", character.MagicId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", character.UserId);
            ViewBag.WeaponId = new SelectList(db.Weapons, "Id", "Name", character.WeaponId);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId," +
            "CharDamage,CharArmor,CharMagic," +
            "WeaponId,ArmorId,MagicId," +
            "FinalDamage,FinalArmor,FinalMagic" +
            ",Name,Level,Image")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArmorId = new SelectList(db.Armors, "Id", "Name", character.ArmorId);
            ViewBag.MagicId = new SelectList(db.Magics, "Id", "Name", character.MagicId);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", character.UserId);
            ViewBag.WeaponId = new SelectList(db.Weapons, "Id", "Name", character.WeaponId);
            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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
