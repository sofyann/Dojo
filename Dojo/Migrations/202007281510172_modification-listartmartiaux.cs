namespace Dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationlistartmartiaux : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Samurais", "Samurai_Id", "dbo.Samurais");
            DropIndex("dbo.Samurais", new[] { "Samurai_Id" });
            AddColumn("dbo.ArtMartials", "Samurai_Id", c => c.Long());
            CreateIndex("dbo.ArtMartials", "Samurai_Id");
            AddForeignKey("dbo.ArtMartials", "Samurai_Id", "dbo.Samurais", "Id");
            DropColumn("dbo.Samurais", "Samurai_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samurais", "Samurai_Id", c => c.Long());
            DropForeignKey("dbo.ArtMartials", "Samurai_Id", "dbo.Samurais");
            DropIndex("dbo.ArtMartials", new[] { "Samurai_Id" });
            DropColumn("dbo.ArtMartials", "Samurai_Id");
            CreateIndex("dbo.Samurais", "Samurai_Id");
            AddForeignKey("dbo.Samurais", "Samurai_Id", "dbo.Samurais", "Id");
        }
    }
}
