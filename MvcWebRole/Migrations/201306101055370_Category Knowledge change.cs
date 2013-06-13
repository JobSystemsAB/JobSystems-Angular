namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryKnowledgechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Knowledges", "Performer_id", c => c.Int());
            AddForeignKey("dbo.Knowledges", "Performer_id", "dbo.Performers", "id");
            CreateIndex("dbo.Knowledges", "Performer_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Knowledges", new[] { "Performer_id" });
            DropForeignKey("dbo.Knowledges", "Performer_id", "dbo.Performers");
            DropColumn("dbo.Knowledges", "Performer_id");
        }
    }
}
