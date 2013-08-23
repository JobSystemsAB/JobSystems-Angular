namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "hour_salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "hour_salary", c => c.String());
        }
    }
}
