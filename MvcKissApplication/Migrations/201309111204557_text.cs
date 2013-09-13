namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class text : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Texts", "updated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Texts", "updated");
            DropColumn("dbo.Texts", "created");
        }
    }
}
