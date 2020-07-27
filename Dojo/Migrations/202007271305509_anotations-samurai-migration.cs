namespace Dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotationssamuraimigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Samurais", "Nom", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Samurais", "Nom", c => c.String());
        }
    }
}
