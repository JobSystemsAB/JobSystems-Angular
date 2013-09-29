namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class textupdated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Texts", "updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Texts", "updated", c => c.DateTime(nullable: false));
        }
    }
}
