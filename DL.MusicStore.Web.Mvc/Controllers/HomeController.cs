using DL.MusicStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DL.MusicStore.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // This is just for demo purpose
        public ActionResult Index()
        {
            // To create an artist
            Artist artist = new Artist("David Liang");
            //Artist artist = new Artist();
            //artist.ArtistId = 1;
            //artist.Name = "David Liang";

            // To create the style
            AlbumStyle rockStyle = new AlbumStyle("Rock");

            //rockStyle.AlbumStyleId = 1;
            //rockStyle.Name = "Rock";

            // To create an album
            Album testAlbum = new Album("Test Album", 12.5, DateTime.Now);
            //Album testAlbum = new Album();
            //testAlbum.AlbumId = 1;
            //testAlbum.Title = "Test Album";
            //testAlbum.Price = 12.5;
            //testAlbum.DatePublished = DateTime.Now;

            //testAlbum.Artist = artist;
            //testAlbum.Style = rockStyle;

            //......

            // Later on in the process, if somebody changes Album's id = 2,
            // it's not dorable after we use private keyword.
            //testAlbum.AlbumId = 2;

            return View();
        }
    }
}