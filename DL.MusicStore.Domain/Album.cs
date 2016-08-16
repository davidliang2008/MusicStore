using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.MusicStore.Domain
{
    public class Album
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime DatePublished { get; set; }

        public int ArtistId { get; set; }
        public int AlbumStyleId { get; set; }
        
        // Navigation properties used by Entity Framework.
        // Entity Framework will automatically fill out these.
        public virtual Artist Artist { get; set; }
        public virtual AlbumStyle Style { get; set; }
    }
}
