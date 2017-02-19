using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DL.MusicStore.Web.Mvc.Areas.Admin.Models.Artist
{
    public class ArtistSummaryViewModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int NumberOfAlbums { get; set; }
    }
}