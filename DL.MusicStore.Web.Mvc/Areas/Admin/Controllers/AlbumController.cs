using DL.MusicStore.Domain;
using DL.MusicStore.Persistence.EF;
using DL.MusicStore.Web.Mvc.Areas.Admin.Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DL.MusicStore.Web.Mvc.Areas.Admin.Controllers
{
    public class AlbumController : Controller
    {
        public ActionResult Index()
        {
            var model = new List<AlbumSummaryViewModel>();

            // Fetch list of ablums from the database
            using (var db = new MSDbContext())
            {
                var albums = db.Set<Album>()
                    .OrderBy(a => a.Title);

                foreach (var album in albums)
                {
                    model.Add(new AlbumSummaryViewModel
                        {
                            AlbumId = album.AlbumId,
                            Title = album.Title,
                            Price = album.Price.ToString("c"),
                            DatePublished = album.DatePublished.ToShortDateString(),
                            Artist = album.Artist.Name,
                            Style = album.Style.Name
                        });
                }
            }

            return View(model);
        }

        #region Edit album

        public ActionResult Edit(int id)
        {
            Album albumFromDb = null;
            List<AlbumStyle> albumStylesFromDb = new List<AlbumStyle>();
            List<Artist> artistsFromDb = new List<Artist>();

            using (var db = new MSDbContext())
            {
                albumFromDb = db.Set<Album>().Find(id);

                albumStylesFromDb = db.Set<AlbumStyle>()
                    .OrderBy(s => s.Name)
                    .ToList();

                artistsFromDb = db.Set<Artist>()
                    .OrderBy(ar => ar.Name)
                    .ToList();
            }

            if (albumFromDb == null)
            {
                return HttpNotFound();
            }

            var model = new EditAlbumViewModel
            {
                AlbumId = albumFromDb.AlbumId,
                Title = albumFromDb.Title,
                Price = albumFromDb.Price,
                SelectedStyleId = albumFromDb.AlbumStyleId,
                AvailableStyles = albumStylesFromDb.ToDictionary(
                    s => s.AlbumStyleId,
                    s => s.Name),
                SelectedArtistId = albumFromDb.ArtistId,
                AvailableArtists = artistsFromDb.ToDictionary(
                    ar => ar.ArtistId,
                    ar => ar.Name
                )
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditAlbumViewModel model)
        {
            if (ModelState.IsValid)
            {
                Album albumFromDb = null;
                using (var db = new MSDbContext())
                {
                    albumFromDb = db.Set<Album>().Find(model.AlbumId);
                    if (albumFromDb != null)
                    {
                        albumFromDb.UpdateTitle(model.Title);
                        albumFromDb.UpdatePrice(model.Price);

                        var albumStyleFromDb = db.Set<AlbumStyle>().Find(model.SelectedStyleId);
                        if (albumStyleFromDb != null)
                        {
                            albumFromDb.UpdateStyle(albumStyleFromDb);
                        }

                        var artistFromDb = db.Set<Artist>().Find(model.SelectedArtistId);
                        if (artistFromDb != null)
                        {
                            albumFromDb.UpdateArtist(artistFromDb);
                        }

                        db.Entry(albumFromDb).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("edit", new { id = model.AlbumId });
        }

        #endregion
    }
}