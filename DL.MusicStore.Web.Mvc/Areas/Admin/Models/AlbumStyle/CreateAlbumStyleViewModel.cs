using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DL.MusicStore.Web.Mvc.Areas.Admin.Models.AlbumStyle
{
    public class CreateAlbumStyleViewModel
    {
        [Display(Name = "Name of style")]
        public string StyleName { get; set; }
    }
}