namespace Dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomanyartmartiauxsamurais : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArtMartials", "Samurai_Id", "dbo.Samurais");
            DropIndex("dbo.ArtMartials", new[] { "Samurai_Id" });
            CreateTable(
                "dbo.SamuraiArtMartials",
                c => new
                    {
                        Samurai_Id = c.Long(nullable: false),
                        ArtMartial_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Samurai_Id, t.ArtMartial_Id })
                .ForeignKey("dbo.Samurais", t => t.Samurai_Id, cascadeDelete: true)
                .ForeignKey("dbo.ArtMartials", t => t.ArtMartial_Id, cascadeDelete: true)
                .Index(t => t.Samurai_Id)
                .Index(t => t.ArtMartial_Id);
            
            DropColumn("dbo.ArtMartials", "Samurai_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtMartials", "Samurai_Id", c => c.Long());
            DropForeignKey("dbo.SamuraiArtMartials", "ArtMartial_Id", "dbo.ArtMartials");
            DropForeignKey("dbo.SamuraiArtMartials", "Samurai_Id", "dbo.Samurais");
            DropIndex("dbo.SamuraiArtMartials", new[] { "ArtMartial_Id" });
            DropIndex("dbo.SamuraiArtMartials", new[] { "Samurai_Id" });
            DropTable("dbo.SamuraiArtMartials");
            CreateIndex("dbo.ArtMartials", "Samurai_Id");
            AddForeignKey("dbo.ArtMartials", "Samurai_Id", "dbo.Samurais", "Id");
        }
    }
}
