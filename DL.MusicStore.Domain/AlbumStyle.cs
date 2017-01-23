using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.MusicStore.Domain
{
    public class AlbumStyle
    {
        public int AlbumStyleId { get; private set; }
        public string Name { get; private set; }

        // Navigation properties used by Entity Framework
        public virtual ICollection<Album> Albums { get; private set; }

        #region Constructors

        // Parameterless constructor will be used by Entity Framework
        protected AlbumStyle()
        {
            this.Albums = new HashSet<Album>();
        }

        public AlbumStyle(string styleName) : this()
        {
            // You can put additional logics here

            // 1) Logging
            // somebody just created an album style

            // 2) Validations
            if (String.IsNullOrEmpty(styleName))
            {
                throw new ArgumentNullException("styleName");
            }

            this.Name = styleName;
        }

        #endregion

        #region Methods
        
        public void UpdateName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            // Logging

            this.Name = name;
        }

        #endregion
    }
}
