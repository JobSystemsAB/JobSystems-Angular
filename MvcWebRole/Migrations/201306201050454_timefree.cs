namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timefree : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PerformerFreeTimes", "performerId", "dbo.Performers");
            DropIndex("dbo.PerformerFreeTimes", new[] { "performerId" });
            CreateTable(
                "dbo.PerformerTimesFree",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        performerId = c.Int(nullable: false),
                        changed = c.DateTime(nullable: false),
                        day = c.DateTime(nullable: false, storeType: "date"),
                        morning = c.Boolean(nullable: false),
                        afternoon = c.Boolean(nullable: false),
                        evening = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Performers", t => t.performerId, cascadeDelete: true)
                .Index(t => t.performerId);
            
            DropTable("dbo.PerformerFreeTimes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PerformerFreeTimes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        performerId = c.Int(nullable: false),
                        day = c.DateTime(nullable: false, storeType: "date"),
                        morning = c.Boolean(nullable: false),
                        afternoon = c.Boolean(nullable: false),
                        evening = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropIndex("dbo.PerformerTimesFree", new[] { "performerId" });
            DropForeignKey("dbo.PerformerTimesFree", "performerId", "dbo.Performers");
            DropTable("dbo.PerformerTimesFree");
            CreateIndex("dbo.PerformerFreeTimes", "performerId");
            AddForeignKey("dbo.PerformerFreeTimes", "performerId", "dbo.Performers", "id", cascadeDelete: true);
        }
    }
}
