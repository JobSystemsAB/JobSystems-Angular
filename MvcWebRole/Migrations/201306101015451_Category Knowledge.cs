namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryKnowledge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Knowledges",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        categoryId = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
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
                "dbo.KnowledgeAssignments",
                c => new
                    {
                        Knowledge_id = c.Int(nullable: false),
                        Assignment_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Knowledge_id, t.Assignment_id })
                .ForeignKey("dbo.Knowledges", t => t.Knowledge_id, cascadeDelete: true)
                .ForeignKey("dbo.Assignments", t => t.Assignment_id, cascadeDelete: true)
                .Index(t => t.Knowledge_id)
                .Index(t => t.Assignment_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.KnowledgeAssignments", new[] { "Assignment_id" });
            DropIndex("dbo.KnowledgeAssignments", new[] { "Knowledge_id" });
            DropIndex("dbo.Knowledges", new[] { "categoryId" });
            DropForeignKey("dbo.KnowledgeAssignments", "Assignment_id", "dbo.Assignments");
            DropForeignKey("dbo.KnowledgeAssignments", "Knowledge_id", "dbo.Knowledges");
            DropForeignKey("dbo.Knowledges", "categoryId", "dbo.Categories");
            DropTable("dbo.KnowledgeAssignments");
            DropTable("dbo.Categories");
            DropTable("dbo.Knowledges");
        }
    }
}
