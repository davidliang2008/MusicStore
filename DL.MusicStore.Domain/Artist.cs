using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.MusicStore.Domain
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<Album> Albums { get; set; }
    }
}
