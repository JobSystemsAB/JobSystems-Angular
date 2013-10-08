namespace PageAndServices.Migrations
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
                        fake_id = c.Guid(nullable: false),
                        auth_token = c.Guid(nullable: false),
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
                        salary = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        parent_id = c.Int(),
                    })
                .PrimaryKey(t => t.category_id)
                .ForeignKey("dbo.Categories", t => t.parent_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        mission_id = c.Int(nullable: false, identity: true),
                        fakeId = c.Guid(nullable: false),
                        hours = c.Int(),
                        description = c.String(),
                        extras = c.String(),
                        address_streetNumber = c.String(),
                        address_street = c.String(),
                        address_postalCode = c.String(),
                        address_postalTown = c.String(),
                        address_country = c.String(),
                        address_longitude = c.Double(nullable: false),
                        address_latitude = c.Double(nullable: false),
                        date = c.DateTime(),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                        customer_id = c.Int(),
                        employee_id = c.Int(),
                    })
                .PrimaryKey(t => t.mission_id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .ForeignKey("dbo.Employees", t => t.employee_id)
                .Index(t => t.customer_id)
                .Index(t => t.employee_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        fakeId = c.Guid(nullable: false),
                        email_address = c.String(),
                        phone_number = c.String(),
                        password = c.String(),
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
                "dbo.Comments",
                c => new
                    {
                        comment_id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        customer_id = c.Int(),
                        employee_id = c.Int(),
                        mission_id = c.Int(),
                    })
                .PrimaryKey(t => t.comment_id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .ForeignKey("dbo.Employees", t => t.employee_id)
                .ForeignKey("dbo.Missions", t => t.mission_id)
                .Index(t => t.customer_id)
                .Index(t => t.employee_id)
                .Index(t => t.mission_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        fakeId = c.Guid(nullable: false),
                        info_text = c.String(),
                        first_name = c.String(),
                        last_name = c.String(),
                        email_address = c.String(),
                        phone_number = c.String(),
                        personal_number = c.String(),
                        bank_name = c.String(),
                        bank_clreaing_number = c.String(),
                        bank_account_number = c.String(),
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
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        testimonial_id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        name = c.String(),
                        language = c.String(),
                        created = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.testimonial_id);
            
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        text_id = c.Int(nullable: false, identity: true),
                        controller_name = c.String(),
                        element_id = c.String(),
                        language = c.String(),
                        text = c.String(),
                        enabled = c.Boolean(nullable: false),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.text_id);
            
            CreateTable(
                "dbo.TextMessages",
                c => new
                    {
                        text_id = c.Int(nullable: false, identity: true),
                        from = c.String(),
                        to = c.String(),
                        message = c.String(),
                        api_id = c.String(),
                        error_message = c.String(),
                        status = c.String(),
                        error = c.Boolean(nullable: false),
                        created = c.DateTime(nullable: false),
                        delivered = c.DateTime(),
                    })
                .PrimaryKey(t => t.text_id);
            
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.MissionCategories", new[] { "Category_id" });
            DropIndex("dbo.MissionCategories", new[] { "Mission_id" });
            DropIndex("dbo.EmployeeCategories", new[] { "Category_id" });
            DropIndex("dbo.EmployeeCategories", new[] { "Employee_id" });
            DropIndex("dbo.CategoryInputs", new[] { "category_id" });
            DropIndex("dbo.WorkShifts", new[] { "mission_id" });
            DropIndex("dbo.WorkShifts", new[] { "employee_id" });
            DropIndex("dbo.Comments", new[] { "mission_id" });
            DropIndex("dbo.Comments", new[] { "employee_id" });
            DropIndex("dbo.Comments", new[] { "customer_id" });
            DropIndex("dbo.Missions", new[] { "employee_id" });
            DropIndex("dbo.Missions", new[] { "customer_id" });
            DropIndex("dbo.Categories", new[] { "parent_id" });
            DropForeignKey("dbo.MissionCategories", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.MissionCategories", "Mission_id", "dbo.Missions");
            DropForeignKey("dbo.EmployeeCategories", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.EmployeeCategories", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.CategoryInputs", "category_id", "dbo.Categories");
            DropForeignKey("dbo.WorkShifts", "mission_id", "dbo.Missions");
            DropForeignKey("dbo.WorkShifts", "employee_id", "dbo.Employees");
            DropForeignKey("dbo.Comments", "mission_id", "dbo.Missions");
            DropForeignKey("dbo.Comments", "employee_id", "dbo.Employees");
            DropForeignKey("dbo.Comments", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Missions", "employee_id", "dbo.Employees");
            DropForeignKey("dbo.Missions", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Categories", "parent_id", "dbo.Categories");
            DropTable("dbo.MissionCategories");
            DropTable("dbo.EmployeeCategories");
            DropTable("dbo.TextMessages");
            DropTable("dbo.Texts");
            DropTable("dbo.Testimonials");
            DropTable("dbo.CategoryInputs");
            DropTable("dbo.WorkShifts");
            DropTable("dbo.Employees");
            DropTable("dbo.Comments");
            DropTable("dbo.Customers");
            DropTable("dbo.Missions");
            DropTable("dbo.Categories");
            DropTable("dbo.Administrators");
        }
    }
}
