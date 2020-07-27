namespace Dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Degats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Samurais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Force = c.Int(nullable: false),
                        Nom = c.String(),
                        Arme_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Armes", t => t.Arme_Id)
                .Index(t => t.Arme_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samurais", "Arme_Id", "dbo.Armes");
            DropIndex("dbo.Samurais", new[] { "Arme_Id" });
            DropTable("dbo.Samurais");
            DropTable("dbo.Armes");
        }
    }
}
