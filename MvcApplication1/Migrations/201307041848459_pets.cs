namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PetEmployee_Pet",
                c => new
                    {
                        Pet_id = c.Int(nullable: false),
                        Employee_Pet_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pet_id, t.Employee_Pet_id })
                .ForeignKey("dbo.Pets", t => t.Pet_id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Pet_id, cascadeDelete: true)
                .Index(t => t.Pet_id)
                .Index(t => t.Employee_Pet_id);
            
            CreateTable(
                "dbo.CustomerMission_PetPet",
                c => new
                    {
                        CustomerMission_Pet_id = c.Int(nullable: false),
                        Pet_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerMission_Pet_id, t.Pet_id })
                .ForeignKey("dbo.Customer_Missions", t => t.CustomerMission_Pet_id, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.Pet_id, cascadeDelete: true)
                .Index(t => t.CustomerMission_Pet_id)
                .Index(t => t.Pet_id);
            
            AddColumn("dbo.Employees", "approved", c => c.Boolean());
            AddColumn("dbo.Employees", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Customer_Missions", "cat");
            DropColumn("dbo.Customer_Missions", "dog");
            DropTable("dbo.EmployeeApplications");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Customer_Missions", "dog", c => c.Boolean());
            AddColumn("dbo.Customer_Missions", "cat", c => c.Boolean());
            DropIndex("dbo.CustomerMission_PetPet", new[] { "Pet_id" });
            DropIndex("dbo.CustomerMission_PetPet", new[] { "CustomerMission_Pet_id" });
            DropIndex("dbo.PetEmployee_Pet", new[] { "Employee_Pet_id" });
            DropIndex("dbo.PetEmployee_Pet", new[] { "Pet_id" });
            DropForeignKey("dbo.CustomerMission_PetPet", "Pet_id", "dbo.Pets");
            DropForeignKey("dbo.CustomerMission_PetPet", "CustomerMission_Pet_id", "dbo.Customer_Missions");
            DropForeignKey("dbo.PetEmployee_Pet", "Employee_Pet_id", "dbo.Employees");
            DropForeignKey("dbo.PetEmployee_Pet", "Pet_id", "dbo.Pets");
            DropColumn("dbo.Employees", "Discriminator");
            DropColumn("dbo.Employees", "approved");
            DropTable("dbo.CustomerMission_PetPet");
            DropTable("dbo.PetEmployee_Pet");
            DropTable("dbo.Pets");
        }
    }
}
