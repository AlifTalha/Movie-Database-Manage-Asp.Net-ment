namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favoriteMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favorites", "MovieId", "dbo.Movies");
            DropIndex("dbo.Favorites", new[] { "MovieId" });
            DropIndex("dbo.Favorites", new[] { "UserId" });
            DropTable("dbo.Favorites");
        }
    }
}
