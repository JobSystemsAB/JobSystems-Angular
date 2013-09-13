namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class texts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        text_id = c.Int(nullable: false, identity: true),
                        controllerName = c.String(),
                        elementId = c.String(),
                        language = c.String(),
                    })
                .PrimaryKey(t => t.text_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Texts");
        }
    }
}
