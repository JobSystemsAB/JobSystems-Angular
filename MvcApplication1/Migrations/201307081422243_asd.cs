namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        administrator_id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        emailAddress = c.String(),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.administrator_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        emailAddress = c.String(),
                        phoneNumber = c.String(),
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
                        organisationNumber = c.String(),
                        companyName = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        personalNumber = c.String(),
                        propertyName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.customer_id);
            
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
                        enabled = c.Boolean(nullable: false),
                        duration = c.Int(),
                        startDateAndTime = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        customer_id = c.Int(),
                        employee_id = c.Int(),
                        pet_id = c.Int(),
                    })
                .PrimaryKey(t => t.mission_id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .ForeignKey("dbo.Employees", t => t.employee_id)
                .ForeignKey("dbo.Pets", t => t.pet_id)
                .Index(t => t.customer_id)
                .Index(t => t.employee_id)
                .Index(t => t.pet_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        infoText = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        emailAddress = c.String(),
                        mobilePhoneNumber = c.String(),
                        phoneNumber = c.String(),
                        bankName = c.String(),
                        bankClearingNumber = c.String(),
                        bankAccountNumber = c.String(),
                        hourSalary = c.String(),
                        password = c.String(),
                        personalNumber = c.String(),
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
                        sendSms = c.Boolean(nullable: false),
                        sendMail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.employee_id);
            
            CreateTable(
                "dbo.EmployeesPet",
                c => new
                    {
                        employeePet_id = c.Int(nullable: false),
                        approved = c.Boolean(),
                    })
                .PrimaryKey(t => t.employeePet_id)
                .ForeignKey("dbo.Employees", t => t.employeePet_id)
                .Index(t => t.employeePet_id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        pet_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.pet_id);
            
            CreateTable(
                "dbo.PetEmployeePets",
                c => new
                    {
                        Pet_id = c.Int(nullable: false),
                        EmployeePet_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pet_id, t.EmployeePet_id })
                .ForeignKey("dbo.Pets", t => t.Pet_id, cascadeDelete: true)
                .ForeignKey("dbo.EmployeesPet", t => t.EmployeePet_id, cascadeDelete: true)
                .Index(t => t.Pet_id)
                .Index(t => t.EmployeePet_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PetEmployeePets", new[] { "EmployeePet_id" });
            DropIndex("dbo.PetEmployeePets", new[] { "Pet_id" });
            DropIndex("dbo.EmployeesPet", new[] { "employeePet_id" });
            DropIndex("dbo.Missions", new[] { "pet_id" });
            DropIndex("dbo.Missions", new[] { "employee_id" });
            DropIndex("dbo.Missions", new[] { "customer_id" });
            DropForeignKey("dbo.PetEmployeePets", "EmployeePet_id", "dbo.EmployeesPet");
            DropForeignKey("dbo.PetEmployeePets", "Pet_id", "dbo.Pets");
            DropForeignKey("dbo.EmployeesPet", "employeePet_id", "dbo.Employees");
            DropForeignKey("dbo.Missions", "pet_id", "dbo.Pets");
            DropForeignKey("dbo.Missions", "employee_id", "dbo.Employees");
            DropForeignKey("dbo.Missions", "customer_id", "dbo.Customers");
            DropTable("dbo.PetEmployeePets");
            DropTable("dbo.Pets");
            DropTable("dbo.EmployeesPet");
            DropTable("dbo.Employees");
            DropTable("dbo.Missions");
            DropTable("dbo.Customers");
            DropTable("dbo.Administrators");
        }
    }
}
