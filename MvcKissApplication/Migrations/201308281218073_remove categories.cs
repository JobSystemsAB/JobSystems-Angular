namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecategories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Missions", "subsubcategory_id", "dbo.Subsubcategories");
            DropForeignKey("dbo.Missions", "subcategory_id", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "category_id", "dbo.Categories");
            DropForeignKey("dbo.Subsubcategories", "subcategory_id", "dbo.Subcategories");
            DropForeignKey("dbo.SubsubcategoryEmployees", "Subsubcategory_id", "dbo.Subsubcategories");
            DropForeignKey("dbo.SubsubcategoryEmployees", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.SubcategoryEmployees", "Subcategory_id", "dbo.Subcategories");
            DropForeignKey("dbo.SubcategoryEmployees", "Employee_id", "dbo.Employees");
            DropIndex("dbo.Missions", new[] { "subsubcategory_id" });
            DropIndex("dbo.Missions", new[] { "subcategory_id" });
            DropIndex("dbo.Subcategories", new[] { "category_id" });
            DropIndex("dbo.Subsubcategories", new[] { "subcategory_id" });
            DropIndex("dbo.SubsubcategoryEmployees", new[] { "Subsubcategory_id" });
            DropIndex("dbo.SubsubcategoryEmployees", new[] { "Employee_id" });
            DropIndex("dbo.SubcategoryEmployees", new[] { "Subcategory_id" });
            DropIndex("dbo.SubcategoryEmployees", new[] { "Employee_id" });
            DropColumn("dbo.Missions", "subsubcategory_id");
            DropColumn("dbo.Missions", "subcategory_id");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Subsubcategories");
            DropTable("dbo.SubsubcategoryEmployees");
            DropTable("dbo.SubcategoryEmployees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubcategoryEmployees",
                c => new
                    {
                        Subcategory_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subcategory_id, t.Employee_id });
            
            CreateTable(
                "dbo.SubsubcategoryEmployees",
                c => new
                    {
                        Subsubcategory_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subsubcategory_id, t.Employee_id });
            
            CreateTable(
                "dbo.Subsubcategories",
                c => new
                    {
                        subsubcategory_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        subcategory_id = c.Int(),
                    })
                .PrimaryKey(t => t.subsubcategory_id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        subcategory_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        category_id = c.Int(),
                    })
                .PrimaryKey(t => t.subcategory_id);
            
            AddColumn("dbo.Missions", "subcategory_id", c => c.Int());
            AddColumn("dbo.Missions", "subsubcategory_id", c => c.Int());
            CreateIndex("dbo.SubcategoryEmployees", "Employee_id");
            CreateIndex("dbo.SubcategoryEmployees", "Subcategory_id");
            CreateIndex("dbo.SubsubcategoryEmployees", "Employee_id");
            CreateIndex("dbo.SubsubcategoryEmployees", "Subsubcategory_id");
            CreateIndex("dbo.Subsubcategories", "subcategory_id");
            CreateIndex("dbo.Subcategories", "category_id");
            CreateIndex("dbo.Missions", "subcategory_id");
            CreateIndex("dbo.Missions", "subsubcategory_id");
            AddForeignKey("dbo.SubcategoryEmployees", "Employee_id", "dbo.Employees", "employee_id", cascadeDelete: true);
            AddForeignKey("dbo.SubcategoryEmployees", "Subcategory_id", "dbo.Subcategories", "subcategory_id", cascadeDelete: true);
            AddForeignKey("dbo.SubsubcategoryEmployees", "Employee_id", "dbo.Employees", "employee_id", cascadeDelete: true);
            AddForeignKey("dbo.SubsubcategoryEmployees", "Subsubcategory_id", "dbo.Subsubcategories", "subsubcategory_id", cascadeDelete: true);
            AddForeignKey("dbo.Subsubcategories", "subcategory_id", "dbo.Subcategories", "subcategory_id");
            AddForeignKey("dbo.Subcategories", "category_id", "dbo.Categories", "category_id");
            AddForeignKey("dbo.Missions", "subcategory_id", "dbo.Subcategories", "subcategory_id");
            AddForeignKey("dbo.Missions", "subsubcategory_id", "dbo.Subsubcategories", "subsubcategory_id");
        }
    }
}
