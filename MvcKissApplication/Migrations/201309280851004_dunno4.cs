namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunno4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Texts", name: "controllerName", newName: "controller_name");
            RenameColumn(table: "dbo.Texts", name: "email_id", newName: "element_id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Texts", name: "element_id", newName: "email_id");
            RenameColumn(table: "dbo.Texts", name: "controller_name", newName: "controllerName");
        }
    }
}
