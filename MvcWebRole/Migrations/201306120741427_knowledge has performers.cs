namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class knowledgehasperformers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Knowledges", "Performer_id", "dbo.Performers");
            DropIndex("dbo.Knowledges", new[] { "Performer_id" });
            CreateTable(
                "dbo.KnowledgePerformers",
                c => new
                    {
                        Knowledge_id = c.Int(nullable: false),
                        Performer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Knowledge_id, t.Performer_id })
                .ForeignKey("dbo.Knowledges", t => t.Knowledge_id, cascadeDelete: true)
                .ForeignKey("dbo.Performers", t => t.Performer_id, cascadeDelete: true)
                .Index(t => t.Knowledge_id)
                .Index(t => t.Performer_id);
            
            DropColumn("dbo.Knowledges", "Performer_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Knowledges", "Performer_id", c => c.Int());
            DropIndex("dbo.KnowledgePerformers", new[] { "Performer_id" });
            DropIndex("dbo.KnowledgePerformers", new[] { "Knowledge_id" });
            DropForeignKey("dbo.KnowledgePerformers", "Performer_id", "dbo.Performers");
            DropForeignKey("dbo.KnowledgePerformers", "Knowledge_id", "dbo.Knowledges");
            DropTable("dbo.KnowledgePerformers");
            CreateIndex("dbo.Knowledges", "Performer_id");
            AddForeignKey("dbo.Knowledges", "Performer_id", "dbo.Performers", "id");
        }
    }
}
