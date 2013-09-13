namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Administrators", "fakeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Missions", "fakeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Customers", "fakeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Employees", "fakeId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "fakeId");
            DropColumn("dbo.Customers", "fakeId");
            DropColumn("dbo.Missions", "fakeId");
            DropColumn("dbo.Administrators", "fakeId");
        }
    }
}
