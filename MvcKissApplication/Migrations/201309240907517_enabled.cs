namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enabled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "enabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Texts", "enabled");
        }
    }
}
