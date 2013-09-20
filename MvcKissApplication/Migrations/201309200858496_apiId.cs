namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apiId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextMessages", "api_id", c => c.String());
            DropColumn("dbo.TextMessages", "elk_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TextMessages", "elk_id", c => c.String());
            DropColumn("dbo.TextMessages", "api_id");
        }
    }
}
