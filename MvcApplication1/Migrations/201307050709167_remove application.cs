namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeapplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "sendSms", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "sendMail", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "sendMail");
            DropColumn("dbo.Employees", "sendSms");
        }
    }
}
