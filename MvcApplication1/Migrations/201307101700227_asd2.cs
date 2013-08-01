namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "created1", c => c.DateTime());
            AddColumn("dbo.EmployeesPet", "created", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployeesPet", "isPet", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "created", c => c.DateTime());
            DropColumn("dbo.Employees", "created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "created", c => c.DateTime(nullable: false));
            DropColumn("dbo.EmployeesPet", "isPet");
            DropColumn("dbo.EmployeesPet", "created");
            DropColumn("dbo.Customers", "created1");
        }
    }
}
