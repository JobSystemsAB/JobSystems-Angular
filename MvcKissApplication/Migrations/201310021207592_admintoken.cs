namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admintoken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Administrators", "auth_token", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Administrators", "auth_token");
        }
    }
}
