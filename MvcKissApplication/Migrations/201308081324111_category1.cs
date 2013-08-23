namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "url", c => c.String());
        }
    }
}
