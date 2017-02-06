using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DL.MusicStore.Web.Mvc.Areas.Admin.Models.Album
{
    public class EditAlbumViewModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        [Display(Name = "Selected style")]
        public int SelectedStyleId { get; set; }
        public Dictionary<int, string> AvailableStyles { get; set; }

        [Display(Name = "Selected artist")]
        public int SelectedArtistId { get; set; }
        public Dictionary<int, string> AvailableArtists { get; set; }
    }
}