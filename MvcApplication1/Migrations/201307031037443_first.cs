namespace MvcApplication1.Migrations
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
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        emailAddress = c.String(),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Customer_Missions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
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
                        customerId = c.Int(nullable: false),
                        employeeId = c.Int(nullable: false),
                        cat = c.Boolean(),
                        dog = c.Boolean(),
                        other = c.String(),
                        duration = c.Int(),
                        startDateAndTime = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.customerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.employeeId, cascadeDelete: true)
                .Index(t => t.customerId)
                .Index(t => t.employeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
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
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.EmployeeApplications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        infoText = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        emailAddress = c.String(),
                        mobilePhoneNumber = c.String(),
                        phoneNumber = c.String(),
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
                        approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customer_Missions", new[] { "employeeId" });
            DropIndex("dbo.Customer_Missions", new[] { "customerId" });
            DropForeignKey("dbo.Customer_Missions", "employeeId", "dbo.Employees");
            DropForeignKey("dbo.Customer_Missions", "customerId", "dbo.Customers");
            DropTable("dbo.EmployeeApplications");
            DropTable("dbo.Employees");
            DropTable("dbo.Customer_Missions");
            DropTable("dbo.Customers");
            DropTable("dbo.Administrators");
        }
    }
}
