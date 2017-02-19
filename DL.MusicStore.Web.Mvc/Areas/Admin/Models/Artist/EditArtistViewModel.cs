using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DL.MusicStore.Web.Mvc.Areas.Admin.Models.Artist
{
    public class EditArtistViewModel
    {
        [Required]
        public int ArtistId { get; set; }

        [Required]
        [Display(Name = "Artist name")]
        public string ArtistName { get; set; }
    }
}