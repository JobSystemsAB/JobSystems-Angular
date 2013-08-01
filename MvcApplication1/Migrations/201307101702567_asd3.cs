namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "created", newName: "created_company");
            RenameColumn(table: "dbo.Customers", name: "created1", newName: "created_private");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Customers", name: "created_private", newName: "created1");
            RenameColumn(table: "dbo.Customers", name: "created_company", newName: "created");
        }
    }
}
