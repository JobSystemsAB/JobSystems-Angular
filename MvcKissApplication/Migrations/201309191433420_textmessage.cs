namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class textmessage : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Administrators", name: "fakeId", newName: "fake_id");
            RenameColumn(table: "dbo.Texts", name: "elementId", newName: "email_id");
            CreateTable(
                "dbo.TextMessages",
                c => new
                    {
                        text_id = c.Int(nullable: false, identity: true),
                        from = c.String(),
                        to = c.String(),
                        message = c.String(),
                        elk_id = c.String(),
                        error_message = c.String(),
                        error = c.Boolean(nullable: false),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.text_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TextMessages");
            RenameColumn(table: "dbo.Texts", name: "email_id", newName: "elementId");
            RenameColumn(table: "dbo.Administrators", name: "fake_id", newName: "fakeId");
        }
    }
}
