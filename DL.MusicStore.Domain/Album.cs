using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.MusicStore.Domain
{
    public class Album
    {
        public int AlbumId { get; private set; }
        public string Title { get; private set; }
        public double Price { get; private set; }
        public DateTime DatePublished { get; private set; }

        public int ArtistId { get; private set; }
        public int AlbumStyleId { get; private set; }
        
        // Navigation properties used by Entity Framework.
        // Entity Framework will automatically fill out these.
        public virtual Artist Artist { get; private set; }
        public virtual AlbumStyle Style { get; private set; }

        #region Constructors

        // Parameterless constructor will be used by Entity Framework
        protected Album() { }

        public Album(string title, double price, DateTime datePublished)
        {
            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title");
            }
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("price");
            }

            this.Title = title;
            this.Price = price;
            this.DatePublished = datePublished;
        }

        #endregion
    }
}
