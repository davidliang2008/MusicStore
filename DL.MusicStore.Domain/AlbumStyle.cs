using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.MusicStore.Domain
{
    public class AlbumStyle
    {
        public int AlbumStyleId { get; set; }
        public string Name { get; set; }

        // Navigation properties used by Entity Framework
        public virtual ICollection<Album> Albums { get; set; }
    }
}
