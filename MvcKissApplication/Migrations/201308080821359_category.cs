namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "salary", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "url");
            DropColumn("dbo.Categories", "salary");
        }
    }
}
