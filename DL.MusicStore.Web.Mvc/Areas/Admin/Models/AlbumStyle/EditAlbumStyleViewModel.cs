using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DL.MusicStore.Web.Mvc.Areas.Admin.Models.AlbumStyle
{
    public class EditAlbumStyleViewModel
    {
        [Required]
        public int AlbumStyleId { get; set; }

        [Required]
        [Display(Name = "Name of style")]
        public string AlbumStyleName { get; set; }
    }
}