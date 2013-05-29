namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Performers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        infoText = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        emailAddress = c.String(),
                        mobilePhoneNumber = c.String(),
                        phoneNumber = c.String(),
                        streetAddress = c.String(),
                        postalCode = c.String(),
                        postTown = c.String(),
                        country = c.String(),
                        bankName = c.String(),
                        bankClearingNumber = c.String(),
                        bankAccountNumber = c.String(),
                        fulltimeSalary = c.String(),
                        hourSalary = c.String(),
                        unsocialHoursBonusSimple = c.String(),
                        unsocialHoursBonusQualified = c.String(),
                        unsocialHoursBonusHoliday = c.String(),
                        travelCompensation = c.String(),
                        taxTable = c.String(),
                        taxColumn = c.String(),
                        password = c.String(),
                        enabled = c.Boolean(),
                        birthDate = c.DateTime(storeType: "date"),
                        startDate = c.DateTime(storeType: "date"),
                        updated = c.DateTime(),
                        created = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Performers");
        }
    }
}
