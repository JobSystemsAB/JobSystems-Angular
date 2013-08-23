namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunno1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryInputs",
                c => new
                    {
                        category_input_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        text = c.String(),
                        type = c.String(),
                        category_id = c.Int(),
                    })
                .PrimaryKey(t => t.category_input_id)
                .ForeignKey("dbo.Categories", t => t.category_id)
                .Index(t => t.category_id);
            
            AddColumn("dbo.Missions", "extras", c => c.String());
        }
        
        public override void Down()
        {
            DropIndex("dbo.CategoryInputs", new[] { "category_id" });
            DropForeignKey("dbo.CategoryInputs", "category_id", "dbo.Categories");
            DropColumn("dbo.Missions", "extras");
            DropTable("dbo.CategoryInputs");
        }
    }
}
