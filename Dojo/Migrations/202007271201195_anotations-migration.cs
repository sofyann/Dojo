namespace Dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotationsmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Armes", "Nom", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Armes", "Nom", c => c.String());
        }
    }
}
