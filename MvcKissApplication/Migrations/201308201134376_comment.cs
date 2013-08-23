namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        comment_id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        customer_id = c.Int(),
                        employee_id = c.Int(),
                        mission_id = c.Int(),
                    })
                .PrimaryKey(t => t.comment_id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .ForeignKey("dbo.Employees", t => t.employee_id)
                .ForeignKey("dbo.Missions", t => t.mission_id)
                .Index(t => t.customer_id)
                .Index(t => t.employee_id)
                .Index(t => t.mission_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "mission_id" });
            DropIndex("dbo.Comments", new[] { "employee_id" });
            DropIndex("dbo.Comments", new[] { "customer_id" });
            DropForeignKey("dbo.Comments", "mission_id", "dbo.Missions");
            DropForeignKey("dbo.Comments", "employee_id", "dbo.Employees");
            DropForeignKey("dbo.Comments", "customer_id", "dbo.Customers");
            DropTable("dbo.Comments");
        }
    }
}
