using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DL.MusicStore.Web.Mvc.Areas.Admin.Models.Album
{
    public class AlbumSummaryViewModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string DatePublished { get; set; }
        public string Artist { get; set; }
        public string Style { get; set; }
    }
}