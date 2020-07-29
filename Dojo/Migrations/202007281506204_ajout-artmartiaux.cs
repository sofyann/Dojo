namespace Dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutartmartiaux : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Samurais", "Arme_Id", "dbo.Armes");
            DropIndex("dbo.Samurais", new[] { "Arme_Id" });
            DropPrimaryKey("dbo.Armes");
            DropPrimaryKey("dbo.Samurais");
            CreateTable(
                "dbo.ArtMartials",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Samurais", "Samurai_Id", c => c.Long());
            AlterColumn("dbo.Armes", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Samurais", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Samurais", "Arme_Id", c => c.Long());
            AddPrimaryKey("dbo.Armes", "Id");
            AddPrimaryKey("dbo.Samurais", "Id");
            CreateIndex("dbo.Samurais", "Arme_Id");
            CreateIndex("dbo.Samurais", "Samurai_Id");
            AddForeignKey("dbo.Samurais", "Samurai_Id", "dbo.Samurais", "Id");
            AddForeignKey("dbo.Samurais", "Arme_Id", "dbo.Armes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samurais", "Arme_Id", "dbo.Armes");
            DropForeignKey("dbo.Samurais", "Samurai_Id", "dbo.Samurais");
            DropIndex("dbo.Samurais", new[] { "Samurai_Id" });
            DropIndex("dbo.Samurais", new[] { "Arme_Id" });
            DropPrimaryKey("dbo.Samurais");
            DropPrimaryKey("dbo.Armes");
            AlterColumn("dbo.Samurais", "Arme_Id", c => c.Int());
            AlterColumn("dbo.Samurais", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Armes", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Samurais", "Samurai_Id");
            DropTable("dbo.ArtMartials");
            AddPrimaryKey("dbo.Samurais", "Id");
            AddPrimaryKey("dbo.Armes", "Id");
            CreateIndex("dbo.Samurais", "Arme_Id");
            AddForeignKey("dbo.Samurais", "Arme_Id", "dbo.Armes", "Id");
        }
    }
}
