using DL.MusicStore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.MusicStore.Persistence.EF.Mappings
{
    public class AlbumStyleMap : EntityTypeConfiguration<AlbumStyle>
    {
        public AlbumStyleMap()
        {
            // Define the key for the table
            HasKey(s => s.AlbumStyleId);    // Lamba expression

            // Define columns for the table
            Property(s => s.AlbumStyleId)
                .HasColumnName("AlbumStyleId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Name)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}
