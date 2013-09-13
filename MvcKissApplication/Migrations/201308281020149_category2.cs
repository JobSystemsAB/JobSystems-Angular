namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeSubcategories", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeSubcategories", "Subcategory_id", "dbo.Subcategories");
            DropForeignKey("dbo.EmployeeSubsubcategories", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeSubsubcategories", "Subsubcategory_id", "dbo.Subsubcategories");
            DropIndex("dbo.EmployeeSubcategories", new[] { "Employee_id" });
            DropIndex("dbo.EmployeeSubcategories", new[] { "Subcategory_id" });
            DropIndex("dbo.EmployeeSubsubcategories", new[] { "Employee_id" });
            DropIndex("dbo.EmployeeSubsubcategories", new[] { "Subsubcategory_id" });
            CreateTable(
                "dbo.SubsubcategoryEmployees",
                c => new
                    {
                        Subsubcategory_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subsubcategory_id, t.Employee_id })
                .ForeignKey("dbo.Subsubcategories", t => t.Subsubcategory_id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Subsubcategory_id)
                .Index(t => t.Employee_id);
            
            CreateTable(
                "dbo.SubcategoryEmployees",
                c => new
                    {
                        Subcategory_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subcategory_id, t.Employee_id })
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Subcategory_id)
                .Index(t => t.Employee_id);
            
            AddColumn("dbo.Categories", "parent_id", c => c.Int());
            AddForeignKey("dbo.Categories", "parent_id", "dbo.Categories", "category_id");
            CreateIndex("dbo.Categories", "parent_id");
            DropTable("dbo.EmployeeSubcategories");
            DropTable("dbo.EmployeeSubsubcategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeSubsubcategories",
                c => new
                    {
                        Employee_id = c.Int(nullable: false),
                        Subsubcategory_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_id, t.Subsubcategory_id });
            
            CreateTable(
                "dbo.EmployeeSubcategories",
                c => new
                    {
                        Employee_id = c.Int(nullable: false),
                        Subcategory_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_id, t.Subcategory_id });
            
            DropIndex("dbo.SubcategoryEmployees", new[] { "Employee_id" });
            DropIndex("dbo.SubcategoryEmployees", new[] { "Subcategory_id" });
            DropIndex("dbo.SubsubcategoryEmployees", new[] { "Employee_id" });
            DropIndex("dbo.SubsubcategoryEmployees", new[] { "Subsubcategory_id" });
            DropIndex("dbo.Categories", new[] { "parent_id" });
            DropForeignKey("dbo.SubcategoryEmployees", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.SubcategoryEmployees", "Subcategory_id", "dbo.Subcategories");
            DropForeignKey("dbo.SubsubcategoryEmployees", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.SubsubcategoryEmployees", "Subsubcategory_id", "dbo.Subsubcategories");
            DropForeignKey("dbo.Categories", "parent_id", "dbo.Categories");
            DropColumn("dbo.Categories", "parent_id");
            DropTable("dbo.SubcategoryEmployees");
            DropTable("dbo.SubsubcategoryEmployees");
            CreateIndex("dbo.EmployeeSubsubcategories", "Subsubcategory_id");
            CreateIndex("dbo.EmployeeSubsubcategories", "Employee_id");
            CreateIndex("dbo.EmployeeSubcategories", "Subcategory_id");
            CreateIndex("dbo.EmployeeSubcategories", "Employee_id");
            AddForeignKey("dbo.EmployeeSubsubcategories", "Subsubcategory_id", "dbo.Subsubcategories", "subsubcategory_id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSubsubcategories", "Employee_id", "dbo.Employees", "employee_id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSubcategories", "Subcategory_id", "dbo.Subcategories", "subcategory_id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSubcategories", "Employee_id", "dbo.Employees", "employee_id", cascadeDelete: true);
        }
    }
}
