namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        administrator_id = c.Int(nullable: false, identity: true),
                        password = c.String(),
                        email_address = c.String(),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.administrator_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.category_id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        subcategory_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        category_id = c.Int(),
                    })
                .PrimaryKey(t => t.subcategory_id)
                .ForeignKey("dbo.Categories", t => t.category_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.Subsubcategories",
                c => new
                    {
                        subsubcategory_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        subcategory_id = c.Int(),
                    })
                .PrimaryKey(t => t.subsubcategory_id)
                .ForeignKey("dbo.Subcategories", t => t.subcategory_id)
                .Index(t => t.subcategory_id);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        mission_id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        address_streetNumber = c.String(),
                        address_street = c.String(),
                        address_postalCode = c.String(),
                        address_postalTown = c.String(),
                        address_country = c.String(),
                        address_longitude = c.Double(nullable: false),
                        address_latitude = c.Double(nullable: false),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                        customer_id = c.Int(),
                        employee_id = c.Int(),
                        category_id = c.Int(),
                        subcategory_id = c.Int(),
                        subsubcategory_id = c.Int(),
                    })
                .PrimaryKey(t => t.mission_id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .ForeignKey("dbo.Employees", t => t.employee_id)
                .ForeignKey("dbo.Categories", t => t.category_id)
                .ForeignKey("dbo.Subcategories", t => t.subcategory_id)
                .ForeignKey("dbo.Subsubcategories", t => t.subsubcategory_id)
                .Index(t => t.customer_id)
                .Index(t => t.employee_id)
                .Index(t => t.category_id)
                .Index(t => t.subcategory_id)
                .Index(t => t.subsubcategory_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        email_address = c.String(),
                        phone_number = c.String(),
                        password = c.String(),
                        address_streetNumber = c.String(),
                        address_street = c.String(),
                        address_postalCode = c.String(),
                        address_postalTown = c.String(),
                        address_country = c.String(),
                        address_longitude = c.Double(nullable: false),
                        address_latitude = c.Double(nullable: false),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                        organisation_number = c.String(),
                        company_name = c.String(),
                        first_name = c.String(),
                        last_name = c.String(),
                        personal_number = c.String(),
                        property_name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        info_text = c.String(),
                        first_name = c.String(),
                        last_name = c.String(),
                        email_address = c.String(),
                        phone_number = c.String(),
                        personal_number = c.String(),
                        bank_name = c.String(),
                        bank_clreaing_number = c.String(),
                        bank_account_number = c.String(),
                        hour_salary = c.String(),
                        password = c.String(),
                        address_streetNumber = c.String(),
                        address_street = c.String(),
                        address_postalCode = c.String(),
                        address_postalTown = c.String(),
                        address_country = c.String(),
                        address_longitude = c.Double(nullable: false),
                        address_latitude = c.Double(nullable: false),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.employee_id);
            
            CreateTable(
                "dbo.WorkShifts",
                c => new
                    {
                        work_shift_id = c.Int(nullable: false, identity: true),
                        span = c.Time(nullable: false),
                        date = c.DateTime(nullable: false),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        employee_id = c.Int(),
                        mission_id = c.Int(),
                    })
                .PrimaryKey(t => t.work_shift_id)
                .ForeignKey("dbo.Employees", t => t.employee_id)
                .ForeignKey("dbo.Missions", t => t.mission_id)
                .Index(t => t.employee_id)
                .Index(t => t.mission_id);
            
            CreateTable(
                "dbo.EmployeeCategories",
                c => new
                    {
                        Employee_id = c.Int(nullable: false),
                        Category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_id, t.Category_id })
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_id, cascadeDelete: true)
                .Index(t => t.Employee_id)
                .Index(t => t.Category_id);
            
            CreateTable(
                "dbo.EmployeeSubcategories",
                c => new
                    {
                        Employee_id = c.Int(nullable: false),
                        Subcategory_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_id, t.Subcategory_id })
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_id, cascadeDelete: true)
                .Index(t => t.Employee_id)
                .Index(t => t.Subcategory_id);
            
            CreateTable(
                "dbo.EmployeeSubsubcategories",
                c => new
                    {
                        Employee_id = c.Int(nullable: false),
                        Subsubcategory_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_id, t.Subsubcategory_id })
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .ForeignKey("dbo.Subsubcategories", t => t.Subsubcategory_id, cascadeDelete: true)
                .Index(t => t.Employee_id)
                .Index(t => t.Subsubcategory_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.EmployeeSubsubcategories", new[] { "Subsubcategory_id" });
            DropIndex("dbo.EmployeeSubsubcategories", new[] { "Employee_id" });
            DropIndex("dbo.EmployeeSubcategories", new[] { "Subcategory_id" });
            DropIndex("dbo.EmployeeSubcategories", new[] { "Employee_id" });
            DropIndex("dbo.EmployeeCategories", new[] { "Category_id" });
            DropIndex("dbo.EmployeeCategories", new[] { "Employee_id" });
            DropIndex("dbo.WorkShifts", new[] { "mission_id" });
            DropIndex("dbo.WorkShifts", new[] { "employee_id" });
            DropIndex("dbo.Missions", new[] { "subsubcategory_id" });
            DropIndex("dbo.Missions", new[] { "subcategory_id" });
            DropIndex("dbo.Missions", new[] { "category_id" });
            DropIndex("dbo.Missions", new[] { "employee_id" });
            DropIndex("dbo.Missions", new[] { "customer_id" });
            DropIndex("dbo.Subsubcategories", new[] { "subcategory_id" });
            DropIndex("dbo.Subcategories", new[] { "category_id" });
            DropForeignKey("dbo.EmployeeSubsubcategories", "Subsubcategory_id", "dbo.Subsubcategories");
            DropForeignKey("dbo.EmployeeSubsubcategories", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeSubcategories", "Subcategory_id", "dbo.Subcategories");
            DropForeignKey("dbo.EmployeeSubcategories", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCategories", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.EmployeeCategories", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.WorkShifts", "mission_id", "dbo.Missions");
            DropForeignKey("dbo.WorkShifts", "employee_id", "dbo.Employees");
            DropForeignKey("dbo.Missions", "subsubcategory_id", "dbo.Subsubcategories");
            DropForeignKey("dbo.Missions", "subcategory_id", "dbo.Subcategories");
            DropForeignKey("dbo.Missions", "category_id", "dbo.Categories");
            DropForeignKey("dbo.Missions", "employee_id", "dbo.Employees");
            DropForeignKey("dbo.Missions", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Subsubcategories", "subcategory_id", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "category_id", "dbo.Categories");
            DropTable("dbo.EmployeeSubsubcategories");
            DropTable("dbo.EmployeeSubcategories");
            DropTable("dbo.EmployeeCategories");
            DropTable("dbo.WorkShifts");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Missions");
            DropTable("dbo.Subsubcategories");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Administrators");
        }
    }
}
