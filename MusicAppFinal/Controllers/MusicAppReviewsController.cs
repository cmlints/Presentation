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
    public class MusicAppReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MusicAppReviews
        public ActionResult Index()
        {
            return View(db.MusicApps.ToList());
        }

        // GET: MusicAppReviews/Details/5
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

        // GET: MusicAppReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicAppReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Genre,ArtistName,Year,NumberOfSongs,Song,AlbumName")] MusicApp musicApp)
        {
            if (ModelState.IsValid)
            {
                db.MusicApps.Add(musicApp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musicApp);
        }

        // GET: MusicAppReviews/Edit/5
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

        // POST: MusicAppReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Genre,ArtistName,Year,NumberOfSongs,Song,AlbumName")] MusicApp musicApp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicApp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicApp);
        }

        // GET: MusicAppReviews/Delete/5
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

        // POST: MusicAppReviews/Delete/5
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

        //[NonAction]
        //private MusicAppViewModel BuildMusicAppReviewModel(MusicApp musicAppReview)
        //{
        //    // generate a dictionary with musicapp ids and names for lookup
        //    var musicAppGenres = db.MusicApps.ToDictionary(m => m.Id, m => m.Genre);

        //    return new MusicAppReviewModel()
        //    {
        //        ID = musicAppReview.ID,
        //        DateCreated = musicAppReview.DateCreated,
        //        Content = musicAppReview.Content,
        //        MusicAppID = musicAppReview.MusicAppID,
        //        MusicAppGenre = musicAppGenres[musicAppReview.MusicAppID]
        //    };
        //}

        //[NonAction]
        //private List<MusicAppReviewModel> BuildMusicAppReviewModelList(List<MusicApp> musicAppReviews)
        //{
        //    List<MusicAppReviewModel> musicAppReviewsViewModels = new List<MusicAppReviewModel>();

        //    //generate a dictionary with musicApp ids and names for lookup
        //    var musicAppGenres = db.MusicApps.ToDictionary(m => m.Id, m => m.Genre);

        //    foreach (var musicAppReview in musicAppReviews)
        //    {
        //        musicAppReviewsViewModels.Add(new MusicAppReviewModel
        //        {
        //            ID = musicAppReview.ID,
        //            DateCreated = musicAppReview.DateCreated,
        //            Content = musicAppReview.Content,
        //            MusicAppID = musicAppReview.MusicAppID,
        //            MusicAppGenre = musicAppGenres[musicAppReview.MusicAppID]
        //        });
        //    }
        //    return musicAppReviewsViewModels;
        //}
    }
}
