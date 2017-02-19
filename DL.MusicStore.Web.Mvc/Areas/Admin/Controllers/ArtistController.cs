using DL.MusicStore.Domain;
using DL.MusicStore.Persistence.EF;
using DL.MusicStore.Web.Mvc.Areas.Admin.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DL.MusicStore.Web.Mvc.Areas.Admin.Controllers
{
    public class ArtistController : Controller
    {
        #region List out all artists

        public ActionResult Index()
        {
            var result = new List<ArtistSummaryViewModel>();

            // Go get data from database
            using (var db = new MSDbContext())
            {
                var artistsFromDb = db.Set<Artist>()
                    .OrderBy(style => style.Name);

                foreach (var a in artistsFromDb)
                {
                    result.Add(new ArtistSummaryViewModel
                    {
                        ArtistId = a.ArtistId,
                        Name = a.Name,
                        NumberOfAlbums = a.Albums.Count
                    });
                }
            }

            return View(result);
        }

        #endregion

        #region Create new artist

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateArtistViewModel model)
        {
            // TODO: validation
            using (var db = new MSDbContext())
            {
                var dbArtist = new Artist(model.ArtistName);

                // Add it to the list of database artists
                db.Set<Artist>().Add(dbArtist);

                // Save
                db.SaveChanges();
            }

            // Post-Redirect-Get Pattern
            return RedirectToAction("index");
        }

        #endregion

        #region Edit artist

        public ActionResult Edit(int id)
        {
            using (var db = new MSDbContext())
            {
                // Look up the artist by its ID in the database
                var dbArtist = db.Set<Artist>().Find(id);
                if (dbArtist == null)
                {
                    // Cannot find the artist by its id.
                    return HttpNotFound();
                }

                var model = new EditArtistViewModel
                {
                    ArtistId = dbArtist.ArtistId,
                    ArtistName = dbArtist.Name
                };

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditArtistViewModel model)
        {
            // TODO: validation
            using (var db = new MSDbContext())
            {
                // Look up the artist by its ID in the database
                var dbArtist = db.Set<Artist>().Find(model.ArtistId);
                if (dbArtist == null)
                {
                    // Return back to its view
                    // TODO: should display error message.
                    return View(model);
                }

                // Update the name
                dbArtist.UpdateName(model.ArtistName);

                // Save
                db.SaveChanges();
            }

            // Post-Redirect-Get Pattern
            return RedirectToAction("index");
        }

        #endregion

        #region Delete artist

        public ActionResult Delete(int id)
        {
            using (var db = new MSDbContext())
            {
                // Look up the artist by its ID in the database
                var dbArtist = db.Set<Artist>().Find(id);
                if (dbArtist == null)
                {
                    // Cannot find the artist by its id.
                    return HttpNotFound();
                }

                var model = new DeleteArtistViewModel
                {
                    ArtistId = dbArtist.ArtistId,
                    ArtistName = dbArtist.Name
                };

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(DeleteArtistViewModel model)
        {
            // TODO: validation
            using (var db = new MSDbContext())
            {
                // Look up the artist by its ID in the database
                var dbArtist = db.Set<Artist>().Find(model.ArtistId);
                if (dbArtist == null)
                {
                    // Return back to its view
                    // TODO: should display error message.
                    return View(model);
                }

                // Update the name
                db.Set<Artist>().Remove(dbArtist);

                // Save
                db.SaveChanges();
            }

            // Post-Redirect-Get Pattern
            return RedirectToAction("index");
        }

        #endregion
    }
}