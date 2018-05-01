using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicAppFinal.Models;

namespace MusicAppFinal.Controllers
{
    public class MusicAppsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MusicApps
        public ActionResult Index()
        {
            return View(db.MusicApps.ToList()); 
        }

        // GET: MusicApps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicApp musicApp = db.MusicApps.Find(id);
            if (musicApp == null)
            {
                return HttpNotFound();
            }
            return View(musicApp);
        }

        // GET: MusicApps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Genre,ArtistName,AlbumName,Song,Year,NumberOfSongs")] MusicApp musicApp)
        {
            if (ModelState.IsValid)
            {
                db.MusicApps.Add(musicApp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musicApp);
        }

        // GET: MusicApps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicApp musicApp = db.MusicApps.Find(id);
            if (musicApp == null)
            {
                return HttpNotFound();
            }
            return View(musicApp);
        }

        // POST: MusicApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Genre,ArtistName,AlbumName,Song,Year,NumberOfSongs")] MusicApp musicApp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicApp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicApp);
        }

        // GET: MusicApps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicApp musicApp = db.MusicApps.Find(id);
            if (musicApp == null)
            {
                return HttpNotFound();
            }
            return View(musicApp);
        }

        // POST: MusicApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicApp musicApp = db.MusicApps.Find(id);
            db.MusicApps.Remove(musicApp);
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
