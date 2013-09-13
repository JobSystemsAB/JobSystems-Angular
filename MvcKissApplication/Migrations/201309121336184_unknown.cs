namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknown : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Missions", "category_id", "dbo.Categories");
            DropIndex("dbo.Missions", new[] { "category_id" });
            CreateTable(
                "dbo.MissionCategories",
                c => new
                    {
                        Mission_id = c.Int(nullable: false),
                        Category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mission_id, t.Category_id })
                .ForeignKey("dbo.Missions", t => t.Mission_id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_id, cascadeDelete: true)
                .Index(t => t.Mission_id)
                .Index(t => t.Category_id);
            
            DropColumn("dbo.Missions", "category_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Missions", "category_id", c => c.Int());
            DropIndex("dbo.MissionCategories", new[] { "Category_id" });
            DropIndex("dbo.MissionCategories", new[] { "Mission_id" });
            DropForeignKey("dbo.MissionCategories", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.MissionCategories", "Mission_id", "dbo.Missions");
            DropTable("dbo.MissionCategories");
            CreateIndex("dbo.Missions", "category_id");
            AddForeignKey("dbo.Missions", "category_id", "dbo.Categories", "category_id");
        }
    }
}
