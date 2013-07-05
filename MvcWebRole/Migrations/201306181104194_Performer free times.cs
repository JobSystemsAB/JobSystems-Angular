namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Performerfreetimes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Knowledges", "categoryId", "dbo.Categories");
            DropIndex("dbo.Knowledges", new[] { "categoryId" });
            CreateTable(
                "dbo.PerformerTimeReports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        assignmentId = c.Int(),
                        performerId = c.Int(),
                        hours = c.Int(nullable: false),
                        minutes = c.Int(nullable: false),
                        updated = c.DateTime(),
                        created = c.DateTime(),
                        startReport = c.DateTime(),
                        endReport = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Assignments", t => t.assignmentId)
                .ForeignKey("dbo.Performers", t => t.performerId)
                .Index(t => t.assignmentId)
                .Index(t => t.performerId);
            
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Performers", t => t.performerId, cascadeDelete: true)
                .Index(t => t.performerId);
            
            AddForeignKey("dbo.Knowledges", "categoryId", "dbo.Categories", "id", cascadeDelete: true);
            CreateIndex("dbo.Knowledges", "categoryId");
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TimeReports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        assignmentId = c.Int(),
                        performerId = c.Int(),
                        hours = c.Int(nullable: false),
                        minutes = c.Int(nullable: false),
                        updated = c.DateTime(),
                        created = c.DateTime(),
                        startReport = c.DateTime(),
                        endReport = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            DropIndex("dbo.PerformerFreeTimes", new[] { "performerId" });
            DropIndex("dbo.Knowledges", new[] { "categoryId" });
            DropIndex("dbo.PerformerTimeReports", new[] { "performerId" });
            DropIndex("dbo.PerformerTimeReports", new[] { "assignmentId" });
            DropForeignKey("dbo.PerformerFreeTimes", "performerId", "dbo.Performers");
            DropForeignKey("dbo.Knowledges", "categoryId", "dbo.Categories");
            DropForeignKey("dbo.PerformerTimeReports", "performerId", "dbo.Performers");
            DropForeignKey("dbo.PerformerTimeReports", "assignmentId", "dbo.Assignments");
            DropTable("dbo.PerformerFreeTimes");
            DropTable("dbo.Categories");
            DropTable("dbo.PerformerTimeReports");
            CreateIndex("dbo.Knowledges", "categoryId");
            CreateIndex("dbo.TimeReports", "performerId");
            CreateIndex("dbo.TimeReports", "assignmentId");
            AddForeignKey("dbo.Knowledges", "categoryId", "dbo.Categories", "id", cascadeDelete: true);
            AddForeignKey("dbo.TimeReports", "performerId", "dbo.Performers", "id");
            AddForeignKey("dbo.TimeReports", "assignmentId", "dbo.Assignments", "id");
        }
    }
}
