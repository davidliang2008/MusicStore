using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.MusicStore.Domain
{
    public class Artist
    {
        public int ArtistId { get; private set; }
        public string Name { get; private set; }

        // Navigation properties
        public virtual ICollection<Album> Albums { get; private set; }

        #region Constructors
        
        protected Artist()
        {
            this.Albums = new HashSet<Album>();
        }

        public Artist(string artistName) : this()
        {
            if (String.IsNullOrEmpty(artistName))
            {
                throw new ArgumentNullException("artistName");
            }

            this.Name = artistName;
        }

        #endregion
    }
}
