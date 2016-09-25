namespace DL.MusicStore.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitAlbumStructures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        DatePublished = c.DateTime(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        AlbumStyleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.AlbumStyles", t => t.AlbumStyleId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.AlbumStyleId);
            
            CreateTable(
                "dbo.AlbumStyles",
                c => new
                    {
                        AlbumStyleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumStyleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "AlbumStyleId", "dbo.AlbumStyles");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "AlbumStyleId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropTable("dbo.AlbumStyles");
            DropTable("dbo.Albums");
            DropTable("dbo.Artists");
        }
    }
}
