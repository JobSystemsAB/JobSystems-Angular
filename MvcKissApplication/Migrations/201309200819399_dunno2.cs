namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunno2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextMessages", "status", c => c.String());
            AddColumn("dbo.TextMessages", "delivered", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TextMessages", "delivered");
            DropColumn("dbo.TextMessages", "status");
        }
    }
}
