namespace PageAndServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeedescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "description", c => c.String());
            DropColumn("dbo.Employees", "info_text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "info_text", c => c.String());
            DropColumn("dbo.Employees", "description");
        }
    }
}
